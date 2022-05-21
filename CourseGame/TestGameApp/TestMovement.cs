using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EngineLibrary.ObjectComponents;
using SharpDX;

namespace TestGameApp
{
    [TestClass]
    public class TestMovement
    {
        [TestMethod]
        public void TestGameObjectMovement()
        {
            var gameObject = new GameObject();
            gameObject.InitializeObjectComponent(new TransformComponent(new Vector2(1f, 1f), new Size2F(1, 1)));

            var offset = new Vector2(1f, 1f);

            gameObject.Transform.SetMovement(offset);

            var expected = new Vector2(2f, 0f);
            var actual = gameObject.Transform.Position;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestErrorGameObjectMovement()
        {
            Random rnd = new Random();

            //Получить случайное число (в диапазоне от 0 до 10)
            float value = rnd.NextFloat(0.0f, 10.0f);

            var gameObject = new GameObject();
            gameObject.InitializeObjectComponent(new TransformComponent(new Vector2(1f, 1f), new Size2F(1, 1)));

            var offset = new Vector2(value, value);

            gameObject.Transform.SetMovement(offset);

            var expected = new Vector2(value, value);
            var actual = gameObject.Transform.Position;

            Assert.AreNotEqual(expected, actual);
        }
    }
}
