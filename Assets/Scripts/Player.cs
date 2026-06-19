using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isWalking;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;

    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized(); // Get the normalized movement input from GameInput

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y); // Convert to 3D vector for movement
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero; // Update the walking state based on movement

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed); // Rotate the player to face the movement direction
    }

    public bool IsWalking() {  return isWalking; }
}
