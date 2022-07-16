# -*- coding: utf-8 -*-
import smtplib
import time
import traceback
import EmailHtml
import appsettings
from email.header import Header
from email.mime.text import MIMEText

#Email参数
mail_host = appsettings.mail_host
mail_user = appsettings.mail_user
mail_pass = appsettings.mail_pass
sender = appsettings.sender

#管理员邮箱
AdminEmails = appsettings.AdminEmails


#打卡状态邮件提示
def PostEmail(Title,IsOk,User,Other):

    ostr = '';
    if Other!='': ostr = '提示 : '+str(Other)+'<br>'
    receivers = User["Email"]  # 接收邮件
    subject = ' '+Title+'『' + IsOk + '』'
    msg = "姓名 : "+User["Name"]+" <br>" \
    "学号 : " + User["StuId"] + " <br>" \
    "状态 : 打卡"+IsOk+"!<br>" \
    ""+ostr+"" \
    "时间 : "+time.strftime("%Y-%m-%d %H:%M:%S", time.localtime())+""
    message = MIMEText(EmailHtml.EmailTemp("完美校园打卡 『"+ IsOk +"』",msg), 'html', 'utf-8')
    message['From'] = Header("BigBug", 'utf-8')
    message['Subject'] = Header(subject, 'utf-8')

    try:
        smtpObj = smtplib.SMTP_SSL(mail_host, 465)
        smtpObj.login(mail_user, mail_pass)
        smtpObj.sendmail(sender, receivers, message.as_string())

    except smtplib.SMTPException:
        EmailError(str(traceback.format_exc()),{'Name':User['Name']})
        print("Error: 无法发送邮件")

#管理员邮件提示
def AdminEmail(dataJson):
    ErrorInfo = ""
    if len(dict(dataJson['ErrorList'])) > 0:
        ErrorInfo += "提示 : <br>";
        for user in dict(dataJson['ErrorList']).items():
            ErrorInfo += '<strong>'+str(user)+'</strong><br>';
    subject = '完美校园打卡 『管理员』'
    msg = "<strong>今日打卡信息如下 :</strong><br>" \
    "打卡总人数 : "+str(dataJson['count'])+"<br>" \
    "打卡成功 : "+str(dataJson['count_T'])+"<br>" \
    "打卡失败 : "+str(dataJson['count_F'])+"<br>" \
    ""+ErrorInfo+"" \
    "时间 : " + time.strftime("%Y-%m-%d %H:%M:%S", time.localtime()) + ""
    message = MIMEText(EmailHtml.EmailTemp("完美校园 『管理员』", msg), 'html', 'utf-8')
    message['From'] = Header("BigBug", 'utf-8')
    message['To'] = Header('管理员', 'utf-8')
    message['Subject'] = Header(subject, 'utf-8')

    try:
        smtpObj = smtplib.SMTP_SSL(mail_host, 465)
        smtpObj.login(mail_user, mail_pass)
        smtpObj.sendmail(sender, AdminEmails, message.as_string())

    except smtplib.SMTPException:
        EmailError(str(traceback.format_exc()),{'Name':dataJson['System-AdminEmail']})
        print("Error: 无法发送邮件")

#警告邮件
def EmailWarning(Title,Msg):
    subject = Title
    msg = '<strong>警告信息如下(服务可能已经奔溃！) :</strong><br> '+Msg+''
    message = MIMEText(EmailHtml.EmailTemp(Title, msg), 'html', 'utf-8')
    message['From'] = Header("BigBug", 'utf-8')
    message['To'] = Header('管理员', 'utf-8')
    message['Subject'] = Header(subject, 'utf-8')

    try:
        smtpObj = smtplib.SMTP_SSL(mail_host, 465)
        smtpObj.login(mail_user, mail_pass)
        smtpObj.sendmail(sender, AdminEmails, message.as_string())

    except smtplib.SMTPException:
        EmailError(str(traceback.format_exc()),{'Name':'System-AdminEmail'})
        print("Error: 无法发送邮件")

#邮件信息发送错误
def EmailError(ErrorMsg,User):
    subject = '完美校园 [Email发送失败]'
    msg = '<strong>邮件发送失败(错误信息如下):</strong><br> ' \
          '错误对象: '+User["Name"]+' <br>'+ErrorMsg+''
    message = MIMEText(EmailHtml.EmailTemp('完美校园 [Email发送失败]', msg), 'html', 'utf-8')
    message['From'] = Header("BigBug", 'utf-8')
    message['To'] = Header('管理员', 'utf-8')
    message['Subject'] = Header(subject, 'utf-8')

    try:
        smtpObj = smtplib.SMTP_SSL(mail_host, 465)
        smtpObj.login(mail_user, mail_pass)
        smtpObj.sendmail(sender, AdminEmails, message.as_string())

    except smtplib.SMTPException:
        print("Error: 无法发送邮件")