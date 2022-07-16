using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimerCard.Models
{
    public class Log
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Uid { get; set; }

        public string UName { get; set; }

        public string Type { get; set; }

        public string Creator { get; set; }

        public DateTime Date { get; set; }

        public string Msg { get; set; }
    }
}
