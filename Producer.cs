using System;
using Confluent.Kafka;

internal class Producer
{

    private readonly string NameTopic = ConfigConstants.CONFIG_TOPIC_NAME;
    private readonly string PortOfKafka = ConfigConstants.CONFIG_PORT_KAFKA;

    public void CreateProducer()
    {

        Console.WriteLine("Strating PRODUCER...");

        var config = getConfigConsumerKafka();
        using (var producer = new ProducerBuilder<Null, string>(config).Build())
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    var currentMsg = new Message<Null, string> { Value = $"This message is {i}." };
                    producer.Produce(NameTopic, currentMsg, deliveryReport =>
                    {
                        Console.WriteLine($"{i}) Producer message '{currentMsg}' to -> {deliveryReport.TopicPartitionOffset}...");
                        Console.WriteLine(deliveryReport.Message.Value);
                    });

                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Error -> {e.Error.Reason}...");
                }
            }
        }

    }

    private ConsumerConfig getConfigConsumerKafka()
    {
        return new ConsumerConfig
        {
            BootstrapServers = PortOfKafka,
        };
    }

}

