using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrainDumpApi_2.Migrations
{
    /// <inheritdoc />
    public partial class PopulaNotas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Notas(Titulo, Conteudo, CategoriaId) VALUES('SL', 'Estudar Service Layer', 2)");
            mb.Sql("INSERT INTO Notas(Titulo, Conteudo, CategoriaId) VALUES('RoadMap', '📁 Backend\r\n∟👨‍💻 C# / ASP.NET Core\r\n∟👨‍💻 EntityFrameworkCore / Postgres / MSSQL\r\n∟👨‍💻 Design Patterns\r\n∟👨‍💻 Memory Caching\r\n∟👨‍💻 Localization\r\n∟👨‍💻 RESTful APIs\r\n∟👨‍💻 gRPC\r\n∟👨‍💻 Clean / Onion Architecture\r\n∟👨‍💻 CQRS (Command Query Responsibility Segregation)\r\n∟👨‍💻 Modular Monolith\r\n∟👨‍💻 Microservices Architecture\r\n∟👨‍💻 DDD (Domain-Driven Design)\r\n∟👨‍💻 Event-Driven Architecture\r\n\r\n📁 Frontend\r\n∟‍👨‍💻 HTML + CSS + Tailwind\r\n∟👨‍💻 Blazor\r\n∟👨‍💻 Javascript / Typescript\r\n\r\n📁 Version Control\r\n∟👨‍💻 Git / GitHub\r\n\r\n📁 Web Sockets\r\n∟‍👨‍💻 SignalR\r\n\r\n📁 Message Queue\r\n∟‍👨‍💻 RabbitMQ\r\n∟‍👨‍💻 Azure Service Bus\r\n∟‍👨‍💻 Amazon SQS\r\n∟👨‍💻 Kafka (Not exactly a message queue, but anyways)\r\n\r\n📁 Cloud & DevOps\r\n∟👨‍💻 Docker / Kubernetes\r\n∟👨‍💻 Azure DevOps / GitHub Actions\r\n∟👨‍💻 Azure / AWS\r\n∟👨‍💻 Terraform / Infrastructure as Code (IaC)\r\n∟👨‍💻 Serverless Computing (Azure Functions, AWS Lambda)\r\n∟👨‍💻 Continuous Integration / Continuous Deployment (CI/CD)\r\n\r\n📁 Testing (XUnit / NUnit)\r\n∟👨‍💻 Unit Testing\r\n∟👨‍💻 Integration Testing\r\n∟👨‍💻 Performance Testing\r\n∟👨‍💻 End-to-End Testing (Selenium, Cypress)\r\n∟👨‍💻 Test-Driven Development (TDD)\r\n\r\n📁 Security\r\n∟👨‍💻 Authentication / Authorization (OAuth, JWT)\r\n∟👨‍💻 Data Protection\r\n∟👨‍💻 Secure Coding Practices\r\n∟👨‍💻 Application Security (OWASP)\r\n∟👨‍💻 Azure AD / B2C\r\n∟👨‍💻 AWS Cognito\r\n\r\n📁 Monitoring & Logging\r\n∟👨‍💻 Serilog / NLog\r\n∟👨‍💻 ELK Stack (Elasticsearch, Logstash, Kibana)\r\n∟👨‍💻 Prometheus / Grafana\r\n∟👨‍💻 OpenTelemetry\r\n∟👨‍💻 Azure Monitor\r\n\r\n📁 Collaboration & Communication\r\n∟👨‍💻 Agile / Scrum Methodologies\r\n∟👨‍💻 Jira / Azure Boards\r\n∟👨‍💻 Trello\r\n\r\n📁 Other Essential Skills\r\n∟👨‍💻 Code Reviews / Pair Programming\r\n∟👨‍💻 Software Architecture Principles\r\n∟👨‍💻 Performance Optimization\r\n∟👨‍💻 Cost Optimization in Cloud', 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Notas");
        }
    }
}
