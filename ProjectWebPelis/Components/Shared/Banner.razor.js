// JavaScript for Banner component
const banners = [
    "https://wallpapercave.com/wp/wp4686158.jpg",
    "https://cdn.wallpapersafari.com/47/21/P6cKJe.jpg",
    "https://preview.redd.it/the-odyssey-wallpaper-4k-desktop-v0-uvbccs5f3c2h1.jpeg?width=3840&format=pjpg&auto=webp&s=6a90615d661a05ae5cc888a8d1b0f85c8260f018"
];

let indice = 0;

function cambiarBanner() {

    const banner = document.querySelector(".base-banner");

    indice++;

    if (indice >= banners.length) {
        indice = 0;
    }

    banner.style.backgroundImage = `linear-gradient( to top, rgba(0, 0, 0, 0.75) 0%, transparent 35%, transparent 65%, rgba(0, 0, 0, 0.95) 100% ),url("${banners[indice]}")`;
}

setInterval(cambiarBanner, 5000);
