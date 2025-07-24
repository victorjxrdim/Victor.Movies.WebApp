Criando um container docker para ASP.NET MVC.

Criar o Dockerfile

V� at� a solu��o aonde se encontrar� o arquivo, no nosso caso ser� na camada de presentation. 
Bot�o direito > Adicionar > Suporte do Docker. SO de destino: Linux, Tipo de Compila��o do Container: Dockerfile
SO de destino de acordo com a m�quina instalada.
Apagar do Dockerfile a clausula USER, pois pode restringir o acesso do container.

Ir at� o terminal do docker e navegar at� a pasta destino com o comando "cd".

Agora construindo a imagem do container (imagem s�o os recursos necess�rios para execu��o da aplica��o)

Executar o comando: 
docker build -f Presentation/Victor.Movies.WebApp/Dockerfile -t victor-movies-app:v1 .
                    Caminho do Dockerfile                       Nome da imagem e vers�o (":v1", � a tag opcional, mas ajuda a separar diferentes builds e no versionamento)
				
-f (referente ao caminho do Dockerfile seguido da pasta que se encontra, nem sempre necess�rio, mas acredito que o padr�o MVC necessita.)

Ap�s isso executamos a cria��o do container:

              Mapeamento da porta 
docker run -d -p 8080:8080 --name movies-container victor-movies-app:v1