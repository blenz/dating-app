FROM node:11-alpine

WORKDIR /usr/src/app

COPY package.json .

RUN npm install && npm install -g @angular/cli@6.0.8

COPY . .

CMD ["ng", "serve", "--host", "0.0.0.0"]