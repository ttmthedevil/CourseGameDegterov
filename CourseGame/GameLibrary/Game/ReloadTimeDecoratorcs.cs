using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Game
{
    public class ReloadTimeDecorator : DecoratorProperty
    {
        public ReloadTimeDecorator(PlayerProperitiesStandart playerProperities) : base(playerProperities)
        {

        }

        /// <summary>
        /// Скорость
        /// </summary>
        public override float ReloadTime => playerProperities.ReloadTime / 2;
    }
}
