using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Movement : MonoBehaviour
{
    
    [SerializeField] private Camera playerCamera;
    [SerializeField] private CameraController cameraController;

    private NavMeshAgent _agent;
    private NavMeshPath _path;

    private CameraController _freeLookInput;
    
    private bool _isMouseMoved = false;
    private Coroutine _lastCoroutine;
    private bool _mouseUp = false;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.angularSpeed = 0;
        _path = new NavMeshPath();
    }

    private void Update()
    {
        HandleMouseClickEvents();
    }

    private void HandleMouseClickEvents()
    {
        if (_isMouseMoved && _lastCoroutine != null)
        {
            StopCoroutine(_lastCoroutine);
            _lastCoroutine = null;
        }

        if (Input.GetMouseButtonDown(0))
        {
            _lastCoroutine = StartCoroutine(MovementHandler());
        }

        if (Input.GetMouseButtonUp(0))
        {
            _mouseUp = true;
            _isMouseMoved = false;
        }
    }

    private IEnumerator MovementHandler()
    {
        _mouseUp = false;

        while (!_mouseUp)
        {
            yield return null;
        }
        
        Move();
    }

    private void Move()
    {
        _mouseUp = false;
        _isMouseMoved = false;

        Ray myRay = playerCamera.ScreenPointToRay(Input.mousePosition);

        //Return if Raycast didn't hit anything
        if (!Physics.Raycast(myRay, out RaycastHit myRaycastHit)) return;
        
        //Set agent destination to raycast hit point if path is possible
        if (_agent.CalculatePath(myRaycastHit.point, _path) &&
            _path.status == NavMeshPathStatus.PathComplete)
        {
            _agent.SetDestination(myRaycastHit.point);
        }
    }

    //Subscribe to events
    private void OnEnable()
    {
        if (cameraController != null)
        {
            cameraController.MouseMoved += MouseMoved;
        }
    }

    //Unsubscribe from events
    private void OnDisable()
    {
        if (cameraController != null)
        {
            cameraController.MouseMoved -= MouseMoved;
        }
    }

    private void MouseMoved()
    {
        _isMouseMoved = true;
    }
    
}
