using Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace GameTest
{
    [TestClass]
    public class Level1TestClass
    {
        //------Method 1-------

        [TestMethod]
        public void Level1_Initialize_NotNull()
        {
            //Arrange
            Level1 level1 = new Level1();

            //Act
            level1.Initialize();
            PlayerController expectedPlayer = level1.Player;
            //Trap expectedTrap = level1.Trap;
            SoundPlayer expectedMusic = level1.Music;

            Box expectedIsABox = level1.IsaBox;
            Box expectedIsABox2 = level1.IsaBox2;
            Box expectedIsABox3 = level1.IsaBox3;

            //Assert
            Assert.IsNotNull(expectedPlayer);
            //Assert.IsNotNull(expectedTrap);
            Assert.IsNotNull(expectedMusic);

            Assert.IsNotNull(expectedIsABox);
            Assert.IsNotNull(expectedIsABox2);
            Assert.IsNotNull(expectedIsABox3);
        }

        [TestMethod]
        public void Level1_ResetPosition()
        {
            //Arrange
            Level1 level1 = new Level1();
            PlayerController player = new PlayerController(new Vector2(200, 200), new Vector2(0.5f, 0.5f), new Vector2(0, 0), new Vector2(250, 250));

            //Act
            Vector2 playerPosition = player.Transform.Position;
            Vector2 expectedPosition = new Vector2(200, 200);
            level1.ResetPosition();

            //Assert
            Assert.IsTrue(playerPosition == expectedPosition);
        }
    }
}