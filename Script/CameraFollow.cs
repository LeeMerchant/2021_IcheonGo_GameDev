using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    public Transform target;

    public float dist = 9.0f;


    public float xSpeed = 220.0f;
    public float ySpeed = 100.0f;


    private float x = 0.0f;
    private float y = 0.0f;


    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;


    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        offset = new Vector3(0.0f, 7.5f, -8.0f);
    }


    void LateUpdate()
    {
        Rotate();
    }

    void Rotate()
    {
        if (target)
        {
            dist -= 1 * Input.mouseScrollDelta.y;

            x += Input.GetAxis("Mouse X") * xSpeed * 0.015f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.015f;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0, 0.0f, -dist) + target.position + new Vector3(0.0f, 0, 0.0f);

            transform.rotation = rotation;
            transform.position = position;
        }
    }
}