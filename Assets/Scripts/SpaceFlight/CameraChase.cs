using UnityEngine;

public class CameraChase : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 2f, -6f);
    public float followLerp = 6f;
    public float lookLerp = 10f;

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 wanted = target.TransformPoint(offset);
            transform.position = Vector3.Lerp(transform.position, wanted, followLerp * Time.deltaTime);

            Quaternion wantedRot = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRot, lookLerp * Time.deltaTime);
        }
    }
}
