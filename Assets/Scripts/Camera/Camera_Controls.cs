using UnityEngine;

public class Camera_Controls : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private FixedJoystick joyStick;

    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float movementTime;

    [Header("Zoom Elements")] 
    [SerializeField] private Vector3 zoomAmount;
    [SerializeField] private Vector3 newZoom;
    [SerializeField] private float minZoom = 2f;
    [SerializeField] private float maxZoom = 8f;
    [SerializeField] private bool isPointerDown_ZoomIn = false;
    [SerializeField] private bool isPointerDown_ZoomOut = false;
    
    [Header("Clamping Elements")]
    [SerializeField] private Vector3 cameraMovement_Pos;
    [SerializeField] private float x_Axis_Min;
    [SerializeField] private float x_Axis_Max;
    [SerializeField] private float z_Axis_Min;
    [SerializeField] private float z_Axis_Max;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        newZoom = cameraTransform.localPosition;
    }

    private void Update()
    {
        if (isPointerDown_ZoomIn)
            newZoom += zoomAmount;
        else if (isPointerDown_ZoomOut)
            newZoom -= zoomAmount;

        HandleMovementBounds();
        HandleZoomUpdates();
        HandleMovementInput();
    }

    #region Input_Movement:
    private void HandleMovementInput()
    {
        transform.position = cameraMovement_Pos;

        // Horizontal:
        if (joyStick.Horizontal >= 0.2f)
            cameraMovement_Pos += movementSpeed * Time.deltaTime * transform.right;
        else if (joyStick.Horizontal <= -0.2f)
            cameraMovement_Pos += -movementSpeed * Time.deltaTime * transform.right;

        // Vertical:
        if (joyStick.Vertical >= 0.2f)
            cameraMovement_Pos += movementSpeed * Time.deltaTime * transform.forward;
        else if (joyStick.Vertical <= -0.2f)
            cameraMovement_Pos += -movementSpeed * Time.deltaTime * transform.forward;
    }

    private void HandleMovementBounds()
    {
        cameraMovement_Pos.x = Mathf.Clamp(cameraMovement_Pos.x, x_Axis_Min, x_Axis_Max);
        cameraMovement_Pos.z = Mathf.Clamp(cameraMovement_Pos.z, z_Axis_Min, z_Axis_Max);
    }
    #endregion

    #region Input_Zoom_EventTriggers:

    public void ZoomInInput_PointerDown()
    {
        isPointerDown_ZoomIn = true;
    }

    public void ZoomInInput_PointerUp()
    {
        isPointerDown_ZoomIn = false;
    }

    public void ZoomOutInput_PointerDown()
    {
        isPointerDown_ZoomOut = true;
    }

    public void ZoomOutInput_PointerUp()
    {
        isPointerDown_ZoomOut = false;
    }

    #endregion

    private void HandleZoomUpdates()
    {
        newZoom.y = Mathf.Clamp(newZoom.y, minZoom, maxZoom);
        newZoom.z = Mathf.Clamp(newZoom.z, minZoom, maxZoom);

        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime); // Smooth camera zoom;
    }
}


