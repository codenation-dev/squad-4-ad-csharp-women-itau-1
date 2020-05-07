<h1><b>API central de erros</b></h1>

<h1>### Conteúdos</h1>

  <a href="#descricao"> * [Descrição do Projeto] </a>
  <a href="#funcionalidades"> * [Funcionalidades] </a>
  <a href="#plataforma"> * [O que a plataforma é capaz de fazer] </a>
  <a href="#staus"> * [Status do Projeto] </a>
  <a href="#demo"> * [Demonstração] </a>
  <a href="#rodar"> * [Como rodar a aplicação] </a>
  <a href="#dados"> * [Dados] </a>
  <a href="#devs"> * [Desenvolvedoras] </a>
  <a href="#problemas"> * [Resolução de Problemas] </a>


<h1 id="#descricao>## Descrição do Projeto</h1>

<p align="justify"> Projeto final desenvolvido pelo squad 4 do curso de aceleração em c# promovido pela Codenation.
Neste projeto vamos implementar uma web API para centralizar registros de erros de aplicações. </p>

<h1 id="funcionalidades">### Funcionalidades</h1>
<ul>
<li>- Cadastro de Usuário</li>
<li>- Autenticação de Usuário</li>
</ul>

<h1 id="plataforma"> O que a plataforma é capaz de fazer </h1>

:pushpin: Cadastrar Usuário
:pushpin: Autenticar Usuário
:pushpin: Buscar Usuário Por Id
:pushpin: Buscar Usuário Por Descrição
:pushpin: Buscar Usuário Por Ambiente
:pushpin: Buscar Usuário Por Origem
:pushpin: Arquivar Usuário
:pushpin: Desarquivar Usuário

<h1 id="status">Status do Projeto</h1>

<!-- > Status do Projeto: Concluido :heavy_check_mark:

> Status do Projeto: Em desenvolvimento :warning

<h1>Deploy da aplicação?</h1>

http://squad4.database.windows.net/

<h1 id="demo">Demonstração</h1>

<img src="">

<h1 id="rodar">Como rodar a aplicação</h1>

git clone https://github.com/codenation-dev/squad-4-ad-csharp-women-itau-1

Entre na pasta do Projeto:

cd ProjetoPraticoCodenation

Atualize as migrations

dotnet ef database update

Execute a aplicação:

ProjetoPraticoCodenation.sln

Agora é possível acessar a aplicação a partir da rota https://localhost

<h1>Dependências e tecnologias</h1>

## Linguagens e libs utilizadas :books:

- [React PDF](https://react-pdf.org/): versão xx.xxx

<h1 id="dados">Dados</h1>

### LogErro:

|ID     | Título | Descrição | Data Criação | Evento | Nível  | Ambiente | Arquivado | Usuario Origem |
| ----- | ------ | --------- |------------- | ------ | ------ | -------- | --------- | -------------- |
| int   | string | string    | datecreate   | string | string | string   | bool      | string         |

### Token

| Nome Usuário | Senha  |
|    string    | string |

<h1> Como rodar os testes </h1>

/*Para projetos com React*/
$ npm test

/*Para projetos com Rails*/
$ rspec

<h1 id="devs"> DESENVOLVEDORAS </h1> :octocat:

[<img src="https://avatars1.githubusercontent.com/u/13949186?s=400&u=586688557ec1ed4362aeb05b822be6b196826314&v=4" width="100">
<sub Elis Dayane>
]<br>

[<img src="https://avatars3.githubusercontent.com/u/10854438?s=400&v=4" width="100">
<sub Agatha Nigro><br>
<img src="https://avatars1.githubusercontent.com/u/13949186?s=400&u=586688557ec1ed4362aeb05b822be6b196826314&v=4" width="100">
<sub Elis Dayane><br>
<img src="https://avatars1.githubusercontent.com/u/60662105?s=400&u=da0dc0c1216598d95e2fec9b364158368b443a6f&v=4" width="100">
<sub Sheyla Barrientos><br>
<img src="https://avatars1.githubusercontent.com/u/59710587?s=400&u=d9697e180687f2b9d1830c88522977dc29532f16&v=4" width="100">
<sub Raquel Prates><br>
]<br>


<h1 id="problemas">### Resolvendo problemas</h1>

Veja alguns problemas que surgiram no desenvolvimento deste projeto e como os resolvemos em

 [issues](https://github.com/codenation-dev/squad-4-ad-csharp-women-itau-1/issues)
 
 

<!-- A sua aplicação pode ter algum tipo de licença, que da direitos e restrições ao que as pessoas podem fazer com ele é muito importante que você deixe isso claro. -->

<!-- A licença mais utilizada é a MIT, que permite que qualquer pessoa possa usar, modificar e distribuir o seu projeto, mas te resguarda sob qualquer responsabilidade -->


