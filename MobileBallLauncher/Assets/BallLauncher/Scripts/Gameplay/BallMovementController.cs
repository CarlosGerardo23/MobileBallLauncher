using System;
using BallLauncher.Core.Inputs;
using UnityEngine;
namespace BallLauncher.Gameplay
{
    public class BallMovementController : MonoBehaviour
    {
        [SerializeField] private InputReaderSO _inputReader;
        [SerializeField] private GameObject _ballGameObject;
        private Rigidbody2D _ballRigidbody;
        Camera _camera;
        private void Awake()
        {
            _camera = Camera.main;
            _ballRigidbody = _ballGameObject.GetComponent<Rigidbody2D>();
        }
        private void OnEnable()
        {
            _inputReader.OnFingerMoveScreenPositionEvent += OnFingerMove;
            _inputReader.OnFingerUpEvent += OnFingerUp;
            _inputReader.OnFingerDownEvent += OnFingerDown;
        }
        private void OnDisable()
        {
            _inputReader.OnFingerMoveScreenPositionEvent -= OnFingerMove;
            _inputReader.OnFingerUpEvent -= OnFingerUp;
            _inputReader.OnFingerDownEvent -= OnFingerDown;
        }

        private void OnFingerMove()
        {
            Vector2 screenPosition = _inputReader.FingerPosition;
            Vector3 worldPosition = _camera.ScreenToWorldPoint(screenPosition);
            _ballGameObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0);
        }
        private void OnFingerUp()
        {
            Debug.Log("Finger Up");
            _ballRigidbody.bodyType = RigidbodyType2D.Dynamic;
        }

        private void OnFingerDown()
        {
            _ballRigidbody.bodyType = RigidbodyType2D.Kinematic;
            Vector2 screenPosition = _inputReader.FingerPosition;
            Vector3 worldPosition = _camera.ScreenToWorldPoint(screenPosition);
            _ballGameObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0);
            _ballRigidbody.linearVelocity = Vector2.zero;
        }
    }
}
