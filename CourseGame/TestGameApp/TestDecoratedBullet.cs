using System;
using GameLibrary.Bullets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestGameApp
{
    [TestClass]
    public class TestDecoratedBullet
    {
        DamageBullet damageBullet;

        [TestInitialize]
        public void InitalizeBullet()
        {
            damageBullet = new DamageBullet();
        }

        [TestMethod]
        public void TestSlowdownBulletDecorator()
        {
            
        }

        [TestMethod]
        public void TestFrezzeBulletDecorator()
        {
            
        }
    }
}
