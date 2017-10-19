using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebForms_Favoritos;

namespace WebForms_Favoritos.Tests
{
    [TestClass]
    public class UnitTest_MetodoChorra
    {
        [TestMethod]
        public void TestMetodoChorra_1_Ok()
        {
            Assert.IsFalse(false);
        }
        [TestMethod]
        public void TestMetodoChorra_2_Ok()
        {
            string numero = lista_usuarios_linq.DameNumeroChorra(0);
            Assert.AreEqual(numero, "cero", "No es cero");
            numero = lista_usuarios_linq.DameNumeroChorra(1);
            Assert.AreNotEqual(numero, "cero", "Es cero");
            numero = lista_usuarios_linq.DameNumeroChorra(2);
            Assert.IsFalse(numero != "dos", "Con 2 está mal");
            numero = lista_usuarios_linq.DameNumeroChorra(3);
            Assert.IsTrue(numero == "tres");
            Assert.IsInstanceOfType(numero, typeof(string), "No es string");

            // Con 4 ó más o negativo tiene que devolver null           
            numero = lista_usuarios_linq.DameNumeroChorra(4);
            Assert.IsNull(numero, "Con más de 3 está mal, no es nulo");
            TestMetodoChorra_2_Fail();
        }
        //[TestMethod]
        public void TestMetodoChorra_2_Fail()
        {
            //string numero = lista_usuarios_linq.DameNumeroChorra(0);
            // Assert.AreEqual(numero, "ceroX", "No es cero");
            //string numero = lista_usuarios_linq.DameNumeroChorra(6);
            if (lista_usuarios_linq.DameNumeroChorra(4) == "cuatro")
                Assert.Fail("Cabrón, Hiho puta!");
        }
    }
}
