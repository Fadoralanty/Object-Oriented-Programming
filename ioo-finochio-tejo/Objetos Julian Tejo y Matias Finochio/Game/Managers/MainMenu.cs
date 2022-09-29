using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class MainMenu : IMenuButtonController
    {
        private string bgTexturePath;
        public Button defaultButton { get; private set; }
        private Button creditsButton;
        private Button quitButton;
        private Button highlightButton;
        private float currentInputDelayTime;
        private float inputDelayTime = 0.2f;

        public MainMenu(string bgTexturePath)
        {
            Initialize(bgTexturePath);
        }

        public void Initialize(string bgTexturePath)
        {
            this.bgTexturePath = bgTexturePath;

            defaultButton = new Button(new Vector2(250, 300), 1,  "Textures/Buttons/PlayButton/PlayHighlight.png", "Textures/Buttons/PlayButton/PlayNormal.png");
            creditsButton = new Button(new Vector2(250, 450), 1,  "Textures/Buttons/CreditsButton/CreditsHightlight.png", "Textures/Buttons/CreditsButton/CreditsNormal.png");
            quitButton = new Button(new Vector2(250, 600), 1, "Textures/Buttons/QuitButton/QuitHightlight.png", "Textures/Buttons/QuitButton/QuitNormal.png");

            defaultButton.AssignButtons(creditsButton, quitButton);
            creditsButton.AssignButtons(quitButton, defaultButton);
            quitButton.AssignButtons(defaultButton, creditsButton);

            SelectButton(defaultButton);
        }

        public void Update()
        {
            currentInputDelayTime -= Time.DeltaTime;

            defaultButton.Update();
            creditsButton.Update();
            quitButton.Update();

            if (Engine.GetKey(Keys.UP) && currentInputDelayTime <= 0)
            {
                SelectButton(highlightButton.PreviousButton);
                currentInputDelayTime = inputDelayTime;
            }

            if (Engine.GetKey(Keys.DOWN) && currentInputDelayTime <= 0)
            {
                SelectButton(highlightButton.NextButton);
                currentInputDelayTime = inputDelayTime;
            }

            if (Engine.GetKey(Keys.SPACE) && currentInputDelayTime <= 0 )
            {
                PressSelectedButton();
            }
        }

        public void Render()
        {
            Engine.Draw(bgTexturePath);
            defaultButton.Render();
            creditsButton.Render();
            quitButton.Render();
        }

        public void PressSelectedButton()
        {
            if (highlightButton != null)
            {
                if (highlightButton == defaultButton)
                {
                    GameManager.Instance.ChangeState(GameManager.State.Level1);
                }
                else if (highlightButton == creditsButton)
                {
                    GameManager.Instance.ChangeState(GameManager.State.Credits);
                }
                else if (highlightButton == quitButton)
                {
                    GameManager.Instance.ExitGame();
                }
            }
        }

        public void SelectButton(Button button)
        {
            if (highlightButton != null)
            {
                highlightButton.Deselect();
            }
            highlightButton = button;
            button.Select();
        }
    }
}
