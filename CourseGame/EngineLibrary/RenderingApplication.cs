using System;
using System.Drawing;
using SharpDX.Windows;
using SharpDX.Direct2D1;
using System.Windows.Forms;

namespace EngineLibrary.EngineComponents
{
    /// <summary>
    /// Класс отрисовки и обновление всех процессов
    /// </summary>
    public class RenderingApplication : IDisposable
    {
        private const float UnitsPerHeight = 15.0f;

        private const int WidthOfApplication = 1280;
        private const int HeightOfApplication = 720;

        private readonly WindowRenderTarget renderTarget;

        private readonly RenderingSystem rendering;
        private readonly InputHandler input;
        private Scene scene;

        /// <summary>
        /// Форма отрисовки
        /// </summary>
        public RenderForm RenderForm { get; set; }

        /// <summary>
        /// Конструктор класса, инциализирующий его компоненты
        /// </summary>
        public RenderingApplication()
        {
            RenderForm = new RenderForm("Game");
            RenderForm.ClientSize = new Size(WidthOfApplication, HeightOfApplication);
            RenderForm.TopLevel = true;
            RenderForm.AllowUserResizing = true;
            RenderForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            rendering = new RenderingSystem(RenderForm);
            renderTarget = rendering.RenderTarget;
            input = new InputHandler(RenderForm);
            Input.SetupInputHandler(input);
        }

        /// <summary>
        /// Установка игровой сцены
        /// </summary>С
        /// <param name="targetScene"></param>
        public void SetScene(Scene targetScene)
        {
            scene = targetScene;
            scene.InitializeScene(renderTarget, RenderForm.ClientSize.Height / UnitsPerHeight);
        }

        /// <summary>
        /// Запуск приложения
        /// </summary>
        public void Run() => RenderLoop.Run(RenderForm, RenderCallback);

        /// <summary>
        /// Формирование каждого кадра
        /// </summary>
        private void RenderCallback()
        {
            input.UpdateKeyboardState();
            Time.UpdateTime();
            renderTarget.BeginDraw();
            renderTarget.Clear(SharpDX.Color.Black);
            scene.DrawScene();
            renderTarget.EndDraw();
            if (!scene.isDrawScene) Dispose();
        }

        /// <summary>
        /// Освобождение ресурсов
        /// </summary>
        public void Dispose()
        {
            RenderForm.Dispose();
            rendering.Dispose();
            input.Dispose();
        }
    }
}
