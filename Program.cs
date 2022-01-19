var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/create-message", KafkaProducer.CreateMessage);
app.MapGet("/get-message", KafkaConsumer.GetMessage);

app.Run();