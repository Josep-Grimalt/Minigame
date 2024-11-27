using UnityEngine;


public class FPMovementController : MonoBehaviour
{
    [SerializeField] private CharacterController cc;
    [SerializeField] private float speed = 10f;

    private Vector3 moveDirection;

    public void SetMoveDirection(Vector3 direction)
    {
        moveDirection = direction;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() {
        Vector3 movement = transform.forward * moveDirection.z + transform.right * moveDirection.x;

        movement = Vector3.ClampMagnitude(movement, 1f);

        cc.Move(speed * Time.deltaTime * movement);
    }
}