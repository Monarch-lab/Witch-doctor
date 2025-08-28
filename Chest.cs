using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private bool isOpen = false;

    public void Interact(PlayerController player)
    {
        if (!isOpen)
        {
            OpenChest();
        }
        else
        {
            CloseChest();
        }
    }

    private void OpenChest()
    {
        isOpen = true;
        Debug.Log("������ ������!");
        // ����� ������ ��������: ��������, ��������� ���� � �.�.
    }

    private void CloseChest()
    {
        isOpen = false;
        Debug.Log("������ ������!");
    }
}