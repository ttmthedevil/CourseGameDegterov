using EngineLibrary.EngineComponents;
using EngineLibrary.ObjectComponents;
using GameLibrary.Game;
using GameLibrary.Guns;
using SharpDX;

namespace GameLibrary.Platformer
{
    /// <summary>
    /// Класс фабрики создания элементов лабиринта 
    /// </summary>
    public class PlatformerElementsFactory
    {
        /// <summary>
        /// Создает элемент лабиринта
        /// </summary>
        /// <param name="position">Позиция объекта на сцене</param>
        /// <param name="tagName">Тег игрового объекта</param>
        /// <returns>Созданный игровой объект</returns>
        public GameObject CreatePlatformerElement(Vector2 position, string tagName)
        {
            GameObject gameObject = new GameObject();
            gameObject.InitializeObjectComponent(new TransformComponent(position, new Size2F(1f, 1f)));
            gameObject.InitializeObjectComponent(new SpriteComponent(RenderingSystem.LoadBitmap("Resources/MazeElements/" + tagName + ".png")));

            switch (tagName)
            {
                case "Platform":
                    gameObject.InitializeObjectComponent(new ColliderComponent(gameObject, new Size2F(1f, 0.1f), new Vector2(0, -0.5f)));
                    break;
                case "Stair":
                case "Wall":
                    gameObject.InitializeObjectComponent(new ColliderComponent(gameObject, new Size2F(1f, 1f)));
                    break;
                default:
                    gameObject.InitializeObjectComponent(new ColliderComponent(gameObject, new Size2F(1f, 1f)));
                    break;
            }

            gameObject.GameObjectTag = tagName;

            //if (TagName == "BreakWall")
            //    gameObject.InitializeObjectScript(new BreakWall());

            return gameObject;
        }

        /// <summary>
        /// Создание монет в лабиринте
        /// </summary>
        /// <param name="position">Позиция объекта на сцене</param>
        /// <returns>Игровой объект</returns>
        public GameObject CreateHealthKit(Vector2 position)
        {
            GameObject gameObject = new GameObject();
            gameObject.InitializeObjectComponent(new TransformComponent(position, new Size2F(1f, 1f)));
            gameObject.InitializeObjectComponent(new SpriteComponent(RenderingSystem.LoadBitmap("Resources/MazeElements/HealthKit.png")));
            gameObject.InitializeObjectComponent(new ColliderComponent(gameObject, new Size2F(1f, 1f)));

            gameObject.GameObjectTag = "HealthKit";

            gameObject.InitializeObjectScript(new HealthKit());

            return gameObject;
        }

        public GameObject CreateTrap(Vector2 position)
        {
            GameObject gameObject = new GameObject();
            gameObject.InitializeObjectComponent(new TransformComponent(position, new Size2F(1f, 1f)));
            gameObject.InitializeObjectComponent(new SpriteComponent(RenderingSystem.LoadBitmap("Resources/MazeElements/Treasure.png")));
            gameObject.InitializeObjectComponent(new ColliderComponent(gameObject, new Size2F(1f, 1f)));

            gameObject.GameObjectTag = "HealthKit";

            gameObject.InitializeObjectScript(new TrapFirst());

            return gameObject;
        }

        public GameObject CreateTrap2(Vector2 position)
        {
            GameObject gameObject = new GameObject();
            gameObject.InitializeObjectComponent(new TransformComponent(position, new Size2F(1f, 1f)));
            gameObject.InitializeObjectComponent(new SpriteComponent(RenderingSystem.LoadBitmap("Resources/MazeElements/Stair.png")));
            gameObject.InitializeObjectComponent(new ColliderComponent(gameObject, new Size2F(1f, 1f)));

            gameObject.GameObjectTag = "HealthKit";

            gameObject.InitializeObjectScript(new TrapSecond());

            return gameObject;
        }
    }
}
