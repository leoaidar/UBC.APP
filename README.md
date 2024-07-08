# UBC.APP
Estudantes APP


BACK-END C# .NET 6


Abrir no terminal PowerShell ou Bash and digitar: 


cd "back/UBC.Students" 

dotnet restore "./UBC.Students.API/UBC.Students.API.csproj"

dotnet build "./UBC.Students.API/UBC.Students.API.csproj"

cd "./UBC.Students.API"

dotnet run


listening on: https://localhost:7219


Documentação SWAGGER: https://localhost:7219/swagger/index.html 


FRONT-END REACT APP

Abrir no terminal PowerShell out Bash e digitar: 

cd "front/students-app" 

npm install 

npm start 


listening on: http://localhost:3000/


Usuario já fixado no login:

usuario: David

senha: 2013-07-18



BACK-END TEST


cd "back\UBC.Students" 

dotnet restore "./UBC.Students.API/UBC.Students.API.csproj"

dotnet build "./UBC.Students.API/UBC.Students.API.csproj"

cd "./UBC.Students.Tests"

dotnet test







FRONT-END REACT ESTRUTURA PROJETO:

Utilizados:
REACT 18.2.0"
TYPESCRIPT: 4.9.5
Bootstrap
ContextAPI
Toastify
Axios
etc...




src:


-components:


Contém componentes reutilizáveis da interface do usuário.

Login.tsx: Componente para autenticação de usuários.

StudentForm.tsx: Formulário para adicionar ou editar estudantes.

StudentList.tsx: Lista todos os estudantes e permite ações como deletar ou editar.


-context:


Provê contextos para gerenciar estados globais.

AuthContext.tsx: Gerencia o estado de autenticação do usuário.

StudentContext.tsx: Gerencia o estado relacionado aos estudantes.


-hooks:


Contém hooks personalizados para operações específicas.

useStudentManagement.tsx: Hook para gerenciar ações como adicionar ou remover estudantes.


-lib:


Bibliotecas ou utilitários auxiliares.

utils.ts: Funções utilitárias genéricas.


-pages:


Componentes que atuam como "páginas" na aplicação.

Home.tsx: Página inicial do aplicativo.


-routes:


Componentes relacionados ao roteamento dentro da aplicação.

PrivateRoute.tsx: Componente que envolve rotas que exigem autenticação.


-services:


Funções para interagir com APIs externas ou lógicas de serviço.

studentsService.ts: Funções para fazer requisições relacionadas a estudantes.


-types:


Definições de tipos e interfaces usadas em todo o aplicativo.

Students.ts: Tipos relacionados a dados de estudantes.


-utils:


Funções úteis e utilitários para uso em toda a aplicação.

axiosClient.ts: Configuração do cliente Axios para chamadas HTTP.










BACK-END ESTRUTURA PROJETO:


Backend em C# .NET 6 utilizando a abordagem de CQRS (Command Query Responsibility Segregation).


UBC.Students.API:


Controllers: Contém os controladores que gerenciam as requisições HTTP, atuando como ponto de entrada para as operações do CQRS.

Seed: Arquivos para alimentar a base de dados com dados iniciais.


UBC.Students.Application:


Interfaces: Definições de interfaces para abstração de serviços.

Mappers: Mapeadores para transformar entidades de domínio em modelos de visualização ou DTOs.

Services: Implementação dos serviços que executam lógicas de negócio, frequentemente usados pelos Handlers.

ViewModels: Modelos que definem como os dados são apresentados na interface ou consumidores externos.


UBC.Students.Domain:


Commands: Comandos que representam as intenções de modificação de estado.

Entities: Entidades de domínio que representam os conceitos centrais do negócio.

Events: Eventos que são resultado das alterações no domínio utilizados para mensageria.

Handlers: Manipuladores que recebem comandos ou consultas e alteram o estado do domínio ou retornam dados.

Queries: Consultas que são usadas para buscar informações sem alterar o estado.

Repositories: Interfaces para os repositórios que abstraem a interação com a camada de dados.



UBC.Students.Infra.Data:


Cache: Implementações de cache para otimização de consultas como Redis por exemplo.

Contexts: Contextos do Entity Framework para acesso ao banco de dados.

Mappings: Configurações de mapeamento do ORM.

Migrations: Migrações do Entity Framework para evolução do banco de dados.

Repositories: Implementações concretas dos repositórios.

UBC.Students.Infra.IoC:


DependencyContainer.cs: Configurações do container de DI (Dependency Injection) para injeção de dependências.


UBC.Students.Tests:


CommandTests: Testes para os comandos do CQRS.

EntitiesTests: Testes para as entidades de domínio.

HandlerTests: Testes para os handlers que processam os comandos e consultas.

QueryTests: Testes para as queries de leitura.



