using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipController : MonoBehaviour
{
    [Header("Thrust / Turn")]
    public float thrustAccel = 15f;      // ���� ����
    public float reverseAccel = 10f;     // ����/����
    public float yawSpeed = 90f;         // �¿� ȸ��(����)
    public float pitchSpeed = 60f;       // ���� ȸ��
    public float rollSpeed = 80f;        // ���� ��

    [Header("Limits")]
    public float maxSpeed = 30f;         // �ִ� �ӵ�(���� ����)

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody is missing on Ship.");
        }
    }

    private void Update()
    {
        // ȸ��: ���콺 or Ű����(Q/E�� �� ����)
        float yaw = Input.GetAxis("Horizontal");  // A/D, ��/��
        float pitch = -Input.GetAxis("Vertical"); // W/S, ��/�� (W = �� ����)
        float roll = 0f;

        if (Input.GetKey(KeyCode.Q) == true)
        {
            roll = roll - 1f;
        }

        if (Input.GetKey(KeyCode.E) == true)
        {
            roll = roll + 1f;
        }

        // ������ ���� ȸ�� ����
        Vector3 euler = new Vector3(pitch * pitchSpeed, yaw * yawSpeed, roll * rollSpeed) * Time.deltaTime;
        transform.Rotate(euler, Space.Self);

        // ������ �Է��� Update���� �а� FixedUpdate���� ����
    }

    private void FixedUpdate()
    {
        float thrustInput = 0f;

        if (Input.GetKey(KeyCode.W) == true || Input.GetKey(KeyCode.UpArrow) == true)
        {
            thrustInput = thrustInput + 1f;
        }

        if (Input.GetKey(KeyCode.S) == true || Input.GetKey(KeyCode.DownArrow) == true)
        {
            thrustInput = thrustInput - 1f;
        }

        if (thrustInput > 0f)
        {
            rb.AddForce(transform.forward * thrustAccel * thrustInput, ForceMode.Acceleration);
        }

        if (thrustInput < 0f)
        {
            rb.AddForce(transform.forward * reverseAccel * thrustInput, ForceMode.Acceleration);
        }

        // �ְ� �ӵ� ����(���� ���� ����)
        Vector3 v = rb.linearVelocity;
        float forwardSpeed = Vector3.Dot(v, transform.forward);

        if (forwardSpeed > maxSpeed)
        {
            Vector3 capped = transform.forward * maxSpeed;
            Vector3 lateral = v - (transform.forward * forwardSpeed);
            rb.linearVelocity = capped + lateral;
        }
    }
}
