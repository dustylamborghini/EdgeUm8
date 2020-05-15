using SQLite;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EdgeUm8.Models
{
    public class House
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string HouseName { get; set; }
        public TimeSpan Opens { get; set; }
        public TimeSpan Closes { get; set; }
        public Byte[] MapPic { get; set; }

    }

    public class HouseViewModel
    {
        public string HouseName { get; set; }

        public TimeSpan Opens { get; set; }

        public TimeSpan Closes { get; set; }

        public string MapPic { get; set; }

        public List<HouseRoomViewModel> Rooms { get; set; }
    }
}
