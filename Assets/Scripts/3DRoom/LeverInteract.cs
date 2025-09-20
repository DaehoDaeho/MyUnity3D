using UnityEngine;

public class LeverInteract : MonoBehaviour
{
    public PuzzleManager manager;
    public Transform handleToRotate; // 레버 스틱(자기 자신)
    public float onAngle = 40f;
    public float offAngle = -40f;

    private bool isOn = false;

    public void Interact()
    {
        isOn = !isOn;

        if (handleToRotate != null)
        {
            float a = isOn ? onAngle : offAngle;
            handleToRotate.localRotation = Quaternion.Euler(a, 0f, 0f);
        }

        if (manager != null)
        {
            manager.SetPower(isOn);
        }

        // 전원 램프 색 변경(있다면)
        Renderer lamp = GameObject.Find("PowerLamp")?.GetComponent<Renderer>();

        if (lamp != null)
        {
            Color c = isOn ? Color.green : Color.gray;
            lamp.material.color = c;
        }
    }
}
