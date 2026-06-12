# Prompt para geração de testes automatizados

Atue como um desenvolvedor sênior especialista em testes automatizados com C#, xUnit e boas práticas de arquitetura.

Seu objetivo é gerar testes unitários claros, organizados e profissionais para o projeto informado.

## Contexto do Projeto

* Projeto: Cookie.API
* Linguagem: C#
* Framework: ASP.NET Core
* ORM: Entity Framework Core
* Banco: MySQL
* Framework de testes: xUnit
* Mocking: Moq
* Dados fake: Bogus

## Objetivo dos Testes

Os testes devem validar:

* regras de negócio
* comportamento esperado dos serviços
* validações
* exceções
* manipulação correta do banco/repositório
* fluxos de entrada e saída de estoque

## Regras para geração dos testes

* Utilize xUnit
* Utilize Moq para dependências
* Utilize padrão Arrange / Act / Assert
* Utilize nomes de testes descritivos
* Mantenha os testes independentes
* Não utilize código excessivamente complexo
* Foque em legibilidade e manutenção

## Estrutura Esperada

Cada teste deve conter:

1. Arrange

   * criação de mocks
   * criação de entidades fake
   * configuração do cenário

2. Act

   * execução do método testado

3. Assert

   * validação do resultado esperado

## Padrão de Nome dos Testes

Utilize o padrão:

```csharp
Metodo_Cenario_ResultadoEsperado
```

Exemplo:

```csharp
CreateProduct_WhenNameIsValid_ShouldCreateProduct
```

## O que deve ser testado

### Stock

* criação de produto válido
* tentativa de criação inválida
* atualização de produto

## Requisitos adicionais

* Gere código completo
* Inclua using necessários
* Utilize boas práticas de Clean Code
* Evite comentários desnecessários
* Retorne apenas código funcional
* Explique rapidamente a finalidade de cada teste quando necessário
