<h3><b>API - Central de Erros</b></h3>

<!---->
<h4>Conteúdo</h4>
<ul>
	<li><a href="#descricao">Descrição</a><br></li>
	<li><a href="#plataforma">Funcionalidades</a><br></li>
	<li><a href="#rodar">Como rodar a aplicação </a><br></li>
	<li><a href="#devs">Desenvolvedoras </a><br></li>
</ul>


<!---->
<h3 id="#descricao">Descrição</h3>
<p> Projeto final desenvolvido pelo squad 4 do curso de aceleração em c# promovido pela Codenation.
Neste projeto vamos implementar uma web API para centralizar registros de erros de aplicações. </p>
<h4>Status do Projeto</h4>
<p>Status do Projeto: Concluído</p>


<!---->
<h3 id="plataforma">Funcionalidades</h3>
<ul style="list-style: none;">  
	<li><img src="https://raw.githubusercontent.com/codenation-dev/squad-4-ad-csharp-women-itau-1/master/img/CadastrarUsuario.png"></li>
		<ul style="list-style: none;"> 
			<li>Inclui um novo usuario</li>
		</ul>    
    <li><img src="https://raw.githubusercontent.com/codenation-dev/squad-4-ad-csharp-women-itau-1/master/img/LinkEsqueciMinhaSenhaUsuario.png"></li>
		<ul style="list-style: none;">
			<li>Gera um codigo para o usuario alterar a senha</li>	
		</ul>			
    <li><img src="https://raw.githubusercontent.com/codenation-dev/squad-4-ad-csharp-women-itau-1/master/img/ResetSenhaUsuario.png"></li>
		<ul style="list-style: none;">
			<li>Permite a alteração da senha do usuario</li>	
		</ul>	
	<li><img src="https://raw.githubusercontent.com/codenation-dev/squad-4-ad-csharp-women-itau-1/master/img/LoginUsuario.png"></li>
		<ul style="list-style: none;"> 
			<li>Retorna um token para autenticação do usuário nos próximos métodos.</li>
		</ul>
	<li><img src="https://raw.githubusercontent.com/codenation-dev/squad-4-ad-csharp-women-itau-1/master/img/IncluirLogErro.png"></li>
		<ul style="list-style: none;">
			<li>Inclui uma lista de logs.</li>	
		</ul>
	<li><img src="https://raw.githubusercontent.com/codenation-dev/squad-4-ad-csharp-women-itau-1/master/img/RemoverLogErro.png"></li>
		<ul style="list-style: none;">
			<li>Exclui uma lista de logs</li>		
		</ul>
	<li><img src="https://raw.githubusercontent.com/codenation-dev/squad-4-ad-csharp-women-itau-1/master/img/ArquivarLogErro.png"></li>
		<ul style="list-style: none;">
			<li>Arquiva uma lista de logs</li>	
		</ul>
	<li><img src="https://raw.githubusercontent.com/codenation-dev/squad-4-ad-csharp-women-itau-1/master/img/DesarquivarLogErro.png"></li>
		<ul style="list-style: none;">
			<li>Desarquiva uma lista de logs</li>	
		</ul>		
	<li><img src="https://raw.githubusercontent.com/codenation-dev/squad-4-ad-csharp-women-itau-1/master/img/LocalizarPorIdLogErro.png"></li>
		<ul style="list-style: none;">
			<li>Retorna os dados de um log a partir do id.</li>	
		</ul>
	<li><img src="https://raw.githubusercontent.com/codenation-dev/squad-4-ad-csharp-women-itau-1/master/img/BuscarPorAmbienteLogErro.png"></li>
		<ul style="list-style: none;">
			<li>Retorna logs a partir do ambiente.</li>		
		</ul>
	<li><img src="https://raw.githubusercontent.com/codenation-dev/squad-4-ad-csharp-women-itau-1/master/img/BuscarPorDescricaoeAmbienteLogErro.png"></li>
		<ul style="list-style: none;">
			<li>Retorna logs a partir do ambiente e descrição.</li>		
		</ul>
	<li><img src="https://raw.githubusercontent.com/codenation-dev/squad-4-ad-csharp-women-itau-1/master/img/BuscarPorOrigemeAmbienteLogErro.png"></li>
		<ul style="list-style: none;">
			<li>Retorna logs a partir do ambiente e origem.</li>	
		</ul>
	<li><img src="https://raw.githubusercontent.com/codenation-dev/squad-4-ad-csharp-women-itau-1/master/img/BuscarNiveleAmbienteLogErro.png"></li>
		<ul style="list-style: none;">
			<li>Retorna logs a partir do ambiente e nivel.</li>	
		</ul>
	<li><img src="https://raw.githubusercontent.com/codenation-dev/squad-4-ad-csharp-women-itau-1/master/img/ArquivadoLogErro.png"></li>
		<ul style="list-style: none;">
			<li>Retorna logs arquivados.</li>		
		</ul>	
