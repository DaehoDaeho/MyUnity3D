using UnityEngine;
using TMPro;

public class InteractRaycaster : MonoBehaviour
{
    public float distance = 3.0f;
    public LayerMask interactLayer = ~0; // ����
    public TMP_Text interactText;

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        bool canInteract = false;
        string label = "";

        if (Physics.Raycast(ray, out hit, distance, interactLayer) == true)
        {
            // ��� Ư�� ��ȣ�ۿ� ��ũ��Ʈ�� �޷� �ִ��� Ȯ��
            if (hit.collider.GetComponent<LeverInteract>() != null)
            {
                label = "Lever [E]";
                canInteract = true;
            }

            if (hit.collider.GetComponent<ButtonInteract>() != null)
            {
                label = "Button [E]";
                canInteract = true;
            }

            if (hit.collider.GetComponent<DoorInteract>() != null)
            {
                label = "Door [E]";
                canInteract = true;
            }

            if (canInteract == true && Input.GetKeyDown(KeyCode.E) == true)
            {
                // �켱����: ���� �� ��ư �� ��
                LeverInteract li = hit.collider.GetComponent<LeverInteract>();

                if (li != null)
                {
                    li.Interact();
                    return;
                }

                ButtonInteract bi = hit.collider.GetComponent<ButtonInteract>();

                if (bi != null)
                {
                    bi.Interact();
                    return;
                }

                DoorInteract di = hit.collider.GetComponent<DoorInteract>();

                if (di != null)
                {
                    di.Interact();
                    return;
                }
            }
        }

        if (interactText != null)
        {
            if (canInteract == true)
            {
                interactText.text = label;
            }
            else
            {
                interactText.text = "";
            }
        }
    }
}
