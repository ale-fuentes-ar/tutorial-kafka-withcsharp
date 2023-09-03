# build my project
build:
	dotnet build

# execute main
run:
	dotnet run .\Program.cs

# execute kafka
PROJECT_NAME=dc.kafka.yml
kafka:
	docker-compose -f $(PROJECT_NAME) up --build -d