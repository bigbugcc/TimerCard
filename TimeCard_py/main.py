# -*- coding: utf-8 -*-
import time
import requests
from Crypto.Random import random
import login
import iEmail
import DBUtils
import appsettings
import utils
uids = appsettings.uids

def PCardInfo(user, token):
    Submit_url = "https://reportedh5.17wanxiao.com/sass/api/epmpics"
    uid = uids[random.randint(0, (len(uids) - 1))]
    temp = 36+random.randint(2, 8)*0.1
    customerid = '1911'

    AttrInfo = DBUtils.GetAttributionInfo(user['AttributionId'])
    response = {}
    if AttrInfo != None:
        check_json = {
            "businessType": "epmpics",
            "method": "submitUpInfo",
            "jsonData": {
                "deptStr": {
                    "deptid": AttrInfo['classId'],
                    "text": AttrInfo['classDescription']
                },
                "areaStr": utils.GetSchoolLocations(),
                "reportdate": round(time.time()*1000),
                "customerid": customerid,
                "deptid": AttrInfo['classId'],
                "source": "app",
                "templateid": "pneumonia",
                "stuNo": user["StuId"],
                "username": user["Name"],
                "phonenum": "",
                "userid": uid,
                "updatainfo": [
                    {
                        "propertyname": "isAlreadyInSchool",
                        "value": "云南昆明"
                    },
                    {
                        "propertyname": "temperature",
                        "value": temp
                    },
                    {
                        "propertyname": "jtdz",
                        "value": user["TeachName"]
                    },
                    {
                        "propertyname": "Nativeplace",
                        "value": "未分配"
                    },
                    {
                        "propertyname": "ownPhone",
                        "value": user["PhoneNumber"]
                    },
                    {
                        "propertyname": "emergencyContact",
                        "value": user["EmergencyContact"]
                    },
                    {
                        "propertyname": "mergencyPeoplePhone",
                        "value": user["MergencyPeoplePhone"]
                    },
                    {
                        "propertyname": "symptom",
                        "value": "无症状"
                    },
                    {
                        "propertyname": "isTouch",
                        "value": "否"
                    },
                    {
                        "propertyname": "xinqing",
                        "value": "否"
                    },
                    {
                        "propertyname": "isGoWarningAdress",
                        "value": "否"
                    },
                    {
                        "propertyname": "cxjh",
                        "value": "否"
                    },
                    {
                        "propertyname": "isFFHasSymptom",
                        "value": "否"
                    },
                    {
                        "propertyname": "isleaveaddress",
                        "value": "否"
                    },
                    {
                        "propertyname": "person",
                        "value": ""
                    },
                    {
                        "propertyname": "langtineadress",
                        "value": user["Langtineadress"]
                    },
                    {
                        "propertyname": "assistRemark",
                        "value": "无"
                    },
                    {
                        "propertyname": "other2",
                        "value": ""
                    }
                ],
                "gpsType": 1,
                "token": token
            }
        }
        res = requests.post(Submit_url, json=check_json)
        response = res.json()
        if response["code"] == "10000":
            print(user["Name"] + "打卡成功！")
            DBUtils.WriteLog('打卡成功', DBUtils.LogStable, (user['Name'] + '-' + user["StuId"]), 'System-PCardInfo',
                             str(response))
            iEmail.PostEmail('完美校园打卡', '成功', user, '')

        else:
            print(user["Name"] + "打卡失败！")
            print(response)
            DBUtils.WriteLog('打卡失败', DBUtils.LogWarning, (user['Name'] + '-' + user["StuId"]), 'System-PCardInfo',
                             str(response))
            iEmail.PostEmail('完美校园打卡', '失败', user, response['data'])

    else:
        print('归属信息错误！')
        response = {'code': '404', 'data': '归属信息错误！'}
        DBUtils.WriteLog('归属信息错误', DBUtils.LogWarning, (user['Name'] + '-' + user["StuId"]), 'System-PCardInfo',
                         str(response))
        iEmail.PostEmail('完美校园打卡', '失败', user, response['data'])
    return response


if __name__ == '__main__':
    # token = login.start_Login("13759151349", "hn235689", "865166023950952")
    # token = login.start_Login("18468057774", "zpc12345678", "865166023950952")
    token = login.start_Login("15687231638", "wyl13887242608", "865166023950952")
    UserInfo = login.GetUserInfo(token)
    count = 0
    count_F = 0
    ErrorList = {}
    Users = DBUtils.GetDBUser()

    for user in Users:
        status = PCardInfo(user, token)
        count += 1
        if status['code'] != '10000':
            count_F += 1
            name = user['Name']+'- [ '+user['StuId']+' ]'
            ErrorList.update({name: status['data']})
            if len(Users) == count:
                continue
            time.sleep(random.randint(125, 200))
            continue
        if len(Users) == count:
            continue
        time.sleep(random.randint(30, 45))

    dataJson = {
        'count': str(count),
        'count_F': str(count_F),
        'count_T': str(count-count_F),
        'ErrorList': ErrorList
    }
    iEmail.AdminEmail(dataJson)