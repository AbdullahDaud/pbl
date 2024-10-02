using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamOrbit : MonoBehaviour
{
    public float xSpeed = 4f;
    public float distance = 5.0f;

    private float X;
    private float Y;

    public GameObject target;

    float minFov = 35f;
    float maxFov = 100f;

    float sensitivity = 17f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Orbit camera around the target when right mouse button is pressed
        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(target.transform.position, target.transform.up, Input.GetAxis("Mouse X") * xSpeed);
        }

        // Adjust field of view based on mouse scroll wheel
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * -sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}
