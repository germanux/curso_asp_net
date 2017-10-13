let nombre = window.localStorage.getItem("nombre");
let nombreDOM = document.getElementById("nombre");

if (nombre !== null || nombre !== "" ) {
    nombreDOM.value = nombre;
}
document.getElementById("enviar").onclick = function () {
    window.localStorage.setItem("nombre", nombreDOM.value);
}; 