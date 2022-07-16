# -*- coding: utf-8 -*-
from Crypto.Random import random
#完美校园用于打卡的主要账户(必填)
Account = '1238888******'
Password = 'xxxxxxxxx'
IMEI = '865166023950952' #手机标识 (在Android模拟器中获取)


# 数据库地址 SqlLite数据库路径
DBDir = 'E:\WorkSpace\YNNU\TimerCard_py\TimerCardDB.db'

# Email参数 (邮件提醒功能)
mail_host = "smtp.qq.com"
mail_user = "xxxx@qq.com"
mail_pass = "xxxxxxxxxxxx"
sender = 'xxxxxxxxxx@qq.com'
AdminEmails = ['1210000000@qq.com'] #管理员邮箱(可多位)

# 用户ids (抓包获取)
uids = ['25276456', '25241996', '25246201']

# 打卡位置
def GetSchoolLocations():
    # 随机地理范围 (百度或者高德自行查阅天填写) 也可直接固定
    lng = str(102.86 + random.randint(7362, 9132) * 0.000001)
    lat = str(24.86 + random.randint(6747, 8677) * 0.000001)
    #抓包获取(替换即可) 也可自行地图定位
    LocationStr = "{\"streetNumber\":\"\",\"street\":\"xxxx\",\"district\":\"xx区\",\"city\":\"xxxx\",\"province\":\"云南省\",\"pois\":\"xx大学呈xx区东区xx公寓\",\"lng\":"+lng+",\"lat\":"+lat+",\"address\":\"xxxxxxxxxxxxxxxxx\",\"text\":\"云南省-xxx\",\"code\":\"\"}"
    return LocationStr
