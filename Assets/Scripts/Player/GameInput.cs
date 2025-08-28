using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private PlayerInputActions playerInputActions;

    // ������� ��� ��������������
    public event EventHandler OnInteractAction;

    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();

        // ������������� �� ������� �����
        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void OnDestroy()
    {
        // ������������ ��� ����������� �������
        playerInputActions.Player.Interact.performed -= Interact_performed;

        playerInputActions.Dispose();
    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }
}

