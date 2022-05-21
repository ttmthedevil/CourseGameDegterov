using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Game
{
    public class SpeedDecorator : DecoratorProperty
    {
        public SpeedDecorator(PlayerProperitiesStandart playerProperities) : base(playerProperities)
        {

        }

        /// <summary>
        /// Скорость
        /// </summary>
        public override float Speed => playerProperities.Speed * 1.5f;

        protected override void DeactivateProperities() => player.SetProperty(new PlayerProperitiesStandart());
    }
}
