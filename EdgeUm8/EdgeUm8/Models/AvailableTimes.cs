using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdgeUm8.Models
{
    public class AvailableTimes
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(HouseRoom))]
        public string RoomId { get; set; }

        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }

        public AvailableTimes() { }
    }

    public class AvailableTimesViewModel : List<AvailableTimes>
    {
        public string RoomId { get; set; }
        public List<AvailableTimes> TimesForRoom { get; set; }

        public AvailableTimesViewModel() { }
    }
}
