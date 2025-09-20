using UnityEngine;
using TMPro;

public class SpaceGameManager : MonoBehaviour
{
    public TMP_Text infoText;
    public GameObject winPanel;
    public Rigidbody shipRb;
    public int totalRings = 5;

    private int passed = 0;
    private float timeElapsed = 0f;
    private bool cleared = false;

    private void Start()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }

        UpdateInfo(0f);
    }

    private void Update()
    {
        if (cleared == false)
        {
            timeElapsed = timeElapsed + Time.deltaTime;
            UpdateInfo(timeElapsed);
        }
    }

    public void OnPassRing()
    {
        if (cleared == true)
        {
            return;
        }

        passed = passed + 1;

        if (passed >= totalRings)
        {
            cleared = true;

            if (winPanel != null)
            {
                winPanel.SetActive(true);
            }

            Time.timeScale = 0f;
        }
    }

    private void UpdateInfo(float t)
    {
        if (infoText != null)
        {
            float speed = 0f;

            if (shipRb != null)
            {
                speed = shipRb.linearVelocity.magnitude;
            }

            infoText.text = $"Rings: {passed}/{totalRings}   Time: {t:0.0}s   Speed: {speed:0.0}";
        }
    }
}
