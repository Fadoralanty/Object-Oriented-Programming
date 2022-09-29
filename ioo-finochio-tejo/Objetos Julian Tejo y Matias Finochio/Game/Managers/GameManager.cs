using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameManager
    {
        public enum State
        {
            MainMenu,
            Level1,
            Level2,
            Level3,
            GameOver,
            WinScreen,
            Credits
        }

        private Level1 level1;
        private Level2 level2;
        private Level3 level3;
        private EndScreen winScreen;
        private EndScreen gameOverScreen;
        private State currentState;
        private MainMenu mainMenu;
        private CreditsScreen creditsScreen;

        //SINGLETON
        private static readonly GameManager instance = new GameManager();
        public static GameManager Instance => instance;

        public EndScreen WinScreen { get => winScreen; set => winScreen = value; }
        public EndScreen GameOverScreen { get => gameOverScreen; set => gameOverScreen = value; }
        public CreditsScreen CreditsScreen { get => creditsScreen; set => creditsScreen = value; }
        public MainMenu MainMenu { get => mainMenu; set => mainMenu = value; }

        private GameManager() { }

        public void Initialize()
        {
            
            level1 = new Level1();
            level2 = new Level2();
            level3 = new Level3();
            gameOverScreen = new EndScreen("Textures/Screens/GameOver.png", 5f);
            winScreen = new EndScreen("Textures/Screens/YouWin.png", 500f);
            mainMenu = new MainMenu("Textures/Screens/MainMenu2.png");
            creditsScreen = new CreditsScreen();

            ChangeState(State.MainMenu);
        }

        public void Update()
        {
            switch (currentState)
            {
                case State.MainMenu:
                    mainMenu.Update();
                    break;

                case State.Level1:
                    level1.Update();
                    break;

                case State.Level2:
                    level2.Update();
                    break;

                case State.Level3:
                    level3.Update();
                    break;

                case State.GameOver:
                    gameOverScreen.Update();
                    break;

                case State.WinScreen:
                    winScreen.Update();
                    break;

                case State.Credits:
                    creditsScreen.Update();
                    break;

                default:
                    break;
            }
        }

        public void Render()
        {
            switch (currentState)
            {
                case State.MainMenu:
                    mainMenu.Render();
                    break;

                case State.Level1:
                    level1.Render();
                    break;

                case State.Level2:
                    level2.Render();
                    break;

                case State.Level3:
                    level3.Render();
                    break;

                case State.GameOver:
                    gameOverScreen.Render();
                    break;

                case State.WinScreen:
                    winScreen.Render();
                    break;
                case State.Credits:
                    creditsScreen.Render();
                    break;
                default:
                    break;
            }
        }

        public void ChangeState(State state)
        {
            /*if (state == State.Level1)
            {
                level1 = new Level1();
            }
            if (state == State.Level2)
            {
                level2 = new Level2();
            }*/
            currentState = state;
        }

        public void ExitGame()
        {
            Environment.Exit(1);
        }
    }

}
