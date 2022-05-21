using EngineLibrary.EngineComponents;
using EngineLibrary.ObjectComponents;
using GameLibrary.Game;
using GameLibrary.Guns;

namespace GameLibrary.Platformer
{
    /// <summarymaze
    /// Класс подбираемого оружия в лабиринте
    /// </summary>
    public class PrizeSpawn : ObjectScript
    {
        private PlatformerScene maze;
        private PlayerProperities dropOutPrize;
        private float cuurentTimeToDisappear;

        /// <summary>
        /// Инициализация места подбираемого оружия
        /// </summary>
        /// <param name="name">Название оружия</param>
        /// <param name="gun">Подбираемое оружие</param>
        /// <param name="disappearTime">Время исчезнование места</param>
        public void InitializeGunSpawn(PlayerProperities playerProperities, float disappearTime)
        {
            dropOutPrize = playerProperities;
            cuurentTimeToDisappear = Time.CurrentTime + disappearTime;
        }

        // <summary>
        /// Инициализация места подбираемого оружия
        /// </summary>
        /// <param name="name">Название оружия</param>
        /// <param name="gun">Подбираемое оружие</param>
        /// <param name="disappearTime">Время исчезнование места</param>
        public void InitializeGunSpawn(float disappearTime) => cuurentTimeToDisappear = Time.CurrentTime + disappearTime;

        /// <summary>
        /// Поведение на момент создание игрового объекта
        /// </summary>
        public override void Start() => maze = PlatformerScene.instance;

        /// <summary>
        /// Обновление игрового объекта
        /// </summary>
        public override void Update()
        {
            if(cuurentTimeToDisappear < Time.CurrentTime)
            {
                maze.RemoveObjectFromScene(gameObject);
            }

            if(gameObject.Collider.CheckIntersection(out var player,"Blue Player","Red Player"))
            {
                switch (player.GameObjectTag)
                {
                    case "Blue Player" when Input.GetButtonDawn(((Player) player.Script).Control.GetKey):
                    {
                        switch (dropOutPrize)
                        {
                            case null:
                                ((Player) player.Script)?.Property.SetProperty(TypeProperty.Ammo, 25);
                                break;
                            default:
                                ((Player) player.Script)?.SetProperty(dropOutPrize);
                                break;
                        }

                        maze.RemoveObjectFromScene(gameObject);
                        break;
                    }
                    case "Red Player" when Input.GetButtonDawn(((Player) player.Script).Control.GetKey):
                    {
                        switch (dropOutPrize)
                        {
                            case null:
                                ((Player) player.Script)?.Property.SetProperty(TypeProperty.Ammo, 25);
                                break;
                            default:
                                ((Player) player.Script)?.SetProperty(dropOutPrize);
                                break;
                        }

                        maze.RemoveObjectFromScene(gameObject);
                        break;
                    }
                }
            }
        }
    }
}
