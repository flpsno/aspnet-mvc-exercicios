using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.Test
{
    [TestClass]
    public class HelloWorldTest
    {

        [TestMethod]
        public void OlaMundo_Teste()
        { 
            //arrange (Ambiente)
            var helloWorld = "HelloWorld";

            //action (Ação que vc irá testar)
            helloWorld = helloWorld.ToUpper();

            //assert (Testa o resultado final)
            Assert.AreEqual("HELLOWORLD", helloWorld);
            Assert.IsTrue(true);
        }

    }
}
