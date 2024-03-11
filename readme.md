cd src/infrastructure
./stop-all.ps1
./start-all.ps1

cd src/EmailSendingService
dapr run --app-id vehicleregistrationservice --app-port 6002 --dapr-http-port 3602 --dapr-grpc-port 60002 --config ../dapr/config/config.yaml --resources-path ../dapr/components dotnet run

cd src/EmailProcessingService
dapr run --app-id finecollectionservice --app-port 6001 --dapr-http-port 3601 --dapr-grpc-port 60001 --config ../dapr/config/config.yaml --resources-path ../dapr/components dotnet run

cd src/EmailFetchingService
dapr run --app-id emailfetchingservice --app-port 6000 --dapr-http-port 3600 --dapr-grpc-port 60000 --config ../dapr/config/config.yaml --resources-path ../dapr/components dotnet run

cd src/OracleSimulation
dotnet run

[text](http://localhost:4000)

RabbitMQ:
http://localhost:15672/
guest
guest
