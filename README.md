# 完美校园自动打卡 (一个账户多人打卡 & 带邮件提醒和简单Web)
## · 项目结构
### · 由 .NET Core MVC 和 Python脚本构成
1. 前端主要用于添加打卡信息到SqlLite数据库和日志显示
2. 后台Python脚本用于执行打卡  
主要目录  
├── bin     
├── Controllers  
├── Models  
├── TimeCard_py  #Python脚本目录  
│   ├── *TimerCardDB  #用户数据库*  
│   ├── *appsettings  #脚本配置文件*  
│   ├── *requirements  #脚本配置文件*  
│── wwwroot #静态js规则文件  
│── Views  #网页文件  
│── appsettings.json  #网站配置文件 

## · 功能及使用
1. 环境部署  
Python == 3.7  
[.Net Core Runtime 3.1](https://dotnet.microsoft.com/download/visual-studio-sdks)  
2. Web网站  
下载源码使用VisualStudio 2019/2017 生成  

### · 配置文件(/TimeCard_py/appsettings.py)
    #完美校园用于打卡的主要账户(必填)
    Account = '1238888******'
    Password = 'xxxxxxxxx'
    IMEI = '865166023950952' #手机标识 (在Android模拟器中获取)


    # 数据库地址 SqlLite数据库路径
    DBDir = 'E:\xx\xxxx\TimerCard_py\TimerCardDB.db'

    # Email参数 (邮件提醒功能)
    mail_host = "smtp.qq.com"
    mail_user = "xxxx@qq.com"
    mail_pass = "xxxxxxxxxxxx"
    sender = 'xxxxxxxxxx@qq.com'
    AdminEmails = ['1210000000@qq.com'] #管理员邮箱(可多位)

    # 用户ids (抓包获取)
    uids = ['25276456', '25241996', '25246201']

    # 打卡位置
    def GetSchoolLocations()


### · 关于 登录 和 IMEI获取问题
        现有的大部分打卡脚本都失效了，是由于获取手机IMEI串的问题，在使用打卡脚本之前请先在Android模拟器上进行登录并将模拟器上的IMEI复制下来填入配置文件中 即可成功使用脚本登录获取token来进行打卡，注意用于登录的账户请不要用手机登录，否则会导致脚本二次登录失败.

### · 打卡事项
· 该脚本登录一次即可为数据库中的所有用户打卡(非跨校),服务器只校验打卡用户的学号(工号)，班级id，学校id以及姓名.

## · 注意事项 
· 该项目只用于学习研究请不要用于违规事宜，所造成的后果与作者无关.

## ·