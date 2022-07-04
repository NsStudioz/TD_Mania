using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraController : MonoBehaviour
{

    public Transform cameraTransform;
    // Position:
    public Vector3 newPosition;
    public float normalSpeed;   // normal movement mode || camera moves normally
    public float fastSpeed;     // fast movement mode || camera moves faster than normal
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
    // other:
    private bool doMovement = true;
    /// 
    /// 
    // Mouse Input:
    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;


    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position; // our new position will be the same as the rig.
        newRotation = transform.rotation; // our new rotation will be the same as the rig.
        newZoom = cameraTransform.localPosition; // using localPosition because we want to make sure that the camera stays relative to our rig.
    }

    // Update is called once per frame
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
            HandleMouseInput();
            HandleMovementInput();
        }
    }

    public void HandleMouseInput() // Mouse camera handle:
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            newZoom += Input.mouseScrollDelta.y * zoomAmount;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entryRayCast;

            if(plane.Raycast(ray, out entryRayCast))
            {
                dragStartPosition = ray.GetPoint(entryRayCast);
            }
        }
        if (Input.GetMouseButton(0))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entryRayCast;

            if (plane.Raycast(ray, out entryRayCast))
            {
                dragCurrentPosition = ray.GetPoint(entryRayCast);

                newPosition = transform.position + dragStartPosition - dragCurrentPosition;
            }
        }
    }


    public void HandleMovementInput() // camera keyboard handle:
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = fastSpeed;
        }
        else
        {
            movementSpeed = normalSpeed;
        }

        // Y-Coordinates:
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            newPosition += (transform.forward * movementSpeed); 
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.mousePosition.y <= panBorderThickness)
        {
            newPosition += (transform.forward * -movementSpeed);
        }
        // X-Coordinates:
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            newPosition += (transform.right * movementSpeed);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.mousePosition.x <= panBorderThickness)
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

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime); // smooth camera movement.
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime); // smooth camera rotation.
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime); // smooth camera zoom.

    }


}
