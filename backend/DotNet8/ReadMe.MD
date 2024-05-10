# 服务端架构
## 1. 日志
1. 日志使用NLog;
1. 在Zy.Shared.ZyLog项目中修改日志配置，默认日志写入文本文件，按需写入数据库；
## 2. 调试与工具 
1. 使用Dumpify作为调试扩展工具包；https://mp.weixin.qq.com/s/N6Ld3fO6rflew-0xX_E_mQ
1. 可以使用MethodTimer.Fody包进行方法计时；https://mp.weixin.qq.com/s/IkQkqI6GbIXxLXpcMTgG4w
1. 使用SwaggerDoc生成MarkDown接口文档；https://{IP}:{Port}/doc?swaggerVersion=v1
## 3. 微服务 
1. 使用ClickHouse保存操作日志以及系统产生的一些业务日志，如：数据修改日志等；
1. 使用GRpc实现跨服务间通信；
## 4. 数据库
1. 系统默认使用MySql数据库，支持读写分离(mysql-proxy实现读写分离)；
1. 使用ShardingCore实现分表，也可通过更改ShardingCore配置实现读写分离；
1. 使用EntityFramework-Plus实现EF的一些扩展操作，如批量删除等；
