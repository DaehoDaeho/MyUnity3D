using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    public Transform door;         // 실제 도어 메쉬(자식)
    public float openAngle = 85f;  // Y축 기준 열림
    public float speed = 120f;

    private bool unlocked = false;
    private bool isOpen = false;
    private float current = 0f;    // 현재 Y 회전(도어의 local Y)

    public void Unlock()
    {
        unlocked = true;
    }

    public void Interact()
    {
        if (unlocked == false)
        {
            return;
        }

        isOpen = !isOpen;
    }

    private void Update()
    {
        float target = isOpen ? openAngle : 0f;
        current = Mathf.MoveTowards(current, target, speed * Time.deltaTime);

        if (door != null)
        {
            door.localRotation = Quaternion.Euler(0f, -current, 0f);
        }
    }
}
