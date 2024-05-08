Install-Package Microsoft.EntityFrameworkCore.Tools

Install-Package Pomelo.EntityFrameworkCore.MySql

Install-Package Microsoft.EntityFrameworkCore.Design                  //to webapi

每次代码更新或首次创建代码之后执行迁移(包含多个上下文时需加入参数-Context SysDbContext)：

Add-Migration InitialCreate-v0.1
Add-Migration InitialCreate-v0.1 -Context SysDbContext
如果有误可以使用以下命令撤回：

Remove-Migration
之后执行以下命令提交修改至数据库：

Update-Database 
Update-Database  -Context SysDbContext