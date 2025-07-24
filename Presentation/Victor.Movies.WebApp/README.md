Criando um container docker para ASP.NET MVC.

Criar o Dockerfile

Vá até a solução aonde se encontrará o arquivo, no nosso caso será na camada de presentation. 
Botão direito > Adicionar > Suporte do Docker. SO de destino: Linux, Tipo de Compilação do Container: Dockerfile
SO de destino de acordo com a máquina instalada.
Apagar do Dockerfile a clausula USER, pois pode restringir o acesso do container.

Ir até o terminal do docker e navegar até a pasta destino com o comando "cd".

Agora construindo a imagem do container (imagem são os recursos necessários para execução da aplicação)

Executar o comando: 
docker build -f Presentation/Victor.Movies.WebApp/Dockerfile -t victor-movies-app:v1 .
                    Caminho do Dockerfile                       Nome da imagem e versão (":v1", é a tag opcional, mas ajuda a separar diferentes builds e no versionamento)
				
-f (referente ao caminho do Dockerfile seguido da pasta que se encontra, nem sempre necessário, mas acredito que o padrão MVC necessita.)

Após isso executamos a criação do container:

              Mapeamento da porta 
docker run -d -p 8080:8080 --name movies-container victor-movies-app:v1