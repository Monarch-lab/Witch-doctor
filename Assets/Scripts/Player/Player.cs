using UnityEngine;

[SelectionBase]
public class Player : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 0.3f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();
        inputVector = inputVector.normalized;
        rb.MovePosition(rb.position + inputVector * (moveSpeed + Time.fixedDeltaTime));
    }
} 