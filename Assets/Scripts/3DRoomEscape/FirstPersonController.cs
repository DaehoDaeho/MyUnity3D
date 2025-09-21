using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public Transform playerCamera;
    public float moveSpeed = 4.0f;
    public float mouseSensitivity = 120.0f;
    public float gravity = 9.81f;
    public CharacterController cc;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float vy = 0.0f;

    private void Awake()
    {
        yaw = transform.eulerAngles.y;
        pitch = 0.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        yaw = yaw + (mx * mouseSensitivity * Time.deltaTime);
        pitch = pitch - (my * mouseSensitivity * Time.deltaTime);

        if(pitch < -85.0f)
        {
            pitch = -85.0f;
        }

        if(pitch > 85.0f)
        {
            pitch = 85.0f;
        }

        transform.rotation = Quaternion.Euler(0.0f, yaw, 0.0f);
        playerCamera.localRotation = Quaternion.Euler(pitch, 0.0f, 0.0f);

        float ax = Input.GetAxisRaw("Horizontal");
        float az = Input.GetAxisRaw("Vertical");
        Vector3 move = (transform.right * ax) + (transform.forward * az);
        move = move.normalized * moveSpeed;

        if(cc.isGrounded == true)
        {
            vy = -0.5f;
        }
        else
        {
            vy = vy - (gravity * Time.deltaTime);
        }

        move.y = vy;
        cc.Move(move * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Escape) == true)
        {
            if(Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
