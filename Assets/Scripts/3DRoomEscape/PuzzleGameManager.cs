using UnityEngine;
using TMPro;

public class PuzzleGameManager : MonoBehaviour
{
    public bool powerOn = false;
    public int[] answerOrder = new[] { 0, 1, 2 };
    public Door door;

    public TMP_Text statusText;

    private int progress = 0;

    public void SetPower(bool on)
    {
        powerOn = on;
        progress = 0;

        UpdateStatus();
    }

    void UpdateStatus()
    {
        if(statusText != null)
        {
            if(powerOn == false)
            {
                statusText.text = "Power Off: Pull Lever";
            }
            else
            {
                statusText.text = $"Button Order: {progress}/{answerOrder.Length}";
            }
        }
    }

    public void PressButton(int id)
    {
        if(powerOn == false)
        {
            return;
        }

        int expected = answerOrder[progress];
        if(id == expected)
        {
            progress = progress + 1;
            if(progress >= answerOrder.Length)
            {
                door.Unlock();

                if(statusText != null)
                {
                    statusText.text = "Unlocked: Open the Door [E]";
                }
            }
            else
            {
                UpdateStatus();
            }
        }
        else
        {
            progress = 0;
            UpdateStatus();
        }
    }
}
