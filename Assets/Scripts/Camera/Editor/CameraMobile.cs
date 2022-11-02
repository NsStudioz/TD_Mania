using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMobile : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;

    // Position:
    [SerializeField] Vector3 newPosition;
    [SerializeField] float normalSpeed;
    [SerializeField] float movementSpeed;
    [SerializeField] float movementTime;
    //[SerializeField] float panBorderThickness = 10f;
    // Scrolling:
    [SerializeField] Vector3 zoomAmount;
    [SerializeField] Vector3 newZoom;
    //[SerializeField] float scrollSpeed = 5f;
    [SerializeField] float minZoom = 2f;
    [SerializeField] float maxZoom = 8f;

    void Start()
    {
        newPosition = transform.position;
        newZoom = cameraTransform.localPosition;
    }

    void Update()
    {
        HandleMovementInput();
    }

    public void HandleMovementInput()
    {

        // Movement Speed Control:
        movementSpeed = normalSpeed;

        // Y-Coordinates:
        if (Input.GetKey(KeyCode.W))
        {
            newPosition += (transform.forward * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            newPosition += (transform.forward * -movementSpeed);
        }

        // X-Coordinates:
        if (Input.GetKey(KeyCode.D))
        {
            newPosition += (transform.right * movementSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            newPosition += (transform.right * -movementSpeed);
        }

        // Zoom:
        if (Input.GetKey(KeyCode.R))
        {
            newZoom += zoomAmount;
        }
        if (Input.GetKey(KeyCode.F))
        {
            newZoom -= zoomAmount;
        }

        newZoom.y = Mathf.Clamp(newZoom.y, minZoom, maxZoom);
        newZoom.z = Mathf.Clamp(newZoom.z, minZoom, maxZoom);

        // Conversion:
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime); // Smooth camera movement.
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime); // Smooth camera zoom;

    }
}
