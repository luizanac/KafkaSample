namespace KafkaSample;

public static class KafkaConsumer
{
	public static async IAsyncEnumerable<string> GetMessage()
	{
		var config = new ConsumerConfig
		{
				BootstrapServers = "kafka1:19091",
				ClientId = "localhost",
				GroupId = "localhost"
		};
		using var consumer = new ConsumerBuilder<Null, string>(config).Build();
		consumer.Subscribe("kafka-sample-topic");

		while (true)
		{
			var message = consumer.Consume();
			yield return message.Message.Value;
			await Task.Delay(100);
		}
	}
}