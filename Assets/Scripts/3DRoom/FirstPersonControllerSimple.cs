using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonControllerSimple : MonoBehaviour
{
    public Transform playerCamera;
    public float moveSpeed = 4.0f;
    public float mouseSensitivity = 120f;
    public float gravity = 9.81f;

    private CharacterController cc;
    private float yaw = 0f;
    private float pitch = 0f;
    private float vy = 0f;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();

        if (playerCamera == null)
        {
            Camera cam = GetComponentInChildren<Camera>();

            if (cam != null)
            {
                playerCamera = cam.transform;
            }
        }

        yaw = transform.eulerAngles.y;
        pitch = 0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // 마우스 회전
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        yaw = yaw + (mx * mouseSensitivity * Time.deltaTime);
        pitch = pitch - (my * mouseSensitivity * Time.deltaTime);

        if (pitch > 85f)
        {
            pitch = 85f;
        }

        if (pitch < -85f)
        {
            pitch = -85f;
        }

        transform.rotation = Quaternion.Euler(0f, yaw, 0f);

        if (playerCamera != null)
        {
            playerCamera.localRotation = Quaternion.Euler(pitch, 0f, 0f);
        }

        // 이동
        float ax = Input.GetAxisRaw("Horizontal");
        float az = Input.GetAxisRaw("Vertical");
        Vector3 move = (transform.right * ax) + (transform.forward * az);
        move = move.normalized * moveSpeed;

        // 중력
        if (cc.isGrounded == true)
        {
            vy = -0.5f;
        }
        else
        {
            vy = vy - (gravity * Time.deltaTime);
        }

        move.y = vy;
        cc.Move(move * Time.deltaTime);

        // ESC로 커서 토글(편의)
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
