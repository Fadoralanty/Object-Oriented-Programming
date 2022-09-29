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
    public class AnimationUnitTest
    {
        //------Method 1-------

        [TestMethod]
        public void AnimationClass_Constructor_NotNull()
        {
            //Arrange
            List<Texture> frames = new List<Texture>();
            Animation animation = new Animation("anim", frames, 1, true);

            //Act
            string name = animation.Name;
            bool animBool = animation.isLooping;
            float speed = animation.Speed;

            //Assert
            Assert.IsNotNull(name);
            Assert.IsNotNull(speed);
            Assert.IsTrue(animBool);
        }

        //------Method 2-------

        [TestMethod]
        public void AnimationClass_PlayMethod_FrameIndex()
        {
            //Arrange
            List<Texture> frames = new List<Texture>();
            Animation animation = new Animation("anim", frames, 1, true);

            //Act
            animation.Play();
            int result = animation.CurrentFrameIndex;
            int expectedResult = 0;

            //Assert
            Assert.AreEqual(result, expectedResult);
        }

        //------Method 3-------

        [TestMethod]
        public void AnimationClass_PlayMethod_CurrentAnimationTime()
        {
            //Arrange
            List<Texture> frames = new List<Texture>();
            Animation animation = new Animation("anim", frames, 1, true);

            //Act
            animation.Play();
            float result = animation.CurrentAnimationTime;
            float expectedResult = 0f;

            //Assert
            Assert.AreEqual(result, expectedResult);
        }
    }
}