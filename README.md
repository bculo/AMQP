# AMQP
RabbitMQ and MassTransit demo
  - docker required to run rabbitmq:3.10.1-management-alpine image
  - docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
  - Right click on solution "Amqp" -> Properties -> Choose Multiple startuo projects (API, Dashboard, UI)
  - Start project
  - Execute API endpoint method SubmitOrder in UI project

Azure service bus and MassTransit demo
  - azure account with azure service bus resource (Standard subscription required)
  - change connection string in appsettings.json (API, Dashboard, UI)
  - Right click on solution "Amqp" -> Properties -> Choose Multiple startuo projects (API, Dashboard, UI)
  - Start project
  - Execute API endpoint method SubmitOrder in UI project

![alt text](Assets/Sreenshot_1-png)
