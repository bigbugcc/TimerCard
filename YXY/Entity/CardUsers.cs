using Furion.Extras.Admin.NET;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Application.Entity
{
    [Table("card_user")]
    [Comment("打卡用户")]
    public class CardUsers : DEntityBase
    {
        [Comment("姓名")]
        [Required, MaxLength(20)]
        public string Name { get; set; }

        [Comment("账号")]
        [Required,MaxLength(25)]
        public string Account { get; set; }

        [Comment("密码")]
        [Required, MaxLength(30)]
        public string Passwrd { get; set; }

        [Comment("现居地址")]
        [Required, MaxLength(100)]
        public string Address { get; set; }

        [Comment("邮箱")]
        [Required, MaxLength(100)]
        public string Email { get; set; }
    }
}
