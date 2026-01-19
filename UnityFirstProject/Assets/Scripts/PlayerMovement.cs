using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveForce = 20f;
    public float maxSpeed = 6f;
    public float turnSpeed = 10f;

    [Header("Drag")]
    public float groundDrag = 5f;


    
    public bool canMove = true;


    public float minX = -5f;
    public float maxX = 5f;
    public float minZ = -5f;
    public float maxZ = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.drag = groundDrag;
        rb.freezeRotation = true;

    }

    void FixedUpdate()
{
    if (!canMove) return;

    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");

    Vector3 inputDirection = new Vector3(horizontal, 0f, vertical).normalized;

    if (rb.velocity.magnitude < maxSpeed)
{
    rb.AddForce(inputDirection * moveForce, ForceMode.Acceleration);
    if (inputDirection != Vector3.zero)
{
    Quaternion targetRotation =
        Quaternion.LookRotation(inputDirection);

    transform.rotation = Quaternion.Slerp(
        transform.rotation,
        targetRotation,
        turnSpeed * Time.fixedDeltaTime
    );
}

}



    

}

}
