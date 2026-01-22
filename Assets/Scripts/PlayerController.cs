using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float vehicleSpeed = 25f;
    [SerializeField] private float turnSpeed = 35f;

    private InputAction moveAction;

    private void Awake()
    {
        var playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
    }

    private void OnEnable()
    {
        moveAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
    }

    private void Start()
    {
        var playerInput = GetComponent<PlayerInput>();

        // Disable all maps first
        foreach (var map in playerInput.actions.actionMaps)
        {
            map.Disable();
        }

        // Enable only the "Player" map
        playerInput.actions.FindActionMap("Player").Enable();

    }
    // Update is called once per frame
    void Update()
    {
        //Making the car move forward!
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        float horizontalInput = moveInput.x;
        float verticalInput = moveInput.y;

        transform.Translate(Vector3.forward * Time.deltaTime * vehicleSpeed * verticalInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
