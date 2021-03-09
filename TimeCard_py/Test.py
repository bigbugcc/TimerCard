import json
import traceback
from Crypto.Random import random
import iEmail
import uuid
import BaseData
import DBUtils
import utils
import time



if __name__ == '__main__':
    try:
        # te = DBUtils.GetAttributionInfo('31351f75-8a6f-8d27-aea8-1d7676d85b66')
        #print(utils.GetSchoolLocations())

        DBUtils.WriteLog('打卡失败', 'Warning', 'System', '信息不在资源列表中')
    except Exception as e:
        print(e.__class__)