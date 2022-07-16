using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimerCard.Util
{
    public class Tools
    {
        //随机体温
        public static double  GetTemperature() {
            Random random = new Random();
            double Temper = 36 + random.Next(2,8) * 0.1;
            return Temper;
        }
    }
}
