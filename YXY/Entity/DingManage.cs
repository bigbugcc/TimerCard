using Admin.NET.Application.Enum;
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
    [Table("ding_manage")]
    [Comment("推送列表")]
    public class DingManage: DEntityBase
    {
        [Comment("标题")]
        [Required]
        public string Name { get; set; }

        [Comment("WebHookToken")]
        [Required]
        public string WHToken { get; set; }

        [Comment("推送对象")]
        [Required]
        public PushType Pusher { get; set; }
    }
}
