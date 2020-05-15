using Remote_db.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Remote_db.Models
{
    public class HouseRoom : IIdentifiable<string>
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey("House")]
        public int HouseId { get; set; }
        public virtual House House { get; set; }

        public bool Projector { get; set; }
        public bool WhiteBoard { get; set; }
        public string MapPic { get; set; }        

    }
    public class HouseRoomForUsers {
        public string RoomId { get; set; }
        public List<AvailableTimes> FreeTimes { get; set; }
    }
}