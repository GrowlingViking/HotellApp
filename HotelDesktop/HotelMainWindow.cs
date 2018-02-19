﻿using System;
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

        public HotelMainWindow()
        {
            InitializeComponent();

            rs = new ServiceFactory().GetReceptionService();

            var res = rs.GetReservations(false).Select(r => new
            {
                Id = r.Id,
                CheckIn = r.Start,
                CheckOut = r.End,
                ContactName = r.User.UserName,
                RoomType = r.Type.Name,
                Room = r.Room == null ? "" : r.Room.Nr.ToString()
            }).ToList();

            var rooms = rs.GetRooms().Select(r => new
            {
                Id = r.Id,
                Nr = r.Nr,
                RoomType = r.Type == null ? "" : r.Type.Name
            }).ToList();

            dataGridView2.DataSource = res;
            dataGridView1.DataSource = rooms;
        }
    }
}
