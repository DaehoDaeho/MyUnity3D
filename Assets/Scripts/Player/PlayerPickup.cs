using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.CompareTag("Coin") == true)
        {
            GameManager gm = FindAnyObjectByType<GameManager>();

            if (gm != null)
            {
                gm.AddScore(coinValue);
            }

            other.gameObject.SetActive(false);
        }
    }
}
