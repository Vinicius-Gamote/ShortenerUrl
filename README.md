# Shortener Url

Este é um projeto de estudo que implementa um encurtador de URLs capaz de reduzir links longos de forma eficiente.
O sistema foi desenvolvido utilizando .NET 9.0, seguindo a arquitetura DDD (Domain-Driven Design), aplicando os princípios SOLID e boas práticas de desenvolvimento.

O projeto inclui:

- Dockerfile otimizado para .NET, garantindo imagens leves e rápidas para build e deploy.

- Docker Compose configurado para orquestrar múltiplos serviços containerizados, incluindo API e PostgreSQL, permitindo fácil integração e escalabilidade.

O objetivo é fornecer um exemplo prático de aplicação de boas práticas de desenvolvimento, containerização e arquitetura limpa em projetos .NET modernos.


## Documentação da API

#### Retorna todos os itens

```http
  POST /shorten
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `originalUrl` | `string` | **Obrigatório**. A url a ser encurtada |

#### Encurta a url inserida 

```http
  GET /{shortCode}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `shortCode`      | `string` | **Obrigatório**. Url encurtada a ser redirecionada |

#### Redireciona a url encurtada criada para a url inicial



## Funcionalidades

- Encurtar urls que deseja
- Redirecionar para a url inicial, uma vez encurtada
- Criação de serviços como banco de dados, e api diretamente via docker-compose


## Rodando localmente

Clone o projeto

```bash
  git clone https://github.com/Vinicius-Gamote/ShortenerUrl
```

Entre no diretório do projeto

```bash
  cd ShortenerApi
```

Construa as imagens docker

```bash
  docker-compose build
```

Isso irá subir a API .NET 9.0 e o PostgreSQL em containers isolados, conforme configurado no docker-compose.yml

```bash
  docker-compose up -d
```

Acesse a aplicação

```
API: https://localhost:7000 (ou porta configurada no compose)

Swagger: https://localhost:7000/swagger
```

Para parar os containers
```bash
    docker-compose down
```
