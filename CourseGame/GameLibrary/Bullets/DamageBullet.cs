using EngineLibrary.EngineComponents;
using EngineLibrary.ObjectComponents;
using GameLibrary.Effects.EffectFactories;
using GameLibrary.Platformer;
using SharpDX;

namespace GameLibrary.Bullets
{
    /// <summary>
    /// Класс пули урона
    /// </summary>
    public class DamageBullet : ObjectScript
    {

        /// <summary>
        /// Экземпляр сцены игры
        /// </summary>
        protected PlatformerScene platformer;

        private Vector2 flyDirection;
        private string[] interactionTag = new string[2];
        protected string tag;
        protected float power;

        /// <summary>
        /// Установление направления полета пули
        /// </summary>
        /// <param name="direction">Вектор направления</param>
        /// <param name="tag">Тег игрового объекта, создающий пулю</param>
        public void SetSettings(Vector2 direction, string tag, float power)
        {
            this.tag = tag;
            flyDirection = direction;
            this.power = power;

            if (tag == "Blue Player")
                interactionTag[0] = "Red Player";
            else switch (tag)
            {
                case "Red Player":
                    interactionTag[0] = "Blue Player";
                    break;
                default:
                    interactionTag[0] = "Blue Player";
                    interactionTag[1] = "Red Player";
                    break;
            }

        }

        /// <summary>
        /// Поведение на момент создание игрового объекта
        /// </summary>
        public override void Start() => platformer = PlatformerScene.instance;

        /// <summary>
        /// Обновление игрового объекта
        /// </summary>
        public override void Update()
        {
            Vector2 movement = flyDirection * Speed * Time.DeltaTime;

            gameObject.Transform.SetMovement(movement);

            if (gameObject.Collider.CheckIntersection("Wall"))
            {
                platformer.RemoveObjectFromScene(gameObject);
            }

            if (gameObject.Collider.CheckIntersection(out GameObject playerGameObject, interactionTag))
            {
                PlayerInteraction(playerGameObject);
                platformer.RemoveObjectFromScene(gameObject);
            }

        }

        /// <summary>
        /// Скорость пули
        /// </summary>
        public float Speed => 15f;

        /// <summary>
        /// Взаимодействие с игроком
        /// </summary>
        public void PlayerInteraction(GameObject playerGameObject)
        {
            DamageEffectFactory factory = new DamageEffectFactory();
            platformer.AddObjectOnScene(factory.CreateEffect(playerGameObject, tag, power));
        }
    }
}
