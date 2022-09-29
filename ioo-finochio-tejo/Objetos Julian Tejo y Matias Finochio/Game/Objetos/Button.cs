using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Button
    {
        private Vector2 position;
        public float scale;
        private string normalTexturePath;
        private string highlightTexturePath;
        private bool isSelected;

        public Button NextButton { get; private set; }
        public Button PreviousButton { get; private set; }

        public Button(Vector2 initialPos, float scale, string normalTexturePath, string highlightTexturePath)
        {
            Initialize(initialPos, scale, normalTexturePath, highlightTexturePath);
        }

        public void Initialize(Vector2 initialPos, float scale, string normalTexturePath, string highlightTexturePath)
        {
            this.position = initialPos;
            this.normalTexturePath = normalTexturePath;
            this.highlightTexturePath = highlightTexturePath;
            this.scale = scale;
        }

        public void AssignButtons(Button nextButton, Button previousButton)
        {
            NextButton = nextButton;
            PreviousButton = previousButton;
        }

        public void Deselect()
        {
            isSelected = false;
        }
        public void Select()
        {
            isSelected = true;
        }
        public void Update()
        {

        }

        public void Render()
        {
            Engine.Draw(isSelected ? highlightTexturePath : normalTexturePath, position.X, position.Y, scale, scale);
        }
    }
}
