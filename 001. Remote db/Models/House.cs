using Remote_db.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Remote_db.Models
{
    public class House : IIdentifiable<int>
    {
        [Key]
        public int Id { get; set; }

        public string HouseName { get; set; }

        public TimeSpan Opens { get; set; }

        public TimeSpan Closes { get; set; }

        public string MapPic { get; set; }
    }
}