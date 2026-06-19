using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isWalking;
    private Vector3 lastInteractDir;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask countersLayerMask;

    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    public bool IsWalking() {  return isWalking; }

    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized(); // Get the normalized movement input from GameInput
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y); // Convert to 3D vector for movement

        if(moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir; // Update the last interaction direction based on movement
        }

        float ineractDistance = 2f;
        if(Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, ineractDistance, countersLayerMask))
        {
            if(raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                //Has ClearCounter
                clearCounter.Interact();
            }
        }
    }

    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized(); // Get the normalized movement input from GameInput
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y); // Convert to 3D vector for movement

        float moveDistance = moveSpeed * Time.deltaTime; // Calculate movement distance based on speed and time
        float playerRadius = .7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance); // Check for obstacles in the movement direction
        if (!canMove)
        {
            //Cannot move towards moveDir

            //Attempt to move only on the X axis
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove)
            {
                //Can only move on the X axis
                moveDir = moveDirX;
            }
            else
            {
                //Cannot move on the X axis, attempt to move only on the Z axis
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    //Can only move on the Z axis
                    moveDir = moveDirZ;
                }
                else
                {
                    //Cannot move in any direction
                }
            }
        }
        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }

        isWalking = moveDir != Vector3.zero; // Update the walking state based on movement

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed); // Rotate the player to face the movement direction
    }
}
