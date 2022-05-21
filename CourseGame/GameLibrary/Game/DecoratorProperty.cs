using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Game
{
    public class DecoratorProperty : PlayerProperities
    {
        protected PlayerProperitiesStandart playerProperities;
        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="playerProperities"></param>
        public DecoratorProperty(PlayerProperitiesStandart playerProperities) => this.playerProperities = playerProperities;

        /// <summary>
        /// Запас здоровья игрока
        /// </summary>
        public override int Health { get => playerProperities.Health;  set => playerProperities.SetProperty( TypeProperty.Health,value); }
        /// <summary>
        /// Боезапас
        /// </summary>
        public override int Ammo { get => playerProperities.Ammo; protected set => playerProperities.SetProperty(TypeProperty.Ammo, value); }
        /// <summary>
        /// Скорость
        /// </summary>
        public override float Speed => playerProperities.Speed;

        /// <summary>
        /// Время перезарядки оружия
        /// </summary>
        public override float ReloadTime { get => playerProperities.ReloadTime; set => playerProperities.SetProperty(TypeProperty.ReloadTime, value); }
        /// <summary>
        /// 
        /// </summary>
        public override float Power => playerProperities.Power;

        protected override void DeactivateProperities()
        {
        }
    }
}
