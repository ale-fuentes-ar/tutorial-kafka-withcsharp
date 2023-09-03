using System;
using Confluent.Kafka;

internal class Consumer
{

    private readonly string NameTopic = ConfigConstants.CONFIG_TOPIC_NAME;
    private readonly string PortOfKafka = ConfigConstants.CONFIG_PORT_KAFKA;
    private readonly string GroupName = ConfigConstants.CONFIG_GROUP_CONSUMER;

    public void createConsumer()
    {
        Console.WriteLine("Strating CONSUMER...");

        var config = getConfigConsumerKafka();
        using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
        {
            consumer.Subscribe(NameTopic);
            while (true)
            {
                try
                {
                    var consumerResult = consumer.Consume();
                    Console.WriteLine($"Received message: {consumerResult.Message.Value} [ from {consumer.Name} ]");
                }
                catch (ConsumeException e)
                {
                    Console.WriteLine($"ERROR : error when try reader message: {e.Error.Reason}");
                }
            }
        }

    }

    private ConsumerConfig getConfigConsumerKafka()
    {
        return new ConsumerConfig
        {
            BootstrapServers = PortOfKafka,
            GroupId = GroupName,
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
    }
}