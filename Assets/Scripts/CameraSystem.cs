using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{

    public Transform cameraTransform;
    // Position:
    public Vector3 newPosition;
    public float normalSpeed;
    public float fastSpeed;
    public float movementSpeed;
    public float movementTime;
    public float panBorderThickness = 10f;
    // Scrolling:
    public Vector3 zoomAmount;
    public Vector3 newZoom;
    public float scrollSpeed = 5f;
    public float minZoom = 2f;
    public float maxZoom = 8f;
    // Rotation:
    public Quaternion newRotation;
    public float rotationAmount;
    // Other:
    private bool doMovement = true;

    void Start()
    {
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            doMovement = !doMovement;
        }

        if (!doMovement)
        {
            return;
        }
        else
        {
            HandleMovementInput();
        }
    }

    public void HandleMovementInput()
    {
        // Movement Speed Control:
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = fastSpeed;
        }
        else
        {
            movementSpeed = normalSpeed;
        }

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

        // Rotations:
        if (Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
        if (Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
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

        // Convertion (Prototype, for testing purposes!):
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime); // Smooth camera movement.
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime); // Smooth camera rotation.
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime); // Smooth camera zoom;

    }




}
