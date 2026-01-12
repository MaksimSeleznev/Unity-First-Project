using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotationSpeed = 10f;

    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        if (moveDirection != Vector3.zero)
{
    Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
    transform.rotation = Quaternion.Slerp(
        transform.rotation,
        targetRotation,
        rotationSpeed * Time.deltaTime
    );
}


        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
