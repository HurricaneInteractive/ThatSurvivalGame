using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject terrain;
    public float moveSpeed = 50.0f;
    public float rotateSpeed = 10.0f;

    private void FixedUpdate() {
        float h = Input.GetAxis("Horizontal") * moveSpeed;
        transform.RotateAround(terrain.transform.position, Vector3.up, rotateSpeed * (h * -1) * Time.fixedDeltaTime);
    }
}
