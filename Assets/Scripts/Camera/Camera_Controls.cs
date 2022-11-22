using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Camera_Controls : MonoBehaviour
{

    /*    [SerializeField] Vector3 newPosition;*/
    /*    [SerializeField] float normalSpeed;*/
    //[SerializeField] float panBorderThickness = 10f;
    //[SerializeField] float scrollSpeed = 5f;
    /*newPosition = transform.position;*/

    // Objects:
    [SerializeField] Transform cameraTransform;
    [SerializeField] FixedJoystick joyStick;
    // Position:
    [SerializeField] float movementSpeed;
    [SerializeField] float movementTime;
    // Scrolling:
    [SerializeField] Vector3 zoomAmount;
    [SerializeField] Vector3 newZoom;
    [SerializeField] float minZoom = 2f;
    [SerializeField] float maxZoom = 8f;
    // Scrolling-bools:
    [SerializeField] bool isPointerDown_ZoomIn = false;
    [SerializeField] bool isPointerDown_ZoomOut = false;
    
    [Header("Clamping Elements")]
    [SerializeField] Vector3 cameraMovement_Pos;
    [SerializeField] float x_Axis_Min;
    [SerializeField] float x_Axis_Max;
    [SerializeField] float z_Axis_Min;
    [SerializeField] float z_Axis_Max;


    void Start()
    {
        newZoom = cameraTransform.localPosition;
    }

    private void Update()
    {
        if (isPointerDown_ZoomIn)
        {
            newZoom += zoomAmount;
        }
        else if (isPointerDown_ZoomOut)
        {
            newZoom -= zoomAmount;
        }

        HandleMovementBounds();
        HandleScrollingInput();
        HandleMovementInput();
    }

    #region Input_Movement:
    private void HandleMovementInput()
    {
        transform.position = cameraMovement_Pos;

        if (joyStick.Horizontal >= 0.2f)
        {
            cameraMovement_Pos += (transform.right * movementSpeed * Time.deltaTime);
        }
        else if (joyStick.Horizontal <= -0.2f)
        {
            cameraMovement_Pos += (transform.right * -movementSpeed * Time.deltaTime);
        }

        if (joyStick.Vertical >= 0.2f)
        {
            cameraMovement_Pos += (transform.forward * movementSpeed * Time.deltaTime);
        }
        else if (joyStick.Vertical <= -0.2f)
        {
            cameraMovement_Pos += (transform.forward * -movementSpeed * Time.deltaTime);
        }
    }

    private void HandleMovementBounds()
    {
        cameraMovement_Pos.x = Mathf.Clamp(cameraMovement_Pos.x, x_Axis_Min, x_Axis_Max);
        cameraMovement_Pos.z = Mathf.Clamp(cameraMovement_Pos.z, z_Axis_Min, z_Axis_Max);
    }
    #endregion

    #region Input_Scrolling:

    public void HandleScrollingInput_ZoomIn_HoldPress()
    {
        isPointerDown_ZoomIn = true;
    }

    public void HandleScrollingInput_ZoomIn_Release()
    {
        isPointerDown_ZoomIn = false;
    }

    public void HandleScrollingInput_ZoomOut_HoldPress()
    {
        isPointerDown_ZoomOut = true;
    }

    public void HandleScrollingInput_ZoomOut_Release()
    {
        isPointerDown_ZoomOut = false;
    }

    public void HandleScrollingInput()
    {
        newZoom.y = Mathf.Clamp(newZoom.y, minZoom, maxZoom);
        newZoom.z = Mathf.Clamp(newZoom.z, minZoom, maxZoom);

        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime); // Smooth camera zoom;
    }

    #endregion
}


// Original Movement:
/*        if (joyStick.Horizontal >= 0.2f)
        {
            transform.position += (transform.right * movementSpeed * Time.deltaTime);
        }
        else if (joyStick.Horizontal <= -0.2f)
        {
            transform.position += (transform.right * -movementSpeed * Time.deltaTime);
        }

        if (joyStick.Vertical >= 0.2f)
        {
            transform.position += (transform.forward * movementSpeed * Time.deltaTime);
        }
        else if (joyStick.Vertical <= -0.2f)
        {
            transform.position += (transform.forward * -movementSpeed * Time.deltaTime);
        }*/
