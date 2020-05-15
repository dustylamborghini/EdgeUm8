using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EdgeUm8.Models
{
    public class HouseRoom
    {
        [PrimaryKey]
        public string Id { get; set; }

        [ForeignKey(typeof(House))]
        public int HouseId { get; set; }

        public bool Projector { get; set; }
        public bool WhiteBoard { get; set; }
        public string MapPic { get; set; }
    }

    public class HouseRoomViewModel
    {
        public int HouseId { get; set; }
        public bool Projector { get; set; }
        public bool WhiteBoard { get; set; }
        public List<AvailableTimes> FreeTimes { get; set; }
    }
}
