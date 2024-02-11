# CS Library Manager

<p align="center">
  <img width="460" height="300" src="/Logo.PNG">
</p>

O CS Library Manager é um sistema de gerenciamento de biblioteca desenvolvido em C#. Este projeto permite que bibliotecários e usuários gerenciem a coleção de livros da biblioteca, bem como o empréstimo e devolução de livros para os clientes.

## Funcionalidades

- Adicionar novos livros à coleção da biblioteca
- Remover livros da coleção
- Emprestar livros para clientes
- Devolver livros à biblioteca
- Procurar livros pelo ISBN
- Exibir a lista de livros disponíveis
- Exibir a lista completa de todos os livros na coleção
- Adicionar novos clientes ao registro
- Procurar clientes pelo ID
- Exibir a lista de livros emprestados por um cliente específico

## Estrutura do Projeto

O projeto é dividido em três classes principais:

### 1. Book

A classe `Book` representa um livro na biblioteca e contém os seguintes atributos:

- `Title`: Título do livro
- `Author`: Autor do livro
- `PublicationYear`: Ano de publicação do livro
- `Isbn`: Número de identificação do livro
- `Availability`: Indica se o livro está disponível para empréstimo

A classe `Book` possui métodos para emprestar e devolver um livro, além de uma representação em forma de string para exibição.

### 2. Client

A classe `Client` representa um cliente da biblioteca e possui os seguintes atributos:

- `Name`: Nome do cliente
- `Id`: ID do cliente
-  `BorrowedBooks`: Lista de livros emprestados pelo cliente

A classe `Client` possui métodos para fazer empréstimos, devolver livros e exibir a lista de livros emprestados.

### 3. Library

A classe `Library` representa a própria biblioteca e contém uma coleção de livros. Possui os seguintes métodos principais:

- AddBook: Adiciona um novo livro à coleção
- RemoveBook: Remove um livro da coleção
- FindByIsbn: Procura um livro pelo ISBN
- ShowCollection: Exibe a lista completa de todos os livros na coleção
- ShowAvailableBooks: Exibe a lista de livros disponíveis para empréstimo

## Utilização

O programa oferece um menu interativo com opções para acessar as funcionalidades mencionadas acima. Os usuários podem navegar pelo menu selecionando as opções desejadas e interagindo com o sistema através do console.

Para executar o programa, basta compilar e executar o arquivo Program.cs.

## Contribuições

Contribuições são bem-vindas! Se você encontrar um problema ou tiver alguma sugestão de melhoria, sinta-se à vontade para abrir uma issue ou enviar um pull request.