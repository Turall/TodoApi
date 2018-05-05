using System;

namespace TodoApi.Models
{
    public class StatusInfo
    {
        public string Key { get; set; }
        public string Azercell{ get; set; }
        public string Express { get; set; }
        public string Phone_Model { get; set; }
        public string Problem { get; set; }
        public bool Repair_Status { get; set; }
        public string Username { get; set; }
        public DateTime DeadLine { get; set; }
        public bool  Iscomplete { get; set; }
        public double Price { get; set; }
    }
}
