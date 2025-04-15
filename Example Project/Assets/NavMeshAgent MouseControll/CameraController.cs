using System;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class CameraController : MonoBehaviour
{
    [SerializeField] private float xSpeed = 0.005f;
    [SerializeField] private float ySpeed = 0.005f;

    private CinemachineFreeLook _freeLookCamera;
    
    public event Action MouseMoved;
    private bool _isDragging;
    private bool _mouseMoved;  //Blocks MouseMoved Events, it's enough to get one event call
    private Vector3 _initialMousePosition;

    // Start is called before the first frame update
    private void Start()
    {
        _freeLookCamera = GetComponent<CinemachineFreeLook>();
        
        //Disable default input from Cinemachine
        _freeLookCamera.m_XAxis.m_InputAxisName = "";
        _freeLookCamera.m_YAxis.m_InputAxisName = "";
        _mouseMoved = false;

    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            // Start dragging the camera
            _isDragging = true;
            _initialMousePosition = Input.mousePosition;
        }

        if (_isDragging)
        {
            // Get the input from Input.GetAxis
            var mouseX = Input.GetAxis("Mouse X") * xSpeed;
            var mouseY = Input.GetAxis("Mouse Y") * ySpeed;

            mouseX /= Time.deltaTime;
            mouseY /= Time.deltaTime;
            
            // Check if the mouse has moved
            if (Math.Abs(Vector3.Distance(_initialMousePosition, Input.mousePosition)) > 10f && !_mouseMoved)
            {
                _mouseMoved = true;
                MouseMoved?.Invoke();
            }

            _freeLookCamera.m_XAxis.m_InputAxisValue = mouseX;
            _freeLookCamera.m_YAxis.m_InputAxisValue = mouseY;
        }

        if (Input.GetMouseButtonUp(0))
        {
            // Stop dragging when the mouse button is released
            _isDragging = false;
            _mouseMoved = false;
            _freeLookCamera.m_XAxis.m_InputAxisValue = 0;
            _freeLookCamera.m_YAxis.m_InputAxisValue = 0;
        }
    }
}
