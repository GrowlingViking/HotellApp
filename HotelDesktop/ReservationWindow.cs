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
            this.reservation = rs.GetReservation(id);

            Id.Text = reservation.Id.ToString();
            Start.Value = reservation.Start;
            End.Value = reservation.End;
            foreach (String s in rs.GetRoomTypes())
                Type.Items.Add(s);
            Type.SelectedItem = reservation.Type.Name;
            User.Text = reservation.User.UserName;

            foreach (Room r in rs.GetReadyRooms(reservation.Type.Name))
                RoomSelect.Items.Add(r.Nr);

        }

        private void CheckIn_Click(object sender, EventArgs e)
        {
            int room;
            if (int.TryParse(RoomSelect.SelectedItem.ToString(), out room))
                if (rs.CheckIn(reservation.Id, room))
                    this.Close();
        }
    }
}