</ul>
<h4>Deploy da aplicação</h4>
<p>https://aceleradevsquad4.azurewebsites.net/swagger/index.html</p>

<!---->
<h4>Modelo - Log</h4>
:octocat: <img src="https://raw.githubusercontent.com/codenation-dev/squad-4-ad-csharp-women-itau-1/master/img/LogErroDTO.png" width="300">


<!---->
<h3 id="rodar">Como rodar a aplicação</h3>
<p>Utilizando a Prompt de comando:</p>
<ul style="list-style: none;">	
	<li>Clonar o projeto</li>
		<ul style="list-style: none;">
			<li>	git clone https://github.com/codenation-dev/squad-4-ad-csharp-women-itau-1</li>	
		</ul>
	<li>Acessar a pasta do Projeto</li>
		<ul style="list-style: none;">	
			<li>	cd [pasta onde a solução foi clonada]\ProjetoPraticoCodenation </li>
		</ul>	
	<li>Executar a aplicação</li>
		<ul style="list-style: none;">
			<li>	dotnet run --project ProjetoPraticoCodenation.csproj</li>
		</ul>
	<p>Agora é possível acessar a aplicação a partir da rota https://localhost:5001/swagger/index.html</p>
	<p>Para mudar o endereço do banco de dados, altere o parametro DefaultConnection no arquivo appsettings.json.</p>
</ul>	

<!---->
<h4>Pacotes</h4>
<img src="https://raw.githubusercontent.com/codenation-dev/squad-4-ad-csharp-women-itau-1/master/img/Pacotes.png" width="400">

<h3>Apresentação</h3>
:computer: <a href="https://docs.google.com/presentation/d/196sl0QQ-J7FffYJFjQIRnoLY3xdwEmUJCwV14Xtm2kc/edit#slide=id.p">Projeto - Central de Erros Web API</a>

<!---->
<h3 id="devs"> Desenvolvedoras </h3>

<table>
  <tr>
    <th> <a href="https://github.com/agathanigro"><img src="https://avatars1.githubusercontent.com/u/10854438?s=400&u=38b08e6cfe52e7c244c4cfb42c15e7ca322153e4&v=4" width="100"
	alt="Agatha Nigro"></a> </th>
    <th> <a href="https://github.com/elisdayane"> <img src="https://avatars1.githubusercontent.com/u/13949186?s=400&u=586688557ec1ed4362aeb05b822be6b196826314&v=4" width="100"
	alt="Elis Dayane"></a> </th>
	<th> <a href="https://github.com/rpmprates"> <img src="https://avatars1.githubusercontent.com/u/59710587?s=400&u=d9697e180687f2b9d1830c88522977dc29532f16&v=4" width="100"
	alt="Raquel Prates"></a> </th>
	<th> <a href="https://github.com/sheylabarrientos"> <img src="https://avatars1.githubusercontent.com/u/60662105?s=400&u=da0dc0c1216598d95e2fec9b364158368b443a6f&v=4" width="100"
	alt="Sheyla Barrientos"></a> </th>
  </tr>
  <tr>
    <td><h4> Agatha Nigro </h4></td>
    <td><h4> Elis Dayane </h4></td>
	<td><h4> Raquel Prates </h4></td>
	<td><h4> Sheyla Barrientos </h4></td>
  </tr>  
</table>
