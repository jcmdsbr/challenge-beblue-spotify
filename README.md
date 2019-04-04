# O "Spotify Commerce" é um projeto criado com a proposta de solucionar um desafio técnico:
* Desenvolver um serviço de back-end (API'S REST) que será responsável por efetuar vendas de discos de
vinil e calcular o valor de cashback para o cliente.

## Você vai precisar das seguites ferramentas:

* Visual Studio Code / Visual Studio 2017 +
* Docker (Containers linux)
* .Net Core 2.1 +
* Conta de acesso ao serviço Spotify (Paga ou Gratuita)

## Passo a passo da configuração:

* Clone o projeto através do comando "git clone https://github.com/jcmds/s-commerce.git"
* Navegue até a pasta ~/src e execute o comando "docker-compose up -d" para subir os container do sql server e redis
* Navegue até a pasta ~/src/SC.Api e execute o comando "dotnet ef database update" para criar as tabelas.
* Acesse o site [Developer Spotify](https://developer.spotify.com/console/get-search-item/) clique em GET TOKEN/REQUEST TOKEN, informe seu usuario e senha.
* Acesse o arquivo de configuração (appsettings.json) localizado em "~/src/SC.Api" e altere a propriedade "SpotifyToken" pelo fornecido no passo anterior.

* ### Agora a aplicação está devidamente configurada, basta executa-la através de sua IDE de preferência.

## Casos de Uso:

* [GET] - GetPlaylist => Obtém os dados de uma playlist (Disco) através do seu identificador.
* [GET] - GetPlaylists => Consulta paginada de playlists (Discos).
* [GET] - GetSale => Obtém os dados de uma venda atavés do seu identificador.
* [GET] - GetSales => Consulta paginada das vendas.
* [POST] - Register => Cadastra uma venda.

## Obs:
* ### Todas as funcionalidades podem ser acessadas via Swagger através do link:
  ### https://localhost:{port}/swagger/index.html
