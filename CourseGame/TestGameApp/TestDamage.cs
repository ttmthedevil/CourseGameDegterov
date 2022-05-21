using System;
using GameLibrary.Effects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestGameApp
{
    [TestClass]
    public class TestDamage
    {

        [TestMethod]
        public void TestDamageEffect()
        {
            DamageEffect slowdownEffect = new DamageEffect();

            float expectedSpeed = 5f;
            float actualSpeed = slowdownEffect.EffectTime;

            Assert.AreEqual(expectedSpeed, actualSpeed);
        }

        [TestMethod]
        public void TestErrorDamageEffect()
        {
            DamageEffect slowdownEffect = new DamageEffect();

            float expectedSpeed = slowdownEffect.EffectTime*2;
            float actualSpeed = slowdownEffect.EffectTime;

            Assert.AreNotEqual(expectedSpeed, actualSpeed);
        }
    }
}
