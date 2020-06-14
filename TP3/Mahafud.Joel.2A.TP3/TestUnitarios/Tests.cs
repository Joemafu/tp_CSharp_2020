using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;
using System.Runtime.Remoting.Metadata;
using Archivos;

namespace TestUnitarios
{
    [TestClass]
    public class Tests
    {
        /// <summary>
        /// Testea NacionalidadInvalidaException a través de un DNI fuera del rango aceptado.
        /// </summary>
        [TestMethod]
        //Assert.
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void ArrojarNacionalidadInvalidaException()
        {
            //Arrange & Act.
            Alumno a = new Alumno(1, "Montgomery", "Burns", "40000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
        }

        /// <summary>
        /// Testea ArchivosException intentando guardar un archivo en un path inexistente.
        /// </summary>
        [TestMethod]
        //Assert.
        [ExpectedException(typeof(ArchivosException))]
        public void ArrojarArchivosException()
        {
            //Arrange.
            string s = "Test";
            Xml<string> xml = new Xml<string>();

            //Act.
            xml.Guardar(@"C:/pathInexistente/Archivo.txt", s);
        }

        /// <summary>
        /// Testea que el constructor de Jornada no deje su atributo de tipo colección en null
        /// </summary>
        [TestMethod]
        public void TestearColeccionNoNull()
        {
            //Arrange.
            Profesor p = new Profesor();

            //Act.
            Jornada j = new Jornada(Universidad.EClases.Laboratorio,p);

            //Assert.
            Assert.IsNotNull(j.Alumnos);
        }
    }
}
