using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isWalking;

    [SerializeField] private float moveSpeed = 7f;

    private void Update()
    {
        Vector2 inputVector = new Vector2(0, 0); 

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x += 1;
        }

        inputVector = inputVector.normalized; // Normalize the vector to ensure consistent movement speed in all directions

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y); // Convert to 3D vector for movement
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero; // Update the walking state based on movement

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed); // Rotate the player to face the movement direction
    }

    public bool IsWalking() {  return isWalking; }
}
