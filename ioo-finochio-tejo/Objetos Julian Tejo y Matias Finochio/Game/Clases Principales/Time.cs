using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class Time
    {
        public static float DeltaTime { get; private set; }

        private static DateTime startDate;
        private static float lastFrameTime;

        public static void Initialize(DateTime dateTime)
        {
            startDate = dateTime;
        }

        public static void CalculateDeltaTime()
        {
            float currentTime = (float)(DateTime.Now - startDate).TotalSeconds;
            DeltaTime = currentTime - lastFrameTime;
            lastFrameTime = currentTime;
        }
    }
}
