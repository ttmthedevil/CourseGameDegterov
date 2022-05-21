using System;
using GameLibrary.Effects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestGameApp
{
    [TestClass]
    public class TestDecoratedEffect
    {
        DamageEffect damageEffect;

        [TestInitialize]
        public void InitalizeGun()
        {
            damageEffect = new DamageEffect();
        }

        [TestMethod]
        public void TestSlowdownEffectDecorator()
        {
           
        }

        [TestMethod]
        public void TestFrezzeEffectDecorator()
        {
           
        }
    }
}
