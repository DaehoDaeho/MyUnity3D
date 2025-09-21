using UnityEngine;
using TMPro;

public class InteractCaster : MonoBehaviour
{
    public float distance = 3.0f;
    public LayerMask interactlayer = ~0;
    public TMP_Text interactText;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        bool canInteract = false;
        string label = "";

        if(Physics.Raycast(ray, out hit, distance, interactlayer) == true)
        {
            if (hit.collider.GetComponent<LeverStick>() != null)
            {
                label = "Lever [E]";
                canInteract = true;
            }

            if (hit.collider.GetComponent<ConsoleButton>() != null)
            {
                label = "Button [E]";
                canInteract = true;
            }

            if(hit.collider.GetComponent<Door>() != null)
            {
                label = "Door [E]";
                canInteract = true;
            }

            if(canInteract == true && Input.GetKeyDown(KeyCode.E) == true)
            {
                LeverStick ls = hit.collider.GetComponent<LeverStick>();
                if (ls != null)
                {
                    ls.Interact();
                    return;
                }

                ConsoleButton cb = hit.collider.GetComponent<ConsoleButton>();
                if(cb != null)
                {
                    cb.Interact();
                    return;
                }

                Door door = hit.collider.GetComponent<Door>();
                if(door != null)
                {
                    door.Interact();
                    return;
                }
            }
        }

        if(interactText != null)
        {
            if(canInteract == true)
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
