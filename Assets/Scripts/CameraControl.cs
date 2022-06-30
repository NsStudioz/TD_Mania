using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Camera Movement:
    public float panSpeed = 5f;
    public float panBorderThickness = 10f;

    // Camera Y-movement: 
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;


    void Update()
    {
        CameraScrolling();
        CameraMovement();
    }

    private void CameraScrolling()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y = pos.y - scroll * 100 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
    }

    private void CameraMovement()
    {
        // Y-Coordinates:
        if (Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        // X-Coordinates:
        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
    }
}
