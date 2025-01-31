function MoreInformation(movieId) {
    fetch(`/Movie/ListMovieInformationById/${movieId}`)
        .then(response => {
            return response.text();
        })
        .then(data => {
            const movieModalBody = document.getElementById("movieModalBody");
            if (movieModalBody) {
                movieModalBody.innerHTML = data;
                const movieModal = new bootstrap.Modal(document.getElementById('movieModal'));
                movieModal.show();
            } else {
                console.error("Elemento 'movieModalBody' não encontrado");
            }
        })
        .catch(error => {
            console.error("Erro ao requisitar dados", error);
        });
}