# 设置基础镜像
FROM nginx
# 定义作者
MAINTAINER zy1119
# 将dist文件中的内容复制到 /usr/share/nginx/html/ 这个目录下面
COPY ./  /usr/share/nginx/html/
COPY nginx.conf /etc/nginx/nginx.conf
RUN echo 'zy init ok!!'


# cd /home/gitCodes/ZyMsg/ZyMessageFront/ZyWeb
# git pull origin master
# docker build -f Dockerfile . -t zy_msg_f
# docker run -d --name zy_msg_f --restart always -p 80:80 zy_msg_f