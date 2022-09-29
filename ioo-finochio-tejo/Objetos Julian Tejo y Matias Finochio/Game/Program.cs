using System;
using System.Collections.Generic;
using System.Media;
namespace Game
{
    public class Program
    {   // ejemplo AutoPropiedad
        // public static float DeltaTime{get; private set;}//private para que solo se pueda modificar dentro de la misma clase
        public const int SCREEN_WIDTH = 1280;//20 tiles 64*64
        public const int SCREEN_HEIGHT = 960;//15

        static void Main(string[] args)
        {
            Initialization();

            while(true)
            {
                Time.CalculateDeltaTime();
                Update();
                Render();
            }
        }

        private static void Initialization()
        {
            Engine.Initialize("game",SCREEN_WIDTH,SCREEN_HEIGHT);
            Time.Initialize(DateTime.Now);
            GameManager.Instance.Initialize();
        }

        private static void Update()
        {
            GameManager.Instance.Update();
        }
        private static void Render()
        {
            Engine.Clear();

            GameManager.Instance.Render();

            Engine.Show();
        }
    }
}