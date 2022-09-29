using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Animation
    {
        public bool isLooping = false;
        public string Name { get; private set; }
        public float speed { get; private set; }
        public Texture CurrentTexture => frames[currentFrameIndex];

        public float Speed { get => speed; set => speed = value; }
        public int CurrentFrameIndex { get => currentFrameIndex; set => currentFrameIndex = value; }
        public float CurrentAnimationTime { get => currentAnimationTime; set => currentAnimationTime = value; }

        private List<Texture> frames;
        public int currentFrameIndex { get; private set; }
        public float currentAnimationTime { get; private set; }
        public Animation(string name, List<Texture> frames, float speed, bool isLooping = true)
        {
            this.Name = name;
            this.frames = frames;
            this.isLooping = isLooping;
            this.speed = speed;
            this.currentFrameIndex = 0;        
        }
        public void Play()
        {
            currentFrameIndex = 0;
            currentAnimationTime = 0;
        }
        public void Update()
        {
            currentAnimationTime += Time.DeltaTime;
            if(currentAnimationTime>= speed)
            {
                currentFrameIndex++;
                currentAnimationTime = 0f;
                if (currentFrameIndex >= frames.Count)
                {
                    if (isLooping)
                    {
                        currentFrameIndex = 0;
                    }
                    else
                    {
                        currentFrameIndex = frames.Count-1;
                    }
                }
            }
        }
    }
}
