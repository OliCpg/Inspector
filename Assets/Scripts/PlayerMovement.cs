using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
   
    [SerializeField] private float gravityStrength;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField][Range(1, 10)] private int lookHorizontalSensitivity = 5;
    [SerializeField][Range(1, 10)] private int lookVerticalSensitivity = 5;

    private Vector2 lookSensitivities;


    private CharacterController characterController;
    private Camera playerCamera;

    private Vector3 verticalForceVelocity;

    private Vector2 moveInput;
    private Vector2 lookDeltas;

    private bool isRunning = false;
    private bool isJumping = false;

    private Vector3 cameraRotation;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();

        lookSensitivities = new Vector2 (lookHorizontalSensitivity * 0.1f, lookVerticalSensitivity * 0.1f);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        // Mouvement de base WASD

        Vector3 moveInputToVector3 = new Vector3 {
            x = moveInput.x,
            y = 0f,
            z = moveInput.y
        };

        float currentSpeed = isRunning ? runSpeed : walkSpeed;
        Vector3 moveVector = transform.TransformDirection(moveInputToVector3);
        moveVector *= currentSpeed;
          
        // Saut
        if (characterController.isGrounded) {
            verticalForceVelocity.y = -2f;

            if (isJumping) {
                verticalForceVelocity.y = jumpSpeed;
            };
            isJumping = false;
        }
        else{
            verticalForceVelocity.y -= gravityStrength * Time.deltaTime;
        }

        characterController.Move((moveVector + verticalForceVelocity) * Time.deltaTime);

        // LOOK
        cameraRotation.x -= lookDeltas.y * lookSensitivities.y;
        cameraRotation.y += lookDeltas.x * lookSensitivities.x;
        cameraRotation.x = Mathf.Clamp(cameraRotation.x, -60f, 60f);

        transform.eulerAngles = new Vector3(0f, cameraRotation.y, 0f);
        playerCamera.transform.localEulerAngles = new Vector3(cameraRotation.x, 0f, 0f);
    }


    public void OnMove(InputAction.CallbackContext context) {
        moveInput = context.ReadValue<Vector2>().normalized;
        
    }
    public void OnRun(InputAction.CallbackContext context) {
        if (context.started) {
            isRunning = true;
        }else if (context.canceled) {
            isRunning = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context) {
        if (context.started && isJumping == false) {
            Debug.Log("Jump !");
            isJumping = true;
        }
    }

    public void OnLook(InputAction.CallbackContext context) {
        lookDeltas = context.ReadValue<Vector2>();
    }
}
