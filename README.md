# RabbitMQ Sender

Este projeto é uma implementação de envio de mensagens utilizando RabbitMQ em C# com .NET. O objetivo é permitir a integração de sistemas e o envio eficiente de mensagens assíncronas entre aplicações distribuídas.

## Funcionalidades

- **Envio de mensagens para RabbitMQ**: O projeto permite enviar mensagens para uma fila do RabbitMQ.
- **Configuração flexível**: Através de arquivos de configuração (`appsettings.json`), é possível configurar diferentes aspectos da conexão e envio de mensagens.
- **Desempenho otimizado**: Utiliza técnicas assíncronas para garantir que o envio de mensagens seja eficiente e não bloqueie o fluxo da aplicação.

## Estrutura do Projeto

- **Sender**: Contém a lógica principal para envio das mensagens.
- **Controllers**: Controladores que gerenciam a interação entre a aplicação e as filas do RabbitMQ.
- **Models**: Modelos de dados utilizados para enviar e receber mensagens.
- **Services**: Serviços para gerenciar a comunicação com RabbitMQ.
- **appsettings.json**: Arquivo de configuração das variáveis de ambiente necessárias para a execução do projeto.
- **Program.cs**: Ponto de entrada principal da aplicação.
- **Sender.csproj**: Arquivo do projeto C# que define as dependências e configurações do projeto.
- **Sender.sln**: Arquivo de solução do projeto.

## Instalação

1. Clone este repositório:

    ```bash
    git clone https://github.com/seu-usuario/rabbitmq-sender.git
    ```

2. Abra o projeto no Visual Studio ou outra IDE compatível com C#.

3. Restaure as dependências do projeto:

    ```bash
    dotnet restore
    ```

4. Configure as variáveis de ambiente no arquivo `appsettings.json` com as credenciais do RabbitMQ.

## Uso

Após a instalação e configuração, você pode usar o sender da seguinte maneira:

1. Compile e inicie o serviço de envio de mensagens:

    ```bash
    dotnet run
    ```

2. As mensagens serão enviadas para a fila configurada no RabbitMQ, conforme as configurações no arquivo `appsettings.json`.

## Contribuindo

Se você deseja contribuir para o projeto, sinta-se à vontade para enviar um pull request. Certifique-se de que seu código esteja bem testado e de que o projeto continue funcional após as modificações.

## Licença

Este projeto está licenciado sob a [Licença MIT](LICENSE).
