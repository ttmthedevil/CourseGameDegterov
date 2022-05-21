using EngineLibrary.EngineComponents;
using EngineLibrary.ObjectComponents;
using SharpDX;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using GameLibrary.Game;
using GameLibrary.Guns;

namespace GameLibrary.Platformer
{
    /// <summary>
    /// Класс лабиринта
    /// </summary>
    public class PlatformerScene : Scene
    {
        /// <summary>
        /// Статическая ссылка на класс
        /// </summary>
        public static PlatformerScene instance = null;
        /// <summary>
        /// Фабрика создания элементов лабиринта
        /// </summary>
        public PlatformerElementsFactory ElementsFactory { get; private set; }
        /// <summary>
        /// Конструктор синего игрока
        /// </summary>
        public PlayerConstructor BluePlayerFactory { get; set; }
        /// <summary>
        /// Конструктор красного игрока
        /// </summary>
        public PlayerConstructor RedPlayerFactory { get; set; }

        private readonly List<Vector2> emptyBlocks = new List<Vector2>();
        public int countOfHealthKits = 0;
        public int countOfTraphKits = 0;
        public int CountEmptyBlocks() => emptyBlocks.Count;

        /// <summary>
        /// Создание игровых объектов на сцене
        /// </summary>

        protected override void CreateGameObjectsOnScene()
        {
            if (instance == null)
                instance = this;

            ElementsFactory = new PlatformerElementsFactory();
            BluePlayerFactory = new PlayerConstructor();
            RedPlayerFactory = new PlayerConstructor();

            GameObject gameObject = new GameObject();
            gameObject.InitializeObjectComponent(new TransformComponent(new Vector2(0f, 0f), new Size2F(27, 15)));
            gameObject.InitializeObjectComponent(new SpriteComponent(RenderingSystem.LoadBitmap("Resources/Фон.png")));
            gameObject.GameObjectTag = "Background";

            gameObjects.Add(gameObject);

            gameObject = new GameObject();
            gameObject.InitializeObjectComponent(new TransformComponent(new Vector2(0f, 0f), new Size2F(1, 1)));
            gameObject.GameObjectTag = "GameManager";
            gameObject.InitializeObjectScript(new SpawnManager());

            gameObjects.Add(gameObject);

            CreatePlatformer();

            GameObject player = BluePlayerFactory.CreatePlayer("Blue Player");

            gameObjects.Add(player);
            gameObjects.Add(BluePlayerFactory.CreateGun(new DamageGun(), "damage"));

            player = RedPlayerFactory.CreatePlayer("Red Player");

            gameObjects.Add(player);
            gameObjects.Add(RedPlayerFactory.CreateGun(new DamageGun(), "damage"));
        }

        /// <summary>
        /// Метод создания лабиринта
        /// </summary>
        public void CreatePlatformer()
        {
            Random random = new Random();

            string text = "Resources/Mazes/Maze " + 1 + ".bmp";

            Bitmap bitmap = new Bitmap(text);

            for (var i = 0; i < bitmap.Height; i++)
            {
                for (var j = 0; j < bitmap.Width; j++)
                {
                    System.Drawing.Color color = bitmap.GetPixel(j, i);

                    GameObject gameObject = null;

                    if (color.R == 0 && color.G == 0 && color.B == 0)
                        gameObject = ElementsFactory.CreatePlatformerElement(new Vector2(j, i), "Wall");
                    else if (color.R == 0 && color.G == 255 && color.B == 0)
                        gameObject = ElementsFactory.CreatePlatformerElement(new Vector2(j, i), "Platform");
                    else if (color.R == 0 && color.G == 0 && color.B == 255)
                        gameObject = ElementsFactory.CreatePlatformerElement(new Vector2(j, i), "Stair");
                    else if (color.R == 255 && color.G == 255 && color.B == 0)
                    {
                        gameObject = ElementsFactory.CreateHealthKit(new Vector2(j, i));
                        countOfHealthKits++;
                    }
                    else if (color.R == 255 && color.G == 0 && color.B == 0)
                    {
                        gameObject = ElementsFactory.CreateTrap(new Vector2(j, i));
                        countOfTraphKits++;
                    }
                    else if (color.R == 0 && color.G == 220 && color.B == 255)
                    {
                        gameObject = ElementsFactory.CreateTrap2(new Vector2(j, i));
                        countOfTraphKits++;
                    }
                    else if (color.R == 125 && color.G == 0 && color.B == 0)
                        RedPlayerFactory.StartPosition = new Vector2(j, i);
                    else if (color.R == 0 && color.G == 0 && color.B == 125)
                        BluePlayerFactory.StartPosition = new Vector2(j, i);
                    else
                        emptyBlocks.Add(new Vector2(j, i));

                    if (gameObject != null)
                        gameObjects.Add(gameObject);
                }
            }
        }

        /// <summary>
        /// Добавление объекта в лист отрисовки
        /// </summary>
        /// <param name="gameObject">Игровой объект</param>
        public void AddObjectOnScene(GameObject gameObject) => gameObjectsToAdd.Add(gameObject);

        /// <summary>
        /// Удаления объекта из листа отрисовки
        /// </summary>
        /// <param name="gameObject">Игровой объект</param>
        public void RemoveObjectFromScene(GameObject gameObject)
        {

            if (gameObject.GameObjectTag == "Spawn")
                emptyBlocks.Add(gameObject.Transform.Position);

            gameObjectsToRemove.Add(gameObject);

            foreach (var monsterObject in gameObjects.Where(monsterObject => monsterObject.Script is Player).Where(monsterObject => ((Player) monsterObject.Script).Property.Health == 0))
            {
                EndScene();
            }

        }

        /// <summary>
        /// Рандомное место в лабиринте
        /// </summary>
        /// <returns>Позицию</returns>
        public Vector2 GetRandomPosition()
        {
            Random random = new Random();

            int index = random.Next(0, emptyBlocks.Count);

            Vector2 position = emptyBlocks[index];

            emptyBlocks.Remove(position);

            return position;
        }

        /// <summary>
        /// Поведение при завершении сцены
        /// </summary>
        protected override void EndScene()
        {
            base.EndScene();

            string winPlayer;

            //if(Player.BPCoins < Player.RPCoins)
            //    winPlayer = RedPlayerFactory.PlayerTag;
            //else
            //    winPlayer = BluePlayerFactory.PlayerTag;

            //GameEvents.EndGame?.Invoke(winPlayer);
        }
    }
}
