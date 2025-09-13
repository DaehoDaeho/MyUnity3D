using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBallController : MonoBehaviour
{
    [Header("Move")]
    public float acceleration = 25f;
    public float maxHorizontalSpeed = 8f;

    [Header("Respawn")]
    public Vector3 startPosition = new Vector3(-4f, 0.6f, -4f);
    public float fallY = -3.0f;

    [Header("Camera-Relative")]
    public Transform cameraTransform;

    private Rigidbody rb;
    private float inputX = 0f;
    private float inputZ = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody is missing on PlayerBall.");
        }

        if (cameraTransform == null)
        {
            Camera cam = Camera.main;

            if (cam != null)
            {
                cameraTransform = cam.transform;
            }
        }
    }

    private void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputZ = Input.GetAxisRaw("Vertical");

        if (transform.position.y < fallY)
        {
            //RespawnToStart();
        }
    }

    private void FixedUpdate()
    {
        Vector3 dir = new Vector3(inputX, 0f, inputZ);

        if (cameraTransform != null)
        {
            Vector3 camForward = cameraTransform.forward;
            Vector3 camRight = cameraTransform.right;

            camForward.y = 0f;
            camRight.y = 0f;

            camForward = camForward.normalized;
            camRight = camRight.normalized;

            dir = (camForward * inputZ) + (camRight * inputX);
        }

        if (dir.sqrMagnitude > 1f)
        {
            dir = dir.normalized;
        }

        rb.AddForce(dir * acceleration, ForceMode.Acceleration);

        Vector3 v = rb.linearVelocity;

        Vector3 vHoriz = new Vector3(v.x, 0f, v.z);
        float speed = vHoriz.magnitude;

        if (speed > maxHorizontalSpeed)
        {
            Vector3 vHorizClamped = vHoriz.normalized * maxHorizontalSpeed;
            rb.linearVelocity = new Vector3(vHorizClamped.x, v.y, vHorizClamped.z);
        }
    }

    public void RespawnToStart()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startPosition;
    }
}
