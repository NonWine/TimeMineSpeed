using UnityEngine;

public class MouseMove : MonoBehaviour
{
    float xRot, yRot;
    float xRotCurrent, yRotCurrent;
    float currentVelosityX, currentVelosityY;
    public Camera player;
    public GameObject playerGameObject;
    public float sensivity = 5f, smoothTime = 0.1f;
    private void Start()
    {
        Cursor.visible = false;
    }
    void FixedUpdate()
    {
        Mouse();

    }
    //camera's rotation
    void Mouse()
    {
        
        xRot += Input.GetAxis("Mouse X") * sensivity ;
        yRot += Input.GetAxis("Mouse Y") * sensivity ;
        yRot = Mathf.Clamp(yRot, -90, 90);

        xRotCurrent = Mathf.SmoothDamp(xRotCurrent, xRot, ref currentVelosityX, smoothTime);
        yRotCurrent = Mathf.SmoothDamp(yRotCurrent, yRot, ref currentVelosityY, smoothTime);
        player.transform.rotation = Quaternion.Euler(-yRotCurrent, xRotCurrent, 0f);
        playerGameObject.transform.rotation = Quaternion.Euler(-yRotCurrent, xRotCurrent, 0f);
    }
}