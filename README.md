# BROKER | Example with Kafka and C#

![](https://img.shields.io/badge/by-Alejandro_Fuentes-informational?style=flat-square)
![](https://img.shields.io/badge/Tutorial-CSharp_&_Kafka-informational?style=flat-square&color=CDCDCD)


## Hands-on


### Step 1 | create kafka enviroment
In this step, I make docker compose for up environment's kafka in my computer. I this is this a easy way for testing, because I don't need install all software in my computer.

the file `container\dc.kafka.yml` has docker file with image kafka already for run:

```shell
docker-compose -f .\container\dc.kafka.yml up --build -d 

# for listen running containers
docker ps --format 'table {{.ID}}\t{{.Names}}\t{{.Image}}\t{{.Status}}'
```

```shell
# for connect to terminal kafka
docker exec -it kafka sh

# Run Kafka Commands inside the container
# List Brokers
docker exec -ti kafka /usr/bin/broker-list.sh

# List Topics
docker exec -ti kafka /opt/kafka/bin/kafka-topics.sh --list --zookeeper zookeeper:2181

# Create a Topic
docker exec -ti kafka /opt/kafka/bin/kafka-topics.sh --create --zookeeper zookeeper:2181 --replication-factor 1 --partitions 1 --topic test2

# List Topics
docker exec -ti kafka /opt/kafka/bin/kafka-topics.sh --list --zookeeper zookeeper:2181
```

### Step 2 | create producer
See `Producer.cs` file please.

### Step 3 | create consumer

See `Consumer.cs` file please.

> `AutoOffsetReset.Earliest`: This option indicates that the consumer should start reading messages from the earliest available offset in the topic. In other words, it begins at the beginning of the partition. If you set this option, the consumer will read all messages in the topic, including those that were produced before the consumer group started. This option is useful when you want to process all available data in the topic, such as when you have a new consumer group or when you want to reprocess historical data.

> In Kafka, the `group.id` setting is typically associated with Kafka consumers (Consumer Groups) rather than producers. It's used to group multiple consumers together to work on consuming messages from one or more Kafka topics in parallel. If you meant to use a producer to send messages to a Kafka topic that is then consumed by a group of consumers, you don't need to specify a `group.id` for the producer. The group.id is only relevant for Kafka consumers.

For finish to execution, we need to break a console (`CTRL + C`). Why? because the consumer does stay listen for new messages.

## Some Tips for beginners

### crate a project with `donet`

> first install `donet` tool in our environment
> see here, [let's go dotnet][link-dotnet]

**create project**

```shell
dotnet new console --framework net6.0
```

**building and executing our project**

```shell
# build my project
dotnet build

# execute main
dotnet run .\Program.cs
```

### Use Makefile for automated actions

A `Makefile` is a simple text file used in software development projects to automate tasks related to building, compiling, and managing the project. It contains a set of rules and dependencies that define how various parts of the project are built and how they depend on each other. Makefiles are most commonly associated with C and C++ projects, but they can be used for a wide range of programming languages and project types.

See `Makefile` please.

**Example how to use `Makefile`**

```shell
# for start container Kafka for our tests.
make kafka

# for compile our project C#.
make build

# execute our project.
make run

```


<!-- links and tools -->
[link-dotnet]:https://dotnet.microsoft.com/en-us/download