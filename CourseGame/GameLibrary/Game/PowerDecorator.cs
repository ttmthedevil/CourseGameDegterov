using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Game
{
    public class PowerDecorator : DecoratorProperty
    {
        public PowerDecorator(PlayerProperitiesStandart playerProperities) : base(playerProperities)
        {

        }

        /// <summary>
        /// Скорость
        /// </summary>
        public override float Power => playerProperities.Power * 2;
    }
}
