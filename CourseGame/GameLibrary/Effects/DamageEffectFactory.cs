using EngineLibrary.EngineComponents;
using EngineLibrary.ObjectComponents;
using GameLibrary.Game;
using SharpDX;

namespace GameLibrary.Effects.EffectFactories
{
    /// <summary>
    /// Фабрика созядания эффекта смерти
    /// </summary>
    public class DamageEffectFactory
    {
        /// <summary>
        /// Создание могилы с монетами
        /// </summary>
        /// <param name="player">Игровой объект игрока</param>
        /// <returns>Игровой объект</returns>
        public GameObject CreateEffect(GameObject gameObj, string tag = null, float power = 1)
        {
            GameObject gameObject = new GameObject();
            gameObject.InitializeObjectComponent(new TransformComponent(gameObj.Transform.Position, new Size2F(1f, 1f)));
           // gameObject.InitializeObjectComponent(new SpriteComponent(RenderingSystem.LoadBitmap("Resources/MazeElements/Effects/damage idle 1.png")));
            gameObject.InitializeObjectComponent(new ColliderComponent(gameObject, new Size2F(0.8f, 0.8f)));
            gameObject.GameObjectTag = "Effect";
            DamageEffect damageEffect = new DamageEffect();
            damageEffect.ActivateEffect(gameObj, tag, power);

           // if (gameObj.Script is Player scriptPlayer && scriptPlayer.Property.Health > 0) gameObject.Sprite.Bitmap = null;

            gameObject.InitializeObjectScript(damageEffect);

            return gameObject;
        }
    }
}
