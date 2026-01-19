using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float speed = 5f;
    public bool canMove = true;


    public float minX = -5f;
    public float maxX = 5f;
    public float minZ = -5f;
    public float maxZ = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
{
    if (!canMove) return;
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3(horizontal, 0f, vertical);

    if (movement != Vector3.zero)
    {
        Quaternion targetRotation = Quaternion.LookRotation(movement);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }

    Vector3 targetPosition =
    rb.position + movement * speed * Time.fixedDeltaTime;

targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
targetPosition.z = Mathf.Clamp(targetPosition.z, minZ, maxZ);

rb.MovePosition(targetPosition);

}

}
