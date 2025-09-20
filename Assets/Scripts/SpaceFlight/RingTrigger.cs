using UnityEngine;

public class RingTrigger : MonoBehaviour
{
    private bool consumed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (consumed == true)
        {
            return;
        }

        if (other != null && other.name == "Ship")
        {
            consumed = true;

            SpaceGameManager gm = FindAnyObjectByType<SpaceGameManager>();

            if (gm != null)
            {
                gm.OnPassRing();
            }

            // 시각 피드백: 링 색 바꾸기
            Transform ring = transform.parent;

            if (ring != null)
            {
                Renderer r = ring.GetComponent<Renderer>();

                if (r != null)
                {
                    r.material.color = Color.cyan;
                }
            }
        }
    }
}
