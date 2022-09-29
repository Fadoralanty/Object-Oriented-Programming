using Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameTest
{
    [TestClass]
    public class Vector2TestClass
    {
        [TestMethod]
        public void Vector2Test()
        {
            float posX = 10;
            float posY = 10;
            
            Vector2 vector = new Vector2(posX, posY);

            Assert.IsTrue(vector.X == posX);
            Assert.IsTrue(vector.Y == posY);
        }

        [TestMethod]
        public void Vector2ToStringTest()
        {
            float posX = 10;
            float posY = 10;

            Vector2 vector = new Vector2(posX, posY);

            string result = vector.ToString();
            string expectedResult = $"Vector2({posX},{posY})";

            Assert.AreEqual(result, expectedResult);
        }
    }
}