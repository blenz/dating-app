FROM node:11-alpine AS build
WORKDIR /usr/src/app
COPY package.json .
RUN npm install && npm install -g @angular/cli@6.0.8
COPY . .
RUN ng build --prod --base-href=/dating/ --build-optimizer=false

FROM nginx:alpine
RUN rm -rf /usr/share/nginx/html/*
COPY build/prod/default.conf /etc/nginx/conf.d/default.conf
COPY --from=build /usr/src/app/dist /usr/share/nginx/html
CMD ["nginx", "-g", "daemon off;"]