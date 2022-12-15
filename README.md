<img src="https://user-images.githubusercontent.com/92826153/207748140-d34e0436-bcd2-49e1-8d84-3312acc29cb1.png" width=200px align="right"> 
<br>
<br>
<h1>GeoPetWebApi</h1>
GeoPet é uma API para cadastro de pets e cuidadores. Conectamos pets e cuidadores.






<Details>
<summary><b>Estrutura do projeto:</b></summary>

- GeoPetWebApi
  - Controllers
    - inputs
  - Services
  - DB
    - repository
    - models
  - jwt  
- Test
  - Unit
    - controller
    - service
    - repository 
</Details>

<Details>
<summary><b>Tecnologias utilizadas:</b></summary>

  - FluentAssertion
  - AutoFixture
  - Moq
  - AspNetCore
  - EntityFrameworkCore
  - Xunit
  - QrCoder
</Details>

<Details>
<summary><b>Para rodar a aplicação: </b></summary>

1- Entre na pasta src/GeoPetWebApi e rode o comando '<b>docker-compose up -d</b>' para levantar o banco de dados(é necessário ter  docker instalado);

2- Em seguida dê o comando '<b>dotnet run</b>', se estiver usando o vscode, ou rode a aplicação pelo visualStudio.
</Details>


<Details>
<summary><b>Documentação</b></summary>
A Documentação foi feita pelo swagger, para acessar  rode o projeto localmente e acesse a página: <link>https://localhost:7170/swagger/index.html</link> 
obs: no exemplo acima a aplicação está rodando na porta 7170, você consegue vizualizar essa informação nos logs da aplicação

<b>- Print da documentação:</b>
<img src="https://user-images.githubusercontent.com/92826153/207751859-f3d267b9-c7db-47ac-89e9-495f316092e4.png">

</Details>






<!--- Fontes de pesquisa:

https://stackoverflow.com/questions/60444977/how-to-get-identity-user-from-his-authentication-jwt-token-in-net-core-api

https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet/blob/dev/src/System.IdentityModel.Tokens.Jwt/ClaimTypeMapping.cs#L54 -->
