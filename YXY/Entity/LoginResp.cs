using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Application.Entity
{
    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string schoolCode { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string schoolName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int qrcodePayType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string account { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string accountEncrypt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string userType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mobilePhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string jobNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string userIdcard { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string identityNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int sex { get; set; }
        /// <summary>

        /// </summary>
        public string userClass { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int realNameStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string regiserTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nickName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int bindCardStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string bindCardTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lastLogin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string headImg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string deviceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int testAccount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int joinNewactivityStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int createStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int eacctStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int schoolClasses { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int schoolNature { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string platform { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string uuToken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string qrcodePrivateKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int bindCardRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int points { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int schoolIdentityType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int alumniFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string extJson { get; set; }
    }

    public class LoginResp
    {
        /// <summary>
        /// 
        /// </summary>
        public int statusCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string success { get; set; }
    }

}
