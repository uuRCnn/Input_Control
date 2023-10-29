using _Controllers;
using _Hereos.Skills;
using _Utility;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using Input = UnityEngine.Input;
using Vector2 = UnityEngine.Vector2;

namespace _Hereos
{
    internal class HeroMain : NetworkBehaviour
    {
        // ==> Components <==

        // -> Player <-
        [SerializeField] private Transform playerTransform;
        [SerializeField] private GameObject parrentObject;

        private Vector2 _movedirection;
        private Vector2 _lastPosition;

        // -> UI
        [SerializeField] private GameObject ownerCanvas;
        [SerializeField] private GameObject skillUI;
        [SerializeField] private GameObject healthposition;

        // ==> Values 
        public static bool IsMoving;
        private const float Speed = 6f;

        
        // ==> Unity Event Functions
        private void Awake()
        {
            _lastPosition = transform.position;
        }

        // ==> Litle Functions

        public void _isMoving()
        {
            Vector2 position = transform.position;
            IsMoving = position != _lastPosition; // bool
            _lastPosition = position;
        }

        private void WalkAnimation()
        {
            // todo: animationsControl.WalkAnim();
        }

        private void MoveHere()
        {
            playerTransform.Translate(_movedirection * (Time.deltaTime * Speed));
        }

        private void CalculateDirection()
        {
            _movedirection = Vector2.right * Input.GetAxis("Horizontal") + Vector2.up * Input.GetAxis("Vertical");
        }

        public void Move()
        {
            CalculateDirection();
            MoveHere();
            WalkAnimation();
        }
    }
}