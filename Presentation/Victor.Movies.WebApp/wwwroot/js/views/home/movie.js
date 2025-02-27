document.addEventListener("DOMContentLoaded", async () => {
    BlockElement();

    await Delay(1000);

    fetch("/Movie/ListMovieInformations")
        .then(response => response.json())
        .then(data => {
            const movieCatalogList = document.getElementById("movie-list");

            data.forEach(movie => {
                const movieCatalogItem = `
                    <div class="card movie-card">
                        <img src="data:image/jpeg;base64,${movie.movieImg}" class="card-img-top" alt="Poster do Filme">
                        <div class="card-body">
                            <h5 class="card-title">
                                <span class="movie-title">${movie.movieName}</span>
                            </h5>
                            <p class="card-text">
                                <i class="bi bi-calendar-event"></i> Gênero:
                                <span class="movie-gender">${movie.gender}</span>
                            </p>
                            <p class="card-text">
                                <i class="bi bi-calendar-event"></i> Ano de Lançamento:
                                <span class="movie-year">${movie.movieYear}</span>
                            </p>
                            <p class="card-text">
                                <i class="bi bi-person-video2"></i> Diretor:
                                <span class="movie-director">${movie.nome}</span>
                            </p>
                            <button class="btn-more-info" onclick="MoreInformation(${movie.movieId});">Mais Informações</button>
                        </div>
                    </div>
                `;
                movieCatalogList.innerHTML += movieCatalogItem;
            });

            UnblockElement();
        })
        .catch(error => {
            console.error("Erro ao requisitar dados", error);
            UnblockElement(); 
        });
});