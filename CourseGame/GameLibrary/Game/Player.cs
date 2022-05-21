using EngineLibrary.EngineComponents;
using EngineLibrary.ObjectComponents;
using SharpDX;
using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Platformer;

namespace GameLibrary.Game
{
    /// <summary>
    /// Класс, описывающий сценарий поведения игрока
    /// </summary>
    public class Player : ObjectScript
    {
        /// <summary>
        /// Управление игроком
        /// </summary>
        public PlayerControl Control { get; private set; }
        /// <summary>
        /// Возможность двигаться у игрока
        /// </summary>
        public bool IsCanMove { get; set; } = true;

        /// <summary>
        /// Полученные монеты
        /// </summary>
        public static int RpBullets { get; private set; } = 25;
        public static int BpBullets { get; private set; } = 25;

        private GameObject childGameObject;

        public PlayerProperities Property { get; private set; }

        public void SetProperty(PlayerProperities property)
        {
            property.SetProperty(TypeProperty.Health, Property.Health);
            property.SetProperty(TypeProperty.Ammo, Property.Ammo);
            property.SetPlayer(this);

            Property = property;
        }

        /// <summary>
        /// Поведение на момент создание игрового объекта
        /// </summary>
        public override void Start()
        {
            Animation animation;

            Property = new PlayerProperitiesStandart();
            Property.SetProperty(TypeProperty.Health, 3);
            Property.SetProperty(TypeProperty.Ammo, 25);
            Property.SetPlayer(this);

            if (gameObject.GameObjectTag == "Blue Player")
            {
                animation = new Animation(RenderingSystem.LoadAnimation("Resources/Blue Player/left idle ", 1), 0.2f, true);
                gameObject.Sprite.AddAnimation("idleLeft", animation);
                animation = new Animation(RenderingSystem.LoadAnimation("Resources/Blue Player/left run ", 1), 0.2f, true);
                gameObject.Sprite.AddAnimation("runLeft", animation);
                animation = new Animation(RenderingSystem.LoadAnimation("Resources/Blue Player/right idle ", 1), 0.2f, true);
                gameObject.Sprite.AddAnimation("idleRight", animation);
                animation = new Animation(RenderingSystem.LoadAnimation("Resources/Blue Player/right run ", 1), 0.2f, true);
                gameObject.Sprite.AddAnimation("runRight", animation);

                Control = new PlayerControl(AxisOfInput.Horizontal, AxisOfInput.Vertical, Key.E, Key.R, Key.T, Key.Z);
                GameEvents.ChangeHealth?.Invoke(gameObject.GameObjectTag, Property.Health);
                GameEvents.ChangeBullets?.Invoke(gameObject.GameObjectTag, BpBullets);
            }
            else
            {
                animation = new Animation(RenderingSystem.LoadAnimation("Resources/Red Player/left idle ", 1), 0.2f, true);
                gameObject.Sprite.AddAnimation("idleLeft", animation);
                animation = new Animation(RenderingSystem.LoadAnimation("Resources/Red Player/left run ", 1), 0.2f, true);
                gameObject.Sprite.AddAnimation("runLeft", animation);
                animation = new Animation(RenderingSystem.LoadAnimation("Resources/Red Player/right idle ", 1), 0.2f, true);
                gameObject.Sprite.AddAnimation("idleRight", animation);
                animation = new Animation(RenderingSystem.LoadAnimation("Resources/Red Player/right run ", 1), 0.2f, true);
                gameObject.Sprite.AddAnimation("runRight", animation);

                Control = new PlayerControl(AxisOfInput.AlternativeHorizontal, AxisOfInput.AlternativeVertical, Key.NumberPad0,Key.NumberPad1, Key.NumberPad2, Key.NumberPadEnter);
                GameEvents.ChangeHealth?.Invoke(gameObject.GameObjectTag, Property.Health);
                GameEvents.ChangeBullets?.Invoke(gameObject.GameObjectTag, RpBullets);
            }

            gameObject.Sprite.SetAnimation("idleLeft");
        }

        /// <summary>
        /// Установка дочернего объекта 
        /// </summary>
        /// <param name="gameObject">Дочерний объект</param>
        public void SetChildGameObject(GameObject gameObject)
        {
            if (childGameObject != null)
                PlatformerScene.instance.RemoveObjectFromScene(childGameObject);

            childGameObject = gameObject;
        }

        /// <summary>
        /// Обновление игрового объекта
        /// </summary>
        public override void Update()
        {
            if (gameObject.IsActive && IsCanMove)
                Move();

            Property?.UpdateTime();
        }

        /// <summary>
        /// Изменение значения характеристик игрока
        /// </summary>
        /// <param name="value">Значение, которое прибавляется к текущему значению монет</param>
        public void ChangeStatsValue(float value)
        {
            if (gameObject.Collider.CheckIntersection("Bullet") || Property.Health <= 3)
            {
                Property.SetProperty(TypeProperty.Health, Property.Health + value);
                GameEvents.ChangeHealth?.Invoke(gameObject.GameObjectTag, Property.Health);
            }
        }

        public void ChangeStatsValue(float value, string gametag)
        {
            if (gametag == "Death")
            {
                //Property.SetProperty(TypeProperty.Health, 10);
                //Coins += value;
               // GameEvents.ChangeHealth?.Invoke(gameObject.GameObjectTag, Property.Health);
                //GameEvents.ChangeCoins?.Invoke(gameObject.GameObjectTag, Coins);
            }  
        }

        /// <summary>
        /// Метод движения игрока
        /// </summary>
        private void Move()
        {
            int directionX = 0, directionY = 0;

            Input.CanJump = true;
            directionX = Input.GetAxis(Control.HorizontalAxis, gameObject);

            if (!gameObject.Collider.CheckIntersection("Wall"))
            {

                directionY = Input.GetAxis(Control.VerticalAxis, gameObject);
                gameObject.Transform.IsUseGravitation = gameObject.Collider.CheckIntersection("Wall");
            }
            else
            {
                gameObject.Transform.IsUseGravitation = true;
            }

            Vector2 direction;

            if (directionX == 0)
            {
                if(childGameObject != null)
                    childGameObject.Sprite.IsFlipX = gameObject.Sprite.IsFlipX;

                if (childGameObject != null && childGameObject.Sprite.IsFlipX)
                    childGameObject.Sprite.SetAnimation("idleLeft");
                else
                {
                    childGameObject?.Sprite.SetAnimation("idleRight");
                }

                gameObject.Sprite.SetAnimation(gameObject.Sprite.IsFlipX ? "idleLeft" : "idleRight");

                direction = new Vector2(0, directionY);
            }
            else
            {
                gameObject.Sprite.IsFlipX = directionX < 0;

                if (childGameObject != null)
                    childGameObject.Sprite.IsFlipX = gameObject.Sprite.IsFlipX;

                if (childGameObject != null && childGameObject.Sprite.IsFlipX)
                    childGameObject.Sprite.SetAnimation("runLeft");
                else
                {
                    childGameObject?.Sprite.SetAnimation("runRight");
                }

                gameObject.Sprite.SetAnimation(gameObject.Sprite.IsFlipX ? "runLeft" : "runRight");

                direction = new Vector2(directionX, 0);
            }

            Vector2 movement = direction * Property.Speed * Time.DeltaTime;
            gameObject.Transform.SetMovement(movement);

            DetectCollision();
        }

        /// <summary>
        /// Распознавание столкновений и реакция на них
        /// </summary>
        private void DetectCollision()
        {
            if (gameObject.Collider.CheckIntersection("Wall","BreakWall"))
            {
                gameObject.Transform.ResetMovement();
            }

            if (gameObject.GameObjectTag == "Blue Player" || gameObject.GameObjectTag == "Red Player")
                gameObject.Transform.AddGravitation();

            string tag = (Input.GetAxis(Control.VerticalAxis, gameObject) == -1) ? "" : "Platform";

            if (gameObject.Collider.CheckIntersection("Wall", tag))
            {
                gameObject.Transform.ResetGravitation();
            }
        }

        public static void SetBullets(string tag, int value)
        {
            if (tag == "Red Player")
            {
                RpBullets += value;
                GameEvents.ChangeBullets?.Invoke(tag, value);
            }
            else
            {
                BpBullets += value;
                GameEvents.ChangeBullets?.Invoke(tag, value);
            }
        }

    }

    /// <summary>
    /// Структура игрового управления персонажа
    /// </summary>
    public struct PlayerControl
    {
        /// <summary>
        /// Горизонтальная ось передвижения
        /// </summary>
        public AxisOfInput HorizontalAxis { get; }
        /// <summary>
        /// Вертикальная ось передвижения
        /// </summary>
        public AxisOfInput VerticalAxis { get; }
        /// <summary>
        /// Кнопка стрельбы
        /// </summary>
        public Key ShootKey { get; }

        public Key ShootKey1 { get; }

        public Key ShootKey2 { get; }
        /// <summary>
        /// Кнопка стрельбы
        /// </summary>
        public Key GetKey { get; private set; }

        /// <summary>
        /// Конструктор структуры
        /// </summary>
        /// <param name="horizontalAxis">Горизонтальная ось передвижения</param>
        /// <param name="verticalAxis"> Вертикальная ось передвижения</param>
        /// <param name="shootKey">Кнопка стрельбы</param>
        public PlayerControl(AxisOfInput horizontalAxis, AxisOfInput verticalAxis, Key shootKey, Key shootKey1, Key shootKey2, Key getKey)
        {
            HorizontalAxis = horizontalAxis;
            VerticalAxis = verticalAxis;
            ShootKey = shootKey;
            ShootKey1 = shootKey1;
            ShootKey2 = shootKey2;
            GetKey = getKey;
        }
    }
}
