# 上位机软件

---  
1，连接前，需先配置电脑的IP，与PMAC和Basler相机通讯需要；
2，目标检测用的是yolo，检测时会占用比较多的资源，因此可能会影响到主界面（尽管已经开了子线程执行）
3，数据库默认连接到本地的Mysql服务，默认root用户
(server=127.0.0.1;port=3306;user=root;password=123456; database=teammates)
并且需要提前进行配置。
---  

**Tips**:  
- 管理员权限启动
- 环境: 安装PeWin32 pro2
- 运行程序: 暂且在debug模型下调试运行