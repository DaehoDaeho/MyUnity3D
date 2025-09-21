using UnityEngine;

public class LeverStick : MonoBehaviour
{
    public PuzzleGameManager manager;
    public Transform handleToRotate;
    public float onAngle = 40.0f;
    public float offAngle = -40.0f;

    private bool isOn = false;

    public void Interact()
    {
        isOn = !isOn;

        if(handleToRotate != null)
        {
            float a = isOn ? onAngle : offAngle;
            handleToRotate.localRotation = Quaternion.Euler(a, 0.0f, 0.0f);
        }

        manager.SetPower(isOn);

        Renderer lamp = GameObject.Find("PowerLamp")?.GetComponent<Renderer>();
        if(lamp != null)
        {
            Color c = isOn ? Color.green : Color.gray;
            lamp.material.color = c;
        }
    }
}
