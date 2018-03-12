using System;

namespace TodoApi.Models
{
    public class TodoItem
    {
        public string Key { get; set; }
        public string Maqazin_Adi { get; set; }
        public string Filial { get; set; }
        public string Paltar_Nov { get; set; }
        public string Razmer { get; set; }
        public string Reng { get; set; }
        public string Endirim_Faiz { get; set; }
        public DateTime DeadLine { get; set; }
        public bool  Iscomplete { get; set; }
    }
}
