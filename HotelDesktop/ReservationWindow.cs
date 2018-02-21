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
    public partial class ReservationWindow : Form
    {

        ReceptionService rs;
        Reservation reservation;

        public ReservationWindow(int id, ReceptionService rs)
        {
            InitializeComponent();

            this.rs = rs;
            this.reservation = rs.GetReservations(false).Where(r => r.Id == id).First();

            Id.Text = reservation.Id.ToString();
            Start.Value = reservation.Start;
            End.Value = reservation.End;
            foreach (String s in rs.GetRoomTypes())
                Type.Items.Add(s);
            Type.SelectedItem = reservation.Type.Name;
            User.Text = reservation.User.UserName;

            foreach (Room r in rs.GetReadyRooms(reservation.Type.Name))
                RoomSelect.Items.Add(r.Nr);

            if (reservation.Room != null)
            {
                RoomSelect.Items.Add(reservation.Room.Nr);
                RoomSelect.SelectedItem = reservation.Room.Nr;
            }
        }

        private void CheckIn_Click(object sender, EventArgs e)
        {
            int room;
            if (int.TryParse(RoomSelect.SelectedItem.ToString(), out room) && reservation.Room == null)
                if (rs.CheckIn(reservation.Id, room))
                    this.Close();
        }

        private void CheckOut_Click(object sender, EventArgs e)
        {
            if (rs.CheckOut(reservation.Id))
                this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (rs.ModifyRes(reservation.Id, Start.Value, End.Value, Type.SelectedItem.ToString()))
                this.Close();
        }

        private void Type_SelectedValueChanged(object sender, EventArgs e)
        {
            RoomSelect.Items.Clear();
            foreach (Room r in rs.GetReadyRooms(Type.SelectedItem.ToString()))
                RoomSelect.Items.Add(r.Nr);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Warning", "Vietnam", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
                if (rs.DeleteRes(reservation.Id))
                    this.Close();
        }
    }
}
