using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputActionsHandler : MonoBehaviour
{
    private FPMovementController movementController;
    private LookController lookController;

    private PlayerActions controls;

    private void Awake()
    {
        movementController = GetComponent<FPMovementController>();
        lookController = GetComponentInChildren<LookController>();
    }

    private void OnEnable() {
        controls = new PlayerActions();
        controls.Human.Enable();

        controls.Human.Move.performed += Move;
        controls.Human.Move.canceled += Move;

        controls.Human.Look.performed += Look;
        controls.Human.Look.canceled += Look;
    }

    private void OnDisable() {
        controls.Human.Move.performed -= Move;
        controls.Human.Move.canceled -= Move;

        controls.Human.Look.performed -= Look;
        controls.Human.Look.canceled -= Look;

        controls.Human.Disable();
    }

    private void Move(InputAction.CallbackContext context)
    {
        if (movementController == null) return;

        Vector2 inputVector = context.ReadValue<Vector2>();

        movementController.SetMoveDirection(new (inputVector.x, 0, inputVector.y));
    }

    private void Look(InputAction.CallbackContext context)
    {
        if (lookController == null) return;

        Vector2 lookValue = context.ReadValue<Vector2>();
        if(context.control.device is Gamepad)
        {
            lookValue *= Time.deltaTime;
        }

        lookController.SetLookVector(lookValue);
    }
}
