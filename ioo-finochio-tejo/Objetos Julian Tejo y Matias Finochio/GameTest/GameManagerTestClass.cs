using Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GameTest
{
    [TestClass]
    public class GameManagerTestClass
    {
        //------Method 1-------

        [TestMethod]
        public void GameManager_Initialize_NotNull()
        {
            //Act
            GameManager.Instance.Initialize();
            var resultMainMenuPath = GameManager.Instance.MainMenu;
            var resultGameOverPath = GameManager.Instance.GameOverScreen;
            var resultWinPath = GameManager.Instance.WinScreen;

            //Assert
            Assert.IsNotNull(resultMainMenuPath);
            Assert.IsNotNull(resultGameOverPath);
            Assert.IsNotNull(resultWinPath);
        }
    }
}