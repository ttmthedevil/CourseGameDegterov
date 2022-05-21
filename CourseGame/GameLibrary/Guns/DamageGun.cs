using EngineLibrary.EngineComponents;
using EngineLibrary.ObjectComponents;
using GameLibrary.Bullets.BulletFactories;
using GameLibrary.Game;
using GameLibrary.Platformer;
using SharpDX;

namespace GameLibrary.Guns
{
    /// <summary>
    /// Класс оружия урона
    /// </summary>
    public class DamageGun : ObjectScript
    {


        public PlayerConstructor PlayerFactory { get; set; }

        /// <summary>
        /// Экземпляр сцены игры
        /// </summary>
        protected PlatformerScene maze;

        private Player playerScript;
        private float currentReloadTime;
        //private Monster monsterScript;

        /// <summary>
        /// Поведение на момент создание игрового объекта
        /// </summary>
        public override void Start()
        {

            playerScript = ((Player)gameObject.ParentGameObject.Script);
            currentReloadTime = Time.CurrentTime + playerScript.Property.ReloadTime;

            maze = PlatformerScene.instance;

            if (playerScript != null)
            {
                GameEvents.ChangeCount?.Invoke(playerScript.gameObject.GameObjectTag, playerScript.Property.Ammo);
            }

            LoadAnimation();
        }

        /// <summary>
        /// Обновление игрового объекта
        /// </summary>
        public override void Update()
        {
            if (playerScript != null && playerScript.IsCanMove && Input.GetButtonDawn(playerScript.Control.ShootKey) && currentReloadTime < Time.CurrentTime && playerScript.Property.Ammo > 0)
            {
                Vector2 bulletSpawnPosition = gameObject.ParentGameObject.Transform.Position;
                Vector2 bulletDirection = new Vector2(gameObject.Sprite.IsFlipX ? -1 : 1, 1);
                SpawnBullet(bulletSpawnPosition, bulletDirection, playerScript.Property.Power);
                playerScript.Property.SetProperty(TypeProperty.Ammo, playerScript.Property.Ammo - 1);

                currentReloadTime = Time.CurrentTime + playerScript.Property.ReloadTime;

                if (playerScript != null && playerScript.Property.Ammo >= 0)
                {
                    GameEvents.ChangeCount?.Invoke(playerScript.gameObject.GameObjectTag, playerScript.Property.Ammo);
                }
            }
            else if (playerScript != null && playerScript.IsCanMove && Input.GetButtonDawn(playerScript.Control.ShootKey1) && currentReloadTime < Time.CurrentTime && playerScript.Property.Ammo > 0)
            {
                Vector2 bulletSpawnPosition = gameObject.ParentGameObject.Transform.Position;
                Vector2 bulletDirection = new Vector2(gameObject.Sprite.IsFlipX ? -1 : 1, 0);
                SpawnBullet(bulletSpawnPosition, bulletDirection, playerScript.Property.Power);
                playerScript.Property.SetProperty(TypeProperty.Ammo, playerScript.Property.Ammo - 1);

                currentReloadTime = Time.CurrentTime + playerScript.Property.ReloadTime;

                if (playerScript != null && playerScript.Property.Ammo >= 0)
                {
                    GameEvents.ChangeCount?.Invoke(playerScript.gameObject.GameObjectTag, playerScript.Property.Ammo);
                }
            }
            else if (playerScript != null && playerScript.IsCanMove && Input.GetButtonDawn(playerScript.Control.ShootKey2) && currentReloadTime < Time.CurrentTime && playerScript.Property.Ammo > 0)
            {
                Vector2 bulletSpawnPosition = gameObject.ParentGameObject.Transform.Position;
                Vector2 bulletDirection = new Vector2(0, 1);
                SpawnBullet(bulletSpawnPosition, bulletDirection, playerScript.Property.Power);
                playerScript.Property.SetProperty(TypeProperty.Ammo, playerScript.Property.Ammo - 1);

                currentReloadTime = Time.CurrentTime + playerScript.Property.ReloadTime;

                if (playerScript != null && playerScript.Property.Ammo >= 0)
                {
                    GameEvents.ChangeCount?.Invoke(playerScript.gameObject.GameObjectTag, playerScript.Property.Ammo);
                }
            }
        }

        /// <summary>
        /// Загрузка анимации оружия
        /// </summary>
        protected void LoadAnimation()
        {
            Animation animation;
            if (PlayerFactory != null)
            {
                animation = new Animation(RenderingSystem.LoadAnimation("Resources/" + PlayerFactory.PlayerTag + "/Damage Gun/damage left idle ", 2), 0.2f, true);

                gameObject.Sprite.AddAnimation("idleLeft", animation);
                animation = new Animation(RenderingSystem.LoadAnimation("Resources/" + PlayerFactory.PlayerTag + "/Damage Gun/damage left run ", 4), 0.2f, true);
                gameObject.Sprite.AddAnimation("runLeft", animation);
                animation = new Animation(RenderingSystem.LoadAnimation("Resources/" + PlayerFactory.PlayerTag + "/Damage Gun/damage right idle ", 2), 0.2f, true);
                gameObject.Sprite.AddAnimation("idleRight", animation);
                animation = new Animation(RenderingSystem.LoadAnimation("Resources/" + PlayerFactory.PlayerTag + "/Damage Gun/damage right run ", 4), 0.2f, true);
                gameObject.Sprite.AddAnimation("runRight", animation);

                gameObject.Sprite.SetAnimation("idleLeft");
            }
            else
            {
                animation = new Animation(RenderingSystem.LoadAnimation("Resources/" + "Blue Player" + "/Damage Gun/damage left idle ", 2), 0.2f, true);

                gameObject.Sprite.AddAnimation("idleLeft", animation);
                animation = new Animation(RenderingSystem.LoadAnimation("Resources/" + "Blue Player" + "/Damage Gun/damage left run ", 4), 0.2f, true);
                gameObject.Sprite.AddAnimation("runLeft", animation);
                animation = new Animation(RenderingSystem.LoadAnimation("Resources/" + "Blue Player" + "/Damage Gun/damage right idle ", 2), 0.2f, true);
                gameObject.Sprite.AddAnimation("idleRight", animation);
                animation = new Animation(RenderingSystem.LoadAnimation("Resources/" + "Blue Player" + "/Damage Gun/damage right run ", 4), 0.2f, true);
                gameObject.Sprite.AddAnimation("runRight", animation);

                gameObject.Sprite.SetAnimation("idleLeft");
            }
        }

        /// <summary>
        /// Создание пули из фабрики
        /// </summary>
        /// <param name="position">Позиция создания</param>
        /// <param name="direction">Направление пули</param>
        protected void SpawnBullet(Vector2 position, Vector2 direction, float power = 1)
        {
            DamageBulletFactory factory = new DamageBulletFactory();
            maze.AddObjectOnScene(factory.CreateBullet(position, direction, gameObject.ParentGameObject.GameObjectTag, power));
        }
    }
}
