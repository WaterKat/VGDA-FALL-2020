using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private float sensitivity = 1f;

    [SerializeField]
    private bool xRotClamp = false;
    [SerializeField]
    private Vector2 xRotLimits = Vector2.zero;
    private float xRot;

    [SerializeField]
    private bool yRotClamp = false;
    [SerializeField]
    private Vector2 yRotLimits = Vector2.zero;
    private float yRot;

    [SerializeField]
    private bool lockCursor = true;

    private bool animating = false;

    private void Start()
    {
        if (lockCursor)
            Cursor.lockState = CursorLockMode.Locked;
    }

    public void StartingCameraAnimation()
    {
        xRot = 0;
        yRot = 0;
        animating = true;
    }
    public void EndingCameraAnimation()
    {
        animating = false;
    }

    private void Update()
    {
        if (lockCursor&&Input.GetMouseButtonDown(0))
            Cursor.lockState = CursorLockMode.Locked;

        if (animating)
            return;

        xRot += Input.GetAxis("Mouse X") * sensitivity;
        if (xRotClamp)
            xRot = Mathf.Clamp(xRot, xRotLimits.x, xRotLimits.y);
        yRot += Input.GetAxis("Mouse Y") * sensitivity;
        if (yRotClamp)
            yRot = Mathf.Clamp(yRot, yRotLimits.x, yRotLimits.y);

        player.camera.transform.localRotation = Quaternion.Euler(yRot, xRot, 0);
    }
}
