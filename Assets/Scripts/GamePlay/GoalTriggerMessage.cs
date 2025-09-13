using UnityEngine;

public class GoalTriggerMessage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.name == "PlayerBall")
        {
            //Debug.Log("Goal area entered.");
            GameManager gameManager = GameObject.FindAnyObjectByType<GameManager>();
            if (gameManager != null)
            {
                gameManager.ClearGame();
            }
        }
    }
}
