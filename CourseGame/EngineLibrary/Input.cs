using EngineLibrary.ObjectComponents;
using SharpDX.DirectInput;
using System;

namespace EngineLibrary.EngineComponents
{
    /// <summary>
    /// Класс, позволяющий управлять вводом с клавиатуры
    /// </summary>
    public static class Input
    {
        private static InputHandler _inputHandler;
        public static bool CanJump { get; set; } = true;

        /// <summary>
        /// Установка обработчика ввода с клавиатуры
        /// </summary>
        /// <param name="input">Обработчик ввода с клавиатуры</param>
        public static void SetupInputHandler(InputHandler input) => _inputHandler = input;

        /// <summary>
        /// Метод, возращающий значение ввода основных осей направления
        /// </summary>
        /// <param name="axis">Ось направления</param>
        /// <returns>Положительное или отрицательное значение оси</returns>
        public static int GetAxis(AxisOfInput axis, GameObject gameObject)
        {
            if (_inputHandler != null)
            {
                int move = 0;

                if (_inputHandler.KeyboardUpdated)
                {
                    switch (axis)
                    {
                        case AxisOfInput.Horizontal:
                            if (_inputHandler.KeyboardState.IsPressed(Key.D))
                            {
                                move++;

                                //gameObject.Transform.IsUseGravitation = true;
                            }

                            if (_inputHandler.KeyboardState.IsPressed(Key.A))
                            {
                                move--;

                                // gameObject.Transform.IsUseGravitation = true;
                            }

                            break;
                        case AxisOfInput.Vertical:
                            if (_inputHandler.KeyboardState.IsPressed(Key.W) && CanJump)
                            {
                                move += 1;
                                //if (move == 2)
                                //{
                                //    move -= 5;
                                //}
                            }
                            else
                            {
                                move -= 1;
                                gameObject.Transform.IsUseGravitation = true;
                                
                            }

                            break;
                        case AxisOfInput.AlternativeHorizontal:
                            if (_inputHandler.KeyboardState.IsPressed(Key.Right))
                            {
                                move++;

                                //gameObject.Transform.IsUseGravitation = true;
                            }

                            if (_inputHandler.KeyboardState.IsPressed(Key.Left))
                            {
                                move--;

                                //gameObject.Transform.IsUseGravitation = true;
                            }

                            break;
                        case AxisOfInput.AlternativeVertical:
                            if (_inputHandler.KeyboardState.IsPressed(Key.Up) && CanJump)
                            {
                                move += 1;
                                //if (move > 5)
                                //{
                                //    move--;
                                //    gameObject.Transform.IsUseGravitation = true;
                                //}
                            }
                            else
                            {
                                move -= 1;
                                gameObject.Transform.IsUseGravitation = true;
                                
                            }

                            //if (inputHandler.KeyboardState.IsPressed(Key.Down)) move--;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(axis), axis, null);
                    }
                }

                return move;
            }

            return 0;
        }

        /// <summary>
        /// Метод, возращающий реакцию на нажатие клавиши ввода
        /// </summary>
        /// <param name="key">Клавиша ввода</param>
        /// <returns>Реакция true или false</returns>
        public static bool GetButtonDawn(Key key) =>
            _inputHandler != null &&
            (_inputHandler.KeyboardUpdated && _inputHandler.KeyboardState.IsPressed(key));
    }

    /// <summary>
    /// Ось направления ввода
    /// </summary>
    public enum AxisOfInput
    {
        /// <summary>
        /// Горизонтальная ось
        /// </summary>
        Horizontal = 0,
        /// <summary>
        /// Вертикальная ось
        /// </summary>
        Vertical = 1,
        /// <summary>
        /// Альтернативная горизонтальная ось
        /// </summary>
        AlternativeHorizontal = 2,
        /// <summary>
        /// Альтернативная вертикальная ось 
        /// </summary>
        AlternativeVertical = 3,
    }
}
