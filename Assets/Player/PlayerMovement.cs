using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.5f;
    [SerializeField]
    private float gravity = 9.8f;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        var direction = new Vector3(horizontalInput, 0, verticalInput);
        var velocity = speed * direction;
        velocity.y -= gravity * Time.deltaTime;
        characterController.Move(Time.deltaTime * velocity);
    }
}
