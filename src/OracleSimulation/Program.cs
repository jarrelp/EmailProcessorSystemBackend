var daprHttpPort = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT") ?? "3600";
var daprGrpcPort = Environment.GetEnvironmentVariable("DAPR_GRPC_PORT") ?? "60000";

// Create a Dapr client with custom HTTP and gRPC endpoints
using var daprClient = new DaprClientBuilder()
    .UseHttpEndpoint($"http://localhost:{daprHttpPort}")
    .UseGrpcEndpoint($"http://localhost:{daprGrpcPort}")
    .Build();

var pubSubService = new PubSubService(daprClient);

var emailDataGenerator = new EmailDataGenerator();

var emailSimulation = new EmailSimulation(pubSubService, emailDataGenerator);


await emailSimulation.Start();

Task.Run(() => Thread.Sleep(Timeout.Infinite)).Wait();