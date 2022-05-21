using EngineLibrary.EngineComponents;
using EngineLibrary.ObjectComponents;
using SharpDX;
using System;

namespace GameLibrary.Platformer
{
    /// <summary>
    /// Класс игрового менеджера
    /// </summary>
    public class SpawnManager : ObjectScript
    {
        private const float TimeToSpawn = 5f;
        private float currentTimeToSpawn;

        private PlatformerScene platformer;
        private PrizeFactory spawnFactory;

        /// <summary>
        /// Поведение на момент создание игрового объекта
        /// </summary>
        public override void Start()
        {
            platformer = PlatformerScene.instance;
            currentTimeToSpawn = Time.CurrentTime;
        }

        /// <summary>
        /// Обновление игрового объекта
        /// </summary>
        public override void Update()
        {
            if (currentTimeToSpawn < Time.CurrentTime)
            {
                Random random = new Random();
                //int chance = random.Next(0, 101);
                int chance = random.Next(0, 101);

                if (platformer.CountEmptyBlocks() == 0) return;

                Vector2 position = platformer.GetRandomPosition();

                if (chance < 20)
                    spawnFactory = new SpeedPrizeFactory();
                else if (chance > 20 && chance <= 50)
                    spawnFactory = new BolletPowerPrizeFactory();
                else if (chance > 50 && chance <= 80)
                    spawnFactory = new ReloadTimePrizeFactory();
                else
                    spawnFactory = new AmmoPrizeFactory();


                platformer.AddObjectOnScene(spawnFactory.CreatePrize(position));

                currentTimeToSpawn += TimeToSpawn;
            }
        }
    }
}
