using System;
using _Hereos;
using Unity.Netcode;
using UnityEngine;

namespace _Controllers
{
    internal class InputControl : NetworkBehaviour // Values
    {
        // ==> Components
        [SerializeField] private HeroMain heroMain;
        [SerializeField] private SpriteRenderer spriteRenderer;

        [SerializeField] private Transform player;

        // ==> Values
        private static float _horizontalInput;

        private Vector3 NetworkPosition;

        // ==> Enums
        private enum InputEnum : byte
        {
            GoToLeft,
            GoToRight,
            GoToUp,
            GoToDown,
            Idle,
        }
        
        // ==> Main Functions
        private void MovingInput()
        {
            if (_Input(KeyCode.A)) InputController(InputEnum.GoToLeft);
            else if (_Input(KeyCode.D)) InputController(InputEnum.GoToRight);
            else if (_Input(KeyCode.W)) InputController(InputEnum.GoToUp);
            else if (_Input(KeyCode.S)) InputController(InputEnum.GoToDown);
            else InputController(InputEnum.Idle); // Idle Anim
        }

        private void InputController(InputEnum expression)
        {
            switch (expression)
            {
                case InputEnum.GoToLeft:
                    TurnFaceToRight(true);
                    heroMain.Move();
                    break;
                case InputEnum.GoToRight:
                    TurnFaceToRight(false);
                    heroMain.Move();
                    break;
                case InputEnum.GoToUp:
                    heroMain.Move();
                    break;
                case InputEnum.GoToDown:
                    heroMain.Move();
                    break;
                case InputEnum.Idle:
                    IdleAnim();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(expression), expression, null);
            }
        }
        
        // ==> Unity Event Functions
        private void Update()
        {
                heroMain._isMoving();
                MovingInput();
        }

        // ==> Little Functions
        private static bool _Input(KeyCode keyCode) // todo: Get Axis ile al (2. fonksion öyle olsun), öyle alırsan daha çok süpürgeyle uçuyor hissiyatı oluşturuyor.
        {
            var pressTheButton = Input.GetKey(keyCode);
            return pressTheButton;
        }

        private void TurnFaceToRight(bool isTurnToLeft) 
        {
            // if (Input.GetAxis("Horizontal") is < 0.1f and > -0.1f) // if koşulunun nedeni: saliselik Animasyon buglarını engelliyor.
                // _isFaceLookingToRight = isTurnToLeft;
        }

        private void IdleAnim()
        {
            // animationsControl.IdleAnim();
        }

    }
}