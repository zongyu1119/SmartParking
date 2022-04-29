@echo off
start "ne_backend" cmd /k call start_backend.bat
echo 等待后端启动完成...

echo 启动前端...
start "ne_frontend" cmd /k call start_frontend.bat
exit