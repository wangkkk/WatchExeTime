# WatchExeTime
编程时间、水群时间统计
可以统计你今天水群时间或编程时间，根据编程时间，显示不同的编程等级。
时间显示有按次显示（离开监视的程序后再次归零计时）、按天计时。
默认按Ctrol+F8隐藏窗口、按Shift+F9显示窗口。
程序使用三层架构，Dapper+SQLite作DAO层。使用接口编程，方便拓展数据库或增加数据库。