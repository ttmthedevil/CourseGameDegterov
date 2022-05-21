using System;
using EngineLibrary.EngineComponents;
using GameLibrary;
using GameLibrary.Bullets.BulletFactories;
using GameLibrary.Effects;
using GameLibrary.Guns;
using GameLibrary.Platformer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpDX;

namespace TestGameApp
{
    [TestClass]
    public class TestDecoratedPrize 
    {
        private RenderingApplication application;
        private PlatformerScene mazeScene;
        
        /// <summary>
        /// Тестирование фабричного метода создания приза амуниции.
        /// </summary>
        [TestMethod]
        public void TestMethodFactoryPrizeAmmo()
        {
            application = new RenderingApplication();
            mazeScene = new PlatformerScene();
            application.SetScene(mazeScene);
            application.Run();
            var factory = new AmmoPrizeFactory();

            var prize = factory.CreatePrize(new Vector2(1, 1));
            Assert.IsTrue(prize.Script is PrizeSpawn);
        }

        /// <summary>
        /// Тестирование фабричного метода создания приза здоровья.
        /// </summary>
        [TestMethod]
        public void TestMethodFactoryPrizeBullet()
        {
            application = new RenderingApplication();
            mazeScene = new PlatformerScene();
            application.SetScene(mazeScene);
            application.Run();
            var factory = new BolletPowerPrizeFactory();

            var prize = factory.CreatePrize(new Vector2(1, 1));
            Assert.IsTrue(prize.Script is PrizeSpawn);
        }

        /// <summary>
        /// Тестирование фабричного метода создания приза времени презарядки.
        /// </summary>
        [TestMethod]
        public void TestMethodFactoryPrizeReload()
        {
            application = new RenderingApplication();
            mazeScene = new PlatformerScene();
            application.SetScene(mazeScene);
            application.Run();
            var factory = new ReloadTimePrizeFactory();

            var prize = factory.CreatePrize(new Vector2(1, 1));
            Assert.IsTrue(prize.Script is PrizeSpawn);
        }

        /// <summary>
        /// Тестирование фабричного метода создания приза скорости.
        /// </summary>
        [TestMethod]
        public void TestMethodFactoryPrizeSpeed()
        {
            application = new RenderingApplication();
            mazeScene = new PlatformerScene();
            application.SetScene(mazeScene);
            application.Run();
            var factory = new SpeedPrizeFactory();

            var prize = factory.CreatePrize(new Vector2(1, 1));
            Assert.IsTrue(prize.Script is PrizeSpawn);
        }
    }
}
