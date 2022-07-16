using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Application.Entity
{
    public class UserDetails
    {
        public string id { get; set; }

        public string schoolCode { get; set; }

        public string schoolName { get; set; }

        public int identityType { get; set; }

        public string userId { get; set; }

        public string mobilePhone { get; set; }

        public string name { get; set; }

        public string jobNo { get; set; }

        public string departmentCode { get; set; }

        public string department { get; set; }

        public string specialitiesCode { get; set; }

        public string specialities { get; set; }

        public string classCode { get; set; }

        public string className { get; set; }

        public int provinceCode { get; set; }

        public string province { get; set; }

        public int cityCode { get; set; }

        public string city { get; set; }

        public int inSchool { get; set; }

        public int contactArea { get; set; }

        public int isPatient { get; set; }

        public int contactPatient { get; set; }

        public string linkPhone { get; set; }

        public string parentsPhone { get; set; }

        public string createTime { get; set; }

        public string createDate { get; set; }

        public string updateTime { get; set; }

        public string remark { get; set; }

        public string locationInfo { get; set; }

        public string longitudeAndLatitude { get; set; }

        public int isSuspected { get; set; }

        public string healthStatusNew { get; set; }

        public string identitySecondType { get; set; }

        public int districtCode { get; set; }

        public string district { get; set; }

        public int isFamiliyPatient { get; set; }

        public int isCommunityPatient { get; set; }

        public int isTodayBack { get; set; }
        
        public string patientHospital { get; set; }

        public string isolatedPlace { get; set; }

        public string temperature { get; set; }

        public string temperatureAfter { get; set; }

        public string country { get; set; }

        public string address { get; set; }

        public string token { get; set; }

        public string uuToken { get; set; }

        public string loginUserId { get; set; }

        public string loginUserName { get; set; }

        public string loginSchoolCode { get; set; }

        public string loginSchoolName { get; set; }

        public string platform { get; set; }

        //疫苗接种情况
        public string vaccineStatus { get; set; }

        public string vaccineOneTime { get; set; }

        public string vaccineTwoTime { get; set; }

        public string vaccineThreeTime { get; set; }

        public string deviceId {get; set;}
    }

    public class UserDetail
    {
        public int statusCode { get; set; }

        public string message { get; set; }

        public UserDetails data { get; set; }

        public string success { get; set; }
    }
}
