using EngineLibrary.ObjectComponents;
using GameLibrary.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Platformer
{
    /// <summary>
    /// Класс аптечки
    /// </summary>
    public class HealthKit : ObjectScript
    {
        private PlatformerScene platformer;

        /// <summary>
        /// Поведение на момент создание игрового объекта
        /// </summary>
        public override void Start() => platformer = PlatformerScene.instance;

        /// <summary>
        /// Обновление игрового объекта
        /// </summary>
        public override void Update()
        {
            if (gameObject.Collider.CheckIntersection(out Player player) && player.Property.Health < 3)
            {
                player.ChangeStatsValue(1);
                platformer.RemoveObjectFromScene(gameObject);
            }
        }
    }
}
