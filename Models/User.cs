using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimerCard.Models
{
    public class User
    {
        public string Id { get; set; }

        //姓名
        public string Name { get; set; }
        
        //学号
        public string StuId { get; set; }
        
        //专业
        public string Discipline{ get; set; }

        //班主任姓名
        public string TeachName { get; set; }
        
        //体温
        public double Temperature { get; set; }

        //Email
        public string Email { get; set; }

        //PhoneNumber
        public string PhoneNumber { get; set; }

        //紧急联系人（姓名）
        public string EmergencyContact { get; set; }

        //紧急联系人电话
        public string MergencyPeoplePhone { get; set; }

        //本人现家庭居住地址
        public string Langtineadress { get; set; }

    }
}
