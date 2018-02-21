using HotelCore;
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
    public partial class RoomWindow : Form
    {

        ReceptionService rs;
        Room room;
        List<HotelCore.Entities.Task> tasks;

        public RoomWindow(int nr, ReceptionService rs)
        {
            InitializeComponent();

            this.rs = rs;
            room = rs.GetRoom(nr);

            IdRoom.Text = room.Id.ToString();
            NrRoom.Text = room.Nr.ToString();
            foreach (String s in rs.GetRoomTypes())
                TypeSelect.Items.Add(s);
            TypeSelect.SelectedItem = room.Type.Name;

            InitializeTasks();

            ServiceType.Items.Add(TaskTypes.Cleaning);
            ServiceType.Items.Add(TaskTypes.Maintenance);
            ServiceType.Items.Add(TaskTypes.Service);

            Status.Items.Add(HotelCore.TaskStatus.New);
            Status.Items.Add(HotelCore.TaskStatus.In_progress);
            Status.Items.Add(HotelCore.TaskStatus.Finished);
        }

        private void InitializeTasks()
        {
            tasks = rs.GetTasks(room.Id);
            if (tasks != null)
                dataGridView1.DataSource = tasks.Select(t => new { Id = t.Id, Type = t.ServiceType, Status = t.Status }).ToList();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                HotelCore.Entities.Task task = tasks.Where(t => t.Id == id).First();
                IdTask.Text = task.Id.ToString();
                ServiceType.SelectedItem = task.ServiceType;
                Status.SelectedItem = task.Status;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ServiceType.SelectedItem != null)
                if (rs.NewTask(room.Id, ServiceType.SelectedItem.ToString()))
                    InitializeTasks();
        }
    }
}
