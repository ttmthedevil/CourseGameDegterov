using System;
using GameLibrary.Guns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestGameApp
{
    [TestClass]
    public class TestDecoratedGun
    {
        DamageGun damageGun;

        [TestInitialize]
        public void InitalizeGun()
        {
            damageGun = new DamageGun();
        }

        [TestMethod]
        public void TestSlowdownGunDecorator()
        {
           
        }

        [TestMethod]
        public void TestFrezzeGunDecorator()
        {
        }
    }
}
