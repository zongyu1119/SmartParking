# 安装Node.js
FROM node:16

# 创建工作目录
WORKDIR /app

# 将node_modules添加到工作目录
COPY package.json .
RUN npm config set registry https://registry.npm.taobao.org/
RUN npm install
RUN npm install -g npm@8.1.3
RUN npm install -g @vue/cli@4.5.15

# 将所有文件复制到工作目录
COPY . .

# 编译前端项目
RUN npm run build:prod

# 产生静态文件
FROM nginx:stable-alpine
COPY --from=0 /app/dist /usr/share/nginx/html/
# COPY nginx.conf /etc/nginx/conf.d/default.conf
COPY nginx.conf /etc/nginx/conf.d/

# cd  /home/gitCodes/ZyMsg
# cd /home/gitCodes/ZyMsg/ZyMessageFront/ZyWeb
# docker build -f Dockerfile . -t zy_msg_f
# docker run -d --name zy_msg_f --restart always -p 80:80 zy_msg_f