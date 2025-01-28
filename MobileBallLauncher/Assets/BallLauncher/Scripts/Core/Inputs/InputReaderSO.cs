using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
[CreateAssetMenu(fileName = "InputReaderSO", menuName = DictionaryScriptableObject.BaseField +
    DictionaryScriptableObject.InptuField + "InputReaderSO", order = DictionaryScriptableObject.InputReaderSOOrder)]
public class InputReaderSO : BaseScriptableObject
{
    public Vector2 CurrentTouchPosition { get; private set; }
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
        Debug.Log("Finger Down");
    }
    private void OnFingerUp(Finger finger)
    {
        Debug.Log("Finger Up");
    }
    private void OnFingerMove(Finger finger)
    {
        CurrentTouchPosition = finger.screenPosition;
        Debug.Log("Finger Move");
    }

}
