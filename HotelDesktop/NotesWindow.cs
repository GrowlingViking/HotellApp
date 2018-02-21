using HotelCore.Entities;
using HotelCore.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelDesktop
{
    public partial class NotesWindow : Form
    {

        ReceptionService rs;
        List<Note> notes;
        HotelCore.Entities.Task task;

        public NotesWindow(int taskId, ReceptionService rs)
        {
            InitializeComponent();

            this.rs = rs;
            task = rs.GetTask(taskId);

            InitializeNotes();
        }

        public void InitializeNotes()
        {
            notes = rs.GetNotes(task.Id);
            dataGridView1.DataSource = notes.Select(n => new { Text = n.Text }).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
                if (rs.NewNote(task.Id, textBox1.Text))
                    InitializeNotes();
        }
    }
}
