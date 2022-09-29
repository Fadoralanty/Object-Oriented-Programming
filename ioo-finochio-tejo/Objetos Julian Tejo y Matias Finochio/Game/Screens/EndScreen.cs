using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class EndScreen
    {
        private float currentTime;
        private string texturePath;
        private float timeToBack;

        public EndScreen(string texturePath, float timeToBack)
        {
            Initialize(texturePath, timeToBack);
        }

        public void Initialize(string texturePath, float timeToBack)
        {
            this.texturePath = texturePath;
            this.timeToBack = timeToBack;
            currentTime = 0;
        }
        public void Update()
        {
            currentTime += Time.DeltaTime;

            if (currentTime >= 5f)
            {
                Environment.Exit(1);
            }
        }
        public void Render()
        {
            Engine.Draw(texturePath);
        }
    }
}