const BlockElement = () => {
    var loadingSpinner = document.getElementById("loading-spinner");
    var overlay = document.getElementById("overlay");

    loadingSpinner.style.display = "flex";
    overlay.style.display = "block";
};

const UnblockElement = () => {
    var loadingSpinner = document.getElementById("loading-spinner");
    var overlay = document.getElementById("overlay");

    loadingSpinner.style.display = "none";
    overlay.style.display = "none";
};

const Delay = (ms) => new Promise(resolve => setTimeout(resolve, ms));