using UnityEngine;

public class CameraFollowSimple : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 6f, -8f);
    public float followLerp = 8f;
    public float lookLerp = 12f;

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 wantedPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, wantedPos, followLerp * Time.deltaTime);

            Vector3 lookPos = new Vector3(target.position.x, target.position.y, target.position.z);

            Quaternion wantedRot = Quaternion.LookRotation(lookPos - transform.position, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRot, lookLerp * Time.deltaTime);
        }
    }
}
