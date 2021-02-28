using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimerCard.Models
{
    public class CardLog
    {
        public string Id { get; set; }

        //用户
        public User User { get; set; }

        //打卡时间
        public DateTime PlayTime { get; set; }

        //打开状态（0: 失败；1: 成功）
        public int PlayStatus { get; set; }

        //二次打卡状态
        public int PlayStatusAgain { get; set; }

        //是否邮件提醒
        public int IsEmailMsg { get; set; }
    }
}
