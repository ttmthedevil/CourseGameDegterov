using EngineLibrary.ObjectComponents;
using GameLibrary.Game;

namespace GameLibrary.Platformer
{
    public class TrapSecond : ObjectScript
    {
        private PlatformerScene maze;
        /// <summary>
        /// Поведение на момент создание игрового объекта
        /// </summary>
        public override void Start()
        {
            maze = PlatformerScene.instance;
        }

        /// <summary>
        /// Обновление игрового объекта
        /// </summary>
        public override void Update()
        {
            if (gameObject.Collider.CheckIntersection(out Player player))
            {
                player.Property.ReloadTime = 2.0f;
                //player.IsCanMove = false;
                maze.RemoveObjectFromScene(gameObject);

            }
        }
    }
}
