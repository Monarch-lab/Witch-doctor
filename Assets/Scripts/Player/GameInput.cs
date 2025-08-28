using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private PlayerInputActions _inputActions;

    private void Awake()
    {
        Instance = this;
        _inputActions = new PlayerInputActions();
        _inputActions.Enable();
    }

    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = _inputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }
}
