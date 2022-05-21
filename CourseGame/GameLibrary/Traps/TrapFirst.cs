using EngineLibrary.ObjectComponents;
using GameLibrary.Game;

namespace GameLibrary.Platformer
{
    public class TrapFirst : ObjectScript
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
                player.ChangeStatsValue(-1);
                //player.IsCanMove = false;
                maze.RemoveObjectFromScene(gameObject);

            }
        }
    }
}
