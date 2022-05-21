using EngineLibrary.EngineComponents;
using EngineLibrary.ObjectComponents;
using GameLibrary.Game;
using GameLibrary.Platformer;

namespace GameLibrary.Effects
{
    /// <summary>
    /// Эффект после урона
    /// </summary>
    public class DamageEffect : ObjectScript
    {
        /// <summary>
        /// Время дейтсвия эффекта
        /// </summary>
        public float EffectTime => 5f;

        protected PlatformerScene platformer;
        /// <summary>
        /// Ссылка на сценарий игрока, на которого действует эффект
        /// </summary>
        protected Player playerScript;
        /// <summary>
        /// Ссылка на игровой объект, на которого действует эффектяя
        /// </summary>
        protected GameObject playerGameObject;

        protected float currentEffectTime;

        /// <summary>
        /// Поведение на момент создание игрового объекта
        /// </summary>
        public override void Start()
        {
            platformer = PlatformerScene.instance;
            currentEffectTime = Time.CurrentTime + EffectTime;

            Initialize();
        }

        /// <summary>
        /// Обновление игрового объекта
        /// </summary>
        public override void Update()
        {
            if (currentEffectTime < Time.CurrentTime)
                DeactivateEffect();

            BehaviorOnScene();
        }


        /// <summary>
        /// Активация эффекта
        /// </summary>
        /// <param name="player">Игровой объект, на который будет наложен эффект</param>
        public void ActivateEffect(GameObject player,string tag = null, float power = 1)
        {
            playerGameObject = player;
            playerGameObject.IsActive = true;

            if(playerGameObject.Script is Player objectScript)
            {
                if (objectScript.Property.Health > 0)
                {
                    objectScript?.ChangeStatsValue(-power);
                }

                if (objectScript.Property.Health <= 0)
                {
                    playerGameObject.IsActive = false;

                    if (tag != null)
                    {
                        Player.SetBullets(tag, 25);

                        Player.SetBullets(tag == "Red Player" ? "Blue Player" : "Red Player", -25);
                    }

                    switch (playerGameObject.GameObjectTag)
                    {
                        case "Red Player" when Player.RpBullets != 1:
                            objectScript?.ChangeStatsValue(-Player.RpBullets / 2, "Death");
                            break;
                        case "Blue Player" when Player.BpBullets != 1:
                            objectScript?.ChangeStatsValue(-Player.BpBullets / 2, "Death");
                            break;
                        default:
                            objectScript?.ChangeStatsValue(-power, "Death");
                            break;
                    }
                    GameEvents.ChangeEffect?.Invoke(playerGameObject.GameObjectTag, "Death");
                }
            }
        }

        /// <summary>
        /// Инициализация эффекта
        /// </summary>
        protected void Initialize() { }

        /// <summary>
        /// Деактивация эффекта
        /// </summary>
        protected void DeactivateEffect()
        {
            if (!playerGameObject.IsActive)
            {
                playerGameObject.Transform.Position = playerGameObject.GameObjectTag == "Blue Player"
                    ?
                    platformer.CountEmptyBlocks() != 0 ? platformer.GetRandomPosition() : platformer.BluePlayerFactory.StartPosition
                    : platformer.CountEmptyBlocks() != 0
                        ? platformer.GetRandomPosition()
                        : platformer.RedPlayerFactory.StartPosition;
                playerGameObject.IsActive = true;
            }
            platformer.RemoveObjectFromScene(gameObject);
            GameEvents.ChangeEffect?.Invoke(playerGameObject.GameObjectTag, "");
            
        }

        /// <summary>
        /// Поведение на сцене
        /// </summary>
        protected void BehaviorOnScene()
        {
            if (gameObject.Collider.CheckIntersection(out GameObject player) && gameObject.IsActive && playerGameObject.GameObjectTag == player.GameObjectTag)
            {
                gameObject.IsActive = false;
            }

            if (playerGameObject.IsActive)
            {
                platformer.RemoveObjectFromScene(gameObject);
            }
        }
    }
}
