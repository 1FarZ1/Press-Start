using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance { get; private set; }
    public Vector2 MouseSensitivity;
    [HideInInspector]public float xRotation = 0f;
    public Vector3 Offset;
    [HideInInspector]public bool CanMove;
    private void Awake()
    {
        Instance = this;
    }
    private void LateUpdate()
    {
        if (CanMove)
        {
            float mousex = Input.GetAxis("Mouse X") * MouseSensitivity.x;
            float mousey = Input.GetAxis("Mouse Y") * MouseSensitivity.y;

            xRotation -= mousey;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


            PlayerController.Instance.transform.Rotate(Vector3.up * mousex);

            this.transform.position = PlayerController.Instance.transform.position + Offset;

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, PlayerController.Instance.transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
