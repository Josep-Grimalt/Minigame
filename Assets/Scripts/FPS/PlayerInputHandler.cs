using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private FPMovementController movementController;
    private LookController lookController;


    private void Start()
    {
        movementController = GetComponent<FPMovementController>();
        lookController = GetComponentInChildren<LookController>();
    }

    private void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");
        movementController?.SetMoveDirection(new Vector3(xMovement, 0, zMovement));

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        lookController?.SetLookVector(new Vector2(mouseX, mouseY));
    }
}