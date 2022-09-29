using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class CreditsScreen
    {
        private float currentTime;
        private string texturePath= "Textures/Screens/Credits.png";
        private float timeToBack=5f;

        public void Update()
        {
            currentTime += Time.DeltaTime;

            if (currentTime >= timeToBack)
            {
                currentTime = 0;
                GameManager.Instance.ChangeState(GameManager.State.MainMenu);
            }
        }
        public void Render()
        {
            Engine.Draw(texturePath);
        }
    }
}
