using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CameraMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float moveSpeed = 50.0f;
    public float boundary = 50.0f;

    public float screenBoundary = 40.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * moveSpeed;
        float v = Input.GetAxis("Vertical") * moveSpeed;
        Vector3 pos = transform.position;
        Vector3 vel = rb.velocity;

        vel.x = CalculateAxisVelocity(h, pos.x);
        vel.z = CalculateAxisVelocity(v, pos.z);

        if (h == 0 && v == 0) {
            Vector3 mousePosition = Input.mousePosition;
            vel.x = CalculateMousePositionVelocity(mousePosition.x, Screen.width, pos.x);
            vel.z = CalculateMousePositionVelocity(mousePosition.y, Screen.height, pos.z);
        }

        rb.velocity = vel;
    }

    private float CalculateAxisVelocity(float axis, float pos)
    {
        if ((axis > 0 && pos < boundary) || (axis < 0 && pos > (boundary * -1)))
        {
            return axis;
        }

        return 0.0f;
    }

    private float CalculateMousePositionVelocity(float pos, int dimensions, float currentCameraPosition)
    {
        // Move Left
        if (pos > 0 && pos < screenBoundary) {
            if (currentCameraPosition > (boundary * -1)) {
                return moveSpeed * -1;
            }
        }
        // Move Right
        else if (pos > (dimensions - screenBoundary) && pos < dimensions) {
            if (currentCameraPosition < boundary) {
                return moveSpeed;
            }
        }

        return 0.0f;
    }
}
