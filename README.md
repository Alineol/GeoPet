Estrutura do projeto:
- GeoPetWebApi
  - Controllers
  - Services
  - DB   
- Test
  - Unit 

Para rodar a aplicação: 

1- Entre na pasta src/GeoPetWebApi e rode o comando 'docker-compose up -d' para levantar o banco de dados;

2- Em seguida dê o comando 'dotnet run', se estiver usando o vscode, ou rode a aplicação pelo visualStudio.

3 - No log da aplicação aparecerá as rotas que estarão disponíveis, clique na que começa com https e será direcionado ao navegador adiciona /swagger/index.html para ser direcionado para o swagger do projeto e testá-lo.



<!--- Fontes de pesquisa:

https://stackoverflow.com/questions/60444977/how-to-get-identity-user-from-his-authentication-jwt-token-in-net-core-api

https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet/blob/dev/src/System.IdentityModel.Tokens.Jwt/ClaimTypeMapping.cs#L54 -->
