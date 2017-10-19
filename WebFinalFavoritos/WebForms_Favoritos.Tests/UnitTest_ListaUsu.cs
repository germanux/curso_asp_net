using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebForms_Favoritos;

namespace WebForms_Favoritos.Tests
{
    [TestClass]
    public class UnitTest_ListaUsu
    {
        [TestMethod]
        public void TestMethod_GestionUsuarios_1()
        {
            GestionUsuarios gestionUsuarios = new GestionUsuarios();
            var lista = gestionUsuarios.ListaUsuarios("");
            Assert.IsNotNull(lista,
                "Lista Nula");
            Assert.IsInstanceOfType(lista, typeof(List<Usuario>),
                "No es una lista");
            Assert.AreNotEqual(lista.Count, 0,
                "Lista instaciada pero vacía");
        }
        [TestMethod]
        public void TestMethod_GestionUsuarios_2()
        {
            GestionUsuarios gestionUsuarios = new GestionUsuarios();
            var lista = gestionUsuarios.ListaUsuarios("E");
            Usuario usu = lista[0];
            Assert.IsTrue(usu.Nombre.ToUpper().Contains("E"),
                "No hay un nombre con E");
        }
    }
}
