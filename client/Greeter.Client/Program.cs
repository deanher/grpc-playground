// See https://aka.ms/new-console-template for more information

using Grpc.Net.Client;
using GrpcGreeterClient;

Console.WriteLine("Hello, World!");

using var channel = GrpcChannel.ForAddress("https://localhost:7108");
var client = new Greeter.GreeterClient(channel);

Console.Write("Type a name and press Enter: ");
var name = Console.ReadLine();
var reply = await client.SayHelloAsync(new HelloRequest { Name = name });

Console.WriteLine($"Greeting: {reply.Message}");

Console.Write("Type a greeting and press Enter: ");
var goodbyeGreeting = Console.ReadLine();
Console.Write("Type a name and press Enter: ");
var goodbyeName = Console.ReadLine();
var goodbyeReply = await client.SayGoobyeAsync(new GoodbyeRequest { Greeting = goodbyeGreeting, Name = goodbyeName });

Console.WriteLine($"Goodbye Greeting: {goodbyeReply.Message}");

Console.WriteLine("Press any key to exit...");

Console.ReadKey();