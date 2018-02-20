using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelCore.Services;
using HotelCore;
using System.Reflection;
using HotelCore.Entities;

namespace HotelDesktop
{
    public partial class HotelMainWindow : Form
    {

        ReceptionService rs;
        bool active = true;

        public HotelMainWindow()
        {
            InitializeComponent();

            rs = new ServiceFactory().GetReceptionService();

            InitializeData();

            rs.StateChanged += Rs_StateChanged;
        }

        private void Rs_StateChanged(object sender)
        {
            InitializeData();
        }

        private void InitializeData()
        {
            var res = rs.GetReservations(active).Select(r => new
            {
                Id = r.Id,
                CheckIn = r.Start,
                CheckOut = r.End,
                ContactName = r.User.UserName == null ? "" : r.User.UserName,
                RoomType = r.Type.Name,
                Room = r.Room == null ? "" : r.Room.Nr.ToString()
            }).OrderByDescending(r => r.CheckIn).ToList();

            var rooms = rs.GetRooms().Select(r => new
            {
                Nr = r.Nr,
                RoomType = r.Type == null ? "" : r.Type.Name
            }).ToList();

            dataGridView2.DataSource = res;
            dataGridView1.DataSource = rooms;
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridView2.SelectedRows[0].Cells[0].Value;
            new ReservationWindow(id, rs).Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
        }

        private void ShowOld_CheckedChanged(object sender, EventArgs e)
        {
            active = !ShowOld.Checked;
            InitializeData();
        }
    }
}
