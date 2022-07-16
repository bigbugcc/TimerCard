# -*- coding: utf-8 -*-
import json
import sqlite3
import traceback
import iEmail
import appsettings
import time
import uuid
# 数据库连接信息
DBDir = appsettings.DBDir
LogWarning = 'Warning'
LogError = 'Error'
LogStable = 'Stable'

# 获取所有学生信息
def GetDBUser():
    Users = []

    try:
        con = sqlite3.connect(DBDir)
        cur = con.cursor()
        cur.execute("select * from user")

        data = cur.fetchall()
        columns = [column[0] for column in cur.description]

        for user in data:
            Users.append(dict(zip(columns, user)))
    except Exception as e:
        iEmail.EmailError(str(traceback.format_exc()), {'Name': 'System-GetDBUser'})
        print(str(e.__class__))
    finally:
        con.close()
    return Users


#获取归属信息
def GetAttributionInfo(Id):

    AttrData  = None;
    try:
        con = sqlite3.connect(DBDir)
        cur = con.cursor()
        cur.execute("select * from Attribution WHERE Id =? ",  (Id,))

        data = cur.fetchall()
        columns = [column[0] for column in cur.description]

        for item in data:
            AttrData = dict(zip(columns, item))

    except Exception as e:
        iEmail.EmailError(str(traceback.format_exc()), {'Name': 'System-GetAttributionInfo'})
        print(str(e.__class__))
        print(str(traceback.format_exc()))
    finally:
        con.close()
        return AttrData

#打卡日志
def WriteLog(Title,Type,UName,Creator,Msg):
    try:
        con = sqlite3.connect(DBDir)
        cur = con.cursor()
        cur.execute("INSERT INTO Log(Id,Title, Type,UName, Creator, Date, Msg) VALUES(?,?, ?, ?, ?, ?, ?)",  (str(uuid.uuid1()),Title,Type,UName,Creator,time.strftime("%Y-%m-%d %H:%M:%S", time.localtime()),Msg))
        status = con.commit()
    except Exception as e:
        iEmail.EmailError(str(traceback.format_exc()), {'Name': 'System-WriteLog'})
        print(str(e.__class__))
        print(str(traceback.format_exc()))
    finally:
        con.close()