window.onload = function (ev) {

    let nombre = window.localStorage.getItem("nombre");
    let nombreDOM = document.getElementById("nombre");
    nombreDOM.onkeypress = function (ev) {
        console.log(`Se ha pulsado una tecla ${nombre}` );
    }
    // nombreDOM.addEventListener("click", fu)
    nombreDOM.onchange = function (ev) {
        console.log("Se ha cambiado");
    }
    if (nombre !== null || nombre !== "") {
        nombreDOM.value = nombre;
    }
    console.log("Log de lo que sea");
    //console.error("ERROR GARRAFAL!");
    //console.warn("ERROR  NO TAN GARRAFAL!");
    document.getElementById("enviar").onclick = function () {
        window.localStorage.setItem("nombre", nombreDOM.value);
        document.getElementById("listadoUsuarios").innerHTML += "<li>Antonio</li>";
    };
    let string = JSON.stringify({

        nombre: "Germán",
        apellidos: "Caballero"
    });
    console.log(string);
    let objeto = JSON.parse(string);
    console.log(objeto);
    setInterval( function () {
        console.log((new Date).toString());
    }, 10000);
    miFun( "J", "X");
}
function miFun(v1 = "A", v2 = "b", v3 = "C") {
    console.log(`${v1} ${v2} ${v3}`);
}