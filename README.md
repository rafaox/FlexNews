<div align="center" style="margin-top: 50px">
  <h1 style="margin-top: 20px;">FlexNews API</h1>
</div>

# Descrição
  Api simples criada em NET 6 para criação, atualizações, consutas e deleções de notícias (POST, PUT, GET and DELETE).

# Banco de dados:
  MongoDB

# Docker:
  Dockerfile e docker compose para auxílio na execução local da API.

- **FlexNews.DataAccessLayer:** 
  Camada de acesso a dados, com a configuração do contexto de banco e modelos.

- **FlexNews.Services:** 
  Camada de serviço, com repositórios, view models e classes bases.

- **FlexNews.Api:** 
  Camada de serviço, com repositórios, view models e classes bases.