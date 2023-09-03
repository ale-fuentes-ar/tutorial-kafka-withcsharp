using System;
using Confluent.Kafka;

internal class Program
{
    static void Main(string[] args)
    {

        var producer = new Producer();
        producer.CreateProducer();

        var consumer = new Consumer();
        consumer.createConsumer();

    }

}


