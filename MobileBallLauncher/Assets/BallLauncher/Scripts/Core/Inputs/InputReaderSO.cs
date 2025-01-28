using System;
using UnityEngine;
using BallLauncher.Core.ScriptableObjects;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
namespace BallLauncher.Core.Inputs
{
    [CreateAssetMenu(fileName = nameof(InputReaderSO), menuName = DictionaryScriptableObject.BaseField +
        DictionaryScriptableObject.InptuField + nameof(InputReaderSO), order = DictionaryScriptableObject.InputReaderSOOrder)]
    public class InputReaderSO : BaseScriptableObject
    {
        public Vector2 FingerPosition { get; private set; }
        public event Action OnFingerUpEvent;
        public event Action OnFingerDownEvent;
        public event Action OnFingerMoveScreenPositionEvent;
        public bool IsTouching { get; private set; }
        private void OnEnable()
        {
            EnhancedTouchSupport.Enable();
            Touch.onFingerDown += OnFingerDown;
            Touch.onFingerUp += OnFingerUp;
            Touch.onFingerMove += OnFingerMove;
        }

        private void OnDisable()
        {
            EnhancedTouchSupport.Disable();
            Touch.onFingerDown -= OnFingerDown;
            Touch.onFingerUp -= OnFingerUp;
            Touch.onFingerMove -= OnFingerMove;
        }

        private void OnFingerDown(Finger finger)
        {
            IsTouching = true;
            Vector2 position = finger.screenPosition;
            if (!IsWithinGameView(position)) return;
            OnFingerDownEvent?.Invoke();
            FingerPosition = position;
        }
        private void OnFingerUp(Finger finger)
        {
            IsTouching = false;
            OnFingerUpEvent?.Invoke();
        }
        private void OnFingerMove(Finger finger)
        {
            Vector2 position = finger.screenPosition;
            if (!IsWithinGameView(position)) return;
            OnFingerMoveScreenPositionEvent?.Invoke();
            FingerPosition = position;
        }
        private bool IsWithinGameView(Vector2 position)
        {
            return position.x >= 0 && position.x <= Screen.width &&
                   position.y >= 0 && position.y <= Screen.height;
        }

    }
}