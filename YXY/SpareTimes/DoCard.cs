using Admin.NET.Application.Entity;
using Admin.NET.Application.Enum;
using Admin.NET.Application.Service.CardsApi;
using Admin.NET.Application.Service.SeedMessage;
using Furion.DatabaseAccessor;
using Furion.DependencyInjection;
using Furion.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Admin.NET.Application.SpareTimes
{
    public class DoCard : ISpareTimeWorker
    {
        DingMessage msg = new DingMessage();
        [SpareTime(3000, "执行打卡", DoOnce = true, StartNow = true, ExecuteType = SpareTimeExecuteTypes.Serial)]
        public void DoCards(SpareTimer timer, long count)
        {
            //创建作用域
            Scoped.Create(async (factory, scope) =>
            {
                var db = Db.GetRepository<CardUsers>();
                
                var users = db.DetachedEntities;
                int allpeo = users.Count();

                if (db.Any())
                {
                    var api = new CardsApi();
                    int fail = 0;
                    foreach (var user in users) {
                        try {
                            var pk = api.GetPublicKey();
                            var en = new JsEncryptHelper("", pk);
                            var passwrd = en.Encrypt(user.Passwrd);

                            var response = api.Login(user.Account, passwrd);
                            if (!response.success.Equals("true"))
                            {
                                fail += 1;
                                msg.SendFailMsg(user, response.message);
                                continue;
                            }
                            await Task.Delay(RandomDelay());
                            UserDetail usr = api.GetDetail(response.data.id);
                            if (!usr.success.Equals("true"))
                            {
                                fail += 1;
                                msg.SendFailMsg(user, usr.message);
                                continue;
                            }
                            await Task.Delay(RandomDelay());
                            UserDetails u = usr.data;
                            u.address = user.Address;
                            //u.token = response.data.token;
                            u.uuToken = response.data.uuToken;
                            u.loginUserId = u.userId;
                            u.loginUserName = u.name;
                            u.loginSchoolCode = u.schoolCode;
                            u.loginSchoolName = u.schoolName;
                            u.deviceId = response.data.deviceId;
                            u.updateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            u.platform = "YUNMA_APP";
                            u.temperature = GetRandomNumber(35.5, 37.0, 1).ToString();
                            u.id = "2203413" + GetTimeStamp().ToString();

                            //提交打卡
                            var info = api.DoDetail(u);
                            if (string.IsNullOrEmpty(info.success) || !info.success.Equals("true"))
                            {
                                fail += 1;
                                msg.SendFailMsg(user, info.message);
                                continue;
                            }
                            await Task.Delay(RandomDelay());

                        }
                        catch (Exception ex)
                        {
                            fail++;
                            msg.SendFailMsg(user,"出现异常终止！"+ex.Message);
                        }
                        
                    }
                   
                    string str = "### **易校园打卡汇总通知** \n" +
                          "#### **总人数 ：** " + allpeo + "人 \n" +
                          "#### **成  功  ：** " + (allpeo - fail) + " 人 \n" +
                          "#### **失  败  ：** " + fail + " 人 \n" +
                          "#### **日  志  ：** 暂无日志！\n" +
                          "#### **状  态  ：** " + (fail == 0 ? "<font color=\"#00FF00\">打卡成功！</font>" : "<font color=\"#FFA500\">打卡异常！</font>") + " \n" +
                          "#### **时  间  ：** " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " \n";
                    msg.SendBaseMarkdown("" + (fail == 0 ? "打卡成功(All)！" : "打卡异常！") + "", str, true, PushType.YXY);

                }
                else {
                    msg.SendFailMsg(new CardUsers() {Name="系统" },"用户列表为空！警告！！！");
                }
            });
        }

        

        public static double GetRandomNumber(double minimum, double maximum, int Len)
        {
            Random random = new Random();
            return Math.Round(random.NextDouble() * (maximum - minimum) + minimum, Len);
        }

        public static int RandomDelay() {
            Random rd = new Random();
            int i = rd.Next(1, 15);
            return i * 1000;
        }

        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
    }
}
