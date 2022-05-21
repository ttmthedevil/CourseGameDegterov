using System;
using GameLibrary;
using GameLibrary.Bullets;
using GameLibrary.Game;
using GameLibrary.Platformer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpDX;

namespace TestGameApp
{
    [TestClass]
    public class TestFactoryPrize
    {

        /// <summary>
        /// Базовые характеристики игрока.
        /// </summary>
        private PlayerProperitiesStandart playerProperities;

        /// <summary>
        /// Инициализация.
        /// </summary>
        [TestInitialize]
        public void InitalizeBullet()
        {
            playerProperities = new PlayerProperitiesStandart();
            playerProperities.SetProperty(TypeProperty.Health, 10);
            playerProperities.SetProperty(TypeProperty.Ammo, 10);
        }

        /// <summary>
        /// Тестирование декоратора скорости.
        /// </summary>
        [TestMethod]
        public void TestSpeedDecorator()
        {
            SpeedDecorator speedDecorator = new SpeedDecorator(playerProperities);

            float expectedSpeed = playerProperities.Speed * 1.5f;

            Assert.AreEqual(expectedSpeed, speedDecorator.Speed);
        }
        [TestMethod]
        public void TestErrorSpeedDecorator()
        {
            SpeedDecorator speedDecorator = new SpeedDecorator(playerProperities);

            float expectedSpeed = playerProperities.Speed - 1.5f;

            Assert.AreNotEqual(expectedSpeed, speedDecorator.Speed);
        }

        /// <summary>
        /// Тестирование декоратора силы выстрела.
        /// </summary>
        [TestMethod]
        public void TestPowerDecorator()
        {
            PowerDecorator powerDecorator = new PowerDecorator(playerProperities);

            float expectedPower = playerProperities.Power * 2;

            Assert.AreEqual(expectedPower, powerDecorator.Power);
        }

        [TestMethod]
        public void TestErrorPowerDecorator()
        {
            PowerDecorator powerDecorator = new PowerDecorator(playerProperities);

            float expectedPower = playerProperities.Power / 2;

            Assert.AreNotEqual(expectedPower, powerDecorator.Power);
        }

        /// <summary>
        /// Тестирование врмени перезарядки.
        /// </summary>
        [TestMethod]
        public void TestReloadTimeDecorator()
        {
            ReloadTimeDecorator reloadTimeDecorator = new ReloadTimeDecorator(playerProperities);

            float expectedReloadTime = playerProperities.ReloadTime / 2;

            Assert.AreEqual(expectedReloadTime, reloadTimeDecorator.ReloadTime);
        }

        [TestMethod]
        public void TestErrorReloadTimeDecorator()
        {
            ReloadTimeDecorator reloadTimeDecorator = new ReloadTimeDecorator(playerProperities);

            float expectedReloadTime = playerProperities.ReloadTime - 2;

            Assert.AreNotEqual(expectedReloadTime, reloadTimeDecorator.ReloadTime);
        }
    }
}
