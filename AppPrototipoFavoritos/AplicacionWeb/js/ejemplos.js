if (10 === "10") { alert("Mira tú!"); }

function Usuario(nombre, email, edad) {
    this.nombre = nombre;
    this.email = email;
    this.edad = edad;
    this.metodo = function () {

        alert("Cachondeooo!");
    }
    this.metodo2 = (para) => { alert("Cachondeooo 2!");; }
} if (unaVariable == "undefined") {

}
Usuario.funEstatica = function () {
    alert("Cachondeooo 3!");
}
usuario = new Usuario("Seat", 34);
coche = {
    nombre: "Seat",
    ruedas: 34,
    metodo: function () { return 0; }
}
coche.miOtroMetodo = function () { alert("Cachondeooo 4!"); }
/*
Usuario.funEstatica();
usuario.metodo();
usuario.metodo2();
coche.miOtroMetodo();*/
var nombre = document.getElementById("nombre");

document.getElementById("enviar").onclick = function () {
    //alert("No toques las ruedas " + nombre.value);
    confirm("No preguntes cosas rarar, Adrés");
} 