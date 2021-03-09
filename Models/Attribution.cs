using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimerCard.Models
{
    public class Attribution
    {
        public string Id { get; set; }

        //班级名
        public string classDescription { get; set; }

        //学院Id
        public string collegeId { get; set; }

        //专业Id
        public string majorId { get; set; }

        //班级Id
        public string classId { get; set; }
    }
}
