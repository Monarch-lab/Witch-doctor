using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Interaction Settings")]
    [SerializeField] private float interactionRange = 2f;
    [SerializeField] private LayerMask interactableLayer;

    private void Start()
    {
        // ������������� �� ������� �����
        GameInput.Instance.OnInteractAction += GameInput_OnInteractAction;
    }

    private void OnDestroy()
    {
        // ������������ ��� �����������
        if (GameInput.Instance != null)
        {
            GameInput.Instance.OnInteractAction -= GameInput_OnInteractAction;
        }
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        TryInteract();
    }

    private void TryInteract()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionRange, interactableLayer);

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact(this);
                break; // ��������������� ������ � ������ ��������
            }
        }
    }

    // ������������ ������� �������������� � ���������
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
