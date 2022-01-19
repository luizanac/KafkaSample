namespace KafkaSample;

public record User(string Name, uint Age);

public static class KafkaProducer
{
	private static User _user = new User("Luiz", 24);

	public static async Task<IResult> CreateMessage()
	{
		var config = new ProducerConfig
		{
				BootstrapServers = "kafka1:19091",
				ClientId = "localhost",
		};

		using var producer = new ProducerBuilder<Null, string>(config).Build();

		var message = new Message<Null, string> {Value = JsonSerializer.Serialize(_user)};
		var result = await producer.ProduceAsync("kafka-sample-topic", message);

		_user = _user with {Age = _user.Age + 1};
		return Results.Ok(result.Status.ToString());
	}
}