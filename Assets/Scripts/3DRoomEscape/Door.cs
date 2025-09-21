using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform doorHinge;
    public float openAngle = 85.0f;
    public float speed = 120.0f;

    private bool unlocked = false;
    private bool isOpen = false;
    private float current = 0.0f;
    
    public void Unlock()
    {
        unlocked = true;
    }

    public void Interact()
    {
        if(unlocked == true)
        {
            isOpen = !isOpen;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float target = isOpen ? openAngle : 0.0f;
        current = Mathf.MoveTowards(current, target, speed * Time.deltaTime);
        doorHinge.localRotation = Quaternion.Euler(0.0f, current, 0.0f);
    }
}
