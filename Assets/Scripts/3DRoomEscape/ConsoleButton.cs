using UnityEngine;

public class ConsoleButton : MonoBehaviour
{
    public PuzzleGameManager manager;
    public int id = 0;
    public float pressDepth = 0.06f;
    public float pressTime = 0.15f;

    private bool animating = false;
    private float t = 0.0f;
    private Vector3 startLocalPos;

    private void Awake()
    {
        startLocalPos = transform.localPosition;
    }

    public void Interact()
    {
        manager.PressButton(id);

        animating = true;
        t = pressTime;
    }

    private void Update()
    {
        if(animating == true)
        {
            float half = pressTime * 0.5f;

            if(t > half)
            {
                float k1 = (pressTime - t) / half;
                transform.localPosition = startLocalPos + new Vector3(0.0f, -pressDepth * k1, 0.0f);
            }
            else
            {
                float k2 = t / half;
                transform.localPosition = startLocalPos + new Vector3(0.0f, -pressDepth * k2, 0.0f);
            }

            t = t - Time.deltaTime;

            if(t <= 0.0f)
            {
                animating = false;
                transform.localPosition = startLocalPos;
            }
        }
    }
}
