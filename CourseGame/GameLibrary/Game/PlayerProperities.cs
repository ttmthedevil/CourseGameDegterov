using EngineLibrary.EngineComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Game
{
    public abstract class PlayerProperities
    {
        protected Player player;

        protected float timeDeactivate = 2;
        protected float timer = 0;

        /// <summary>
        /// Запас здоровья игрока
        /// </summary>
        public abstract int Health { get;  set; }
        /// <summary>
        /// Боезапас
        /// </summary>
        public abstract int Ammo { get; protected set; }
        /// <summary>
        /// Скорость
        /// </summary>
        public abstract float Speed { get; }
        /// <summary>
        /// Время перезарядки оружия
        /// </summary>
        public abstract float ReloadTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public abstract float Power { get; }

        public virtual void SetPlayer(Player player) => this.player = player;

        public virtual void SetProperty(TypeProperty type, float value)
        {
            switch (type)
            {
                case TypeProperty.Health:
                    Health = (int)value;
                    break;
                case TypeProperty.Ammo:
                    Ammo = (int)value;
                    break;
                case TypeProperty.Speed:
                    break;
                case TypeProperty.ReloadTime:
                    break;
                case TypeProperty.Power:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public virtual void UpdateTime()
        {
            timer += Time.DeltaTime;

            if (timer >= timeDeactivate)
            {
                timer = 0;
                DeactivateProperities();
            }
        }

        protected abstract void DeactivateProperities();
    }
}
