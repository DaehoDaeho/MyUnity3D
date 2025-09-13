using UnityEngine;

public class FallZoneRespawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.name == "PlayerBall")
        {
            PlayerBallController pbc = other.GetComponent<PlayerBallController>();

            if (pbc != null)
            {
                pbc.RespawnToStart();
            }
        }
    }
}
