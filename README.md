# Steam Time
SteamTime é um projeto de padrão [MVC](https://pt.wikipedia.org/wiki/MVC) para portfólio criado por [Erik Bergkamp](https://github.com/eriking50), notar que alguns commits não ficaram registrados na minha conta, mas possuem meu nome. Este projeto tem foco em desenvolvimento BackEnd, tanto que as páginas geradas usam apenas BootStrap para CSS e algumas edições CSS à mão para questões estéticas específicas.

##  Sobre
O projeto tem como base Asp Net 2.0 e utiliza tecnologia de renderização de paginas Razor para geração das Views. O banco de dados escolhido foi o 
[MySQL](https://www.mysql.com) e pode ser alterado no projeto caso desejado.

## Instruções
Para rodar o programa é necessário abrir o projeto no Visual Studio, e rodar as migrations pelo console do NuGet com o comando "Update-Database", caso você queira alterar o banco de dados você pode deve alterar as configurações antes de rodar as migrations (eu sou novato então não sei se essa alteração de BD funciona dessa forma).

É necessário que haja um arquivo "steamAccess.json" com os seguintes campos:
 
    {
    "key": "Chave da Steam API Aqui",
    "id": "Id da Steam"
	}
 
 Onde "Chave da Steam API" é a chave que se consegue pelo site da Steam API e o ID é o ID da Steam que se quer avaliar, AVISO é necessário que o perfil que possui esse ID esteja público.
 Na linha 24 do arquivo Index da View do SteamGame há o seguinte campo:
 
    <img  src="https://i.ibb.co/L9c9Vyn/notfound.png"  alt="@Html.DisplayFor(modelItem => item.Name)">
    
Este campo serve de tratamento caso o jogo não venha com um cover atrelado a ele, essa imagem foi hospedado num site de graça então há a possibilidade de haver erros de não ser encontrada, caso aconteça você pode substituir essa imagem por qualquer imagem hospedada na internet que tenha as seguintes dimensões: 184px x 69px.
 