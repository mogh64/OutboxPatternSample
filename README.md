# OutboxPatternSample
It is a sample implementation of Transactional Outbox Pattern
.Net Core,MassTransit,RabbitMQ,ElasticSearch,MSSQL Server is used in this sample project.
## Common library:
for common types,setting and Integration Events
## Infrastructure.Elastic library:
classess required for abstracting usage of Nest for communicating with elastic-search database 
## Core component:
it is the command emitter component that initiate a use case
## WorkerService component:
it has responsibility to periodically check outbox table ,read events and place them into the message broker(rabbitMQ) using MassTransit
## Consumer component:
it listiens to the queue and consume messages,after that,it stores documents build from the recieved events into the elastic-search as a search engine database
## Search component:
it provies API's for searching capabilities from search engine
