$(document).ready(() => {
    $("a[href='usuarios.html']").click((ev) => {
        ev.preventDefault();
        $("section").load("usuarios.html");
    });
    $("aside").click(() => {
        $("aside").hide();
    });
    $("a").click( (infoEvento) => {
        //infoEvento.preventDefault();
        console.log("Se ha pulsado algo");
    });

    $("ul li").addClass("fondo-rojo");
    setTimeout(() => {
        $("ul li").removeClass("fondo-rojo");
    }, 2000);
});