using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Application.Util
{
    public class markdown
    {
        public string title { get; set; }

        public string text { get; set; }
    }

    public class At
    {
        public List<string> atMobiles { get; set; }

        public List<string> atUserIds { get; set; }

        public string isAtAll { get; set; }
    }

    public  class Markdowns
    {
        public  string msgtype { get; set; }

        public  markdown markdown { get; set; }

        public  At at { get; set; }
    }

}
