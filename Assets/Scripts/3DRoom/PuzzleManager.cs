using UnityEngine;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    public bool powerOn = false;          // ������ ����
    public int[] answerOrder = new int[] { 0, 1, 2 }; // 0:Blue, 1:Yellow, 2:Magenta
    public DoorInteract door;             // ���� �� Unlock

    public TMP_Text statusText;           // �ɼ�: ������� ǥ��

    private int progress = 0;

    public void SetPower(bool on)
    {
        powerOn = on;
        progress = 0;

        UpdateStatus();
    }

    public void PressButton(int id)
    {
        if (powerOn == false)
        {
            return;
        }

        int expected = answerOrder[progress];

        if (id == expected)
        {
            progress = progress + 1;

            if (progress >= answerOrder.Length)
            {
                if (door != null)
                {
                    door.Unlock();
                }

                if (statusText != null)
                {
                    statusText.text = "Unlocked: Open The Door[E]";
                }
            }
            else
            {
                UpdateStatus();
            }
        }
        else
        {
            // Ʋ���� ����
            progress = 0;
            UpdateStatus();
        }
    }

    private void UpdateStatus()
    {
        if (statusText != null)
        {
            if (powerOn == false)
            {
                statusText.text = "Lamp OFF: Pull Lever";
            }
            else
            {
                statusText.text = $"Buttons Order: {progress}/{answerOrder.Length}";
            }
        }
    }
}
