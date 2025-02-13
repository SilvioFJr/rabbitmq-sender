# RabbitMQ Sender

Este projeto é uma implementação de envio de mensagens utilizando RabbitMQ em C# com .NET. O objetivo é permitir a integração de sistemas e o envio eficiente de mensagens assíncronas entre aplicações distribuídas.

## Funcionalidades

- **Envio de mensagens para RabbitMQ**: O projeto permite enviar mensagens para uma fila do RabbitMQ.
- **Configuração flexível**: As configurações do RabbitMQ são definidas no arquivo `.env`, permitindo fácil personalização.
- **Desempenho otimizado**: Utiliza técnicas assíncronas para garantir que o envio de mensagens seja eficiente e não bloqueie o fluxo da aplicação.

## Estrutura do Projeto

- **Sender**: Contém a lógica principal para envio das mensagens.
- **Controllers**: Controladores que gerenciam a interação entre a aplicação e as filas do RabbitMQ.
- **Models**: Modelos de dados utilizados para enviar e receber mensagens.
- **Services**: Serviços para gerenciar a comunicação com RabbitMQ.
- **.env**: Arquivo onde você deve definir as variáveis de configuração, como as credenciais do RabbitMQ.
- **Program.cs**: Ponto de entrada principal da aplicação.
- **Sender.csproj**: Arquivo do projeto C# que define as dependências e configurações do projeto.
- **Sender.sln**: Arquivo de solução do projeto.

## Instalação

1.  Clone este repositório:

    ```bash
    git clone https://github.com/seu-usuario/rabbitmq-sender.git
    ```

2.  Abra o projeto no Visual Studio ou outra IDE compatível com C#.

3.  Restaure as dependências do projeto:

    ```bash
    dotnet restore
    ```

4.  Crie um arquivo `.env` na raiz do projeto e defina as seguintes variáveis de ambiente:

    ```
    ASPNETCORE_ENVIRONMENT=Development
    HTTP_PORT=5000
    HTTPS_PORT=5001

    RABBITMQ_HOST=seu_host_rabbitmq
    RABBITMQ_USER=seu_usuario
    RABBITMQ_PASSWORD=sua_senha
    RABBITMQ_QUEUE=sua_fila
    ```

        Nota: As variáveis acima são um exemplo, adicione ou modifique conforme necessário para o seu caso de uso.

## Testando os Endpoints

Aqui estão dois exemplos de como testar os endpoints da API usando `curl`:

### 1. Emissão de Ordem (`/api/sender/emit-order`)

Este endpoint permite emitir uma ordem para ser processada. Ele espera um corpo JSON com as informações do produto.

```bash
curl -X POST "http://localhost:5000/api/sender/emit-order" \
-H "Content-Type: application/json" \
-d '{
    "name": "Produto Exemplo",
    "value": 100.00,
    "quantity": 2
}'
```
### 2. Enviar mensagem de primeiro contato de pacientes para WhatsApp via plataforma Inflobip (`/api/sender/send-first-contact-message`)

Este endpoint envia uma mensagem para o WhatsApp usando um template. Ele espera um corpo JSON com as informações do template, como o número de telefone, idioma e dados do template.

```bash
curl --location 'http://localhost:5000/api/sender/send-first-contact-message' \
--header 'Content-Type: application/json' \
--data '{
    "phoneNumberTo": "5531999999999",
    "language": "pt_BR",
    "templateName": "first_contact_with_patients",
    "templateData": {
        "body": {
            "additionalProp1": "Organização",
            "additionalProp2": "Especialidade",
            "additionalProp3": "Nome",
            "additionalProp4": "Nome"
        },
        "buttons": {
            "Button1": {
                "type": "QUICK_REPLY",
                "parameter": "AGENDAR"
            },
            "Button2": {
                "type": "QUICK_REPLY",
                "parameter": "NÃO SOU EU"
            }
        },
        "header": {
            "type": "TEXT",
            "placeholder": "Organização Header"
        }
    }
}'
```
