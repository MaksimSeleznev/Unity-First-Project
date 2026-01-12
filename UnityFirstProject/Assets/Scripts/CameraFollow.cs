using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public Vector3 offset = new Vector3(0f, 5f, -7f);
    public float rotationSmoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Quaternion targetRotation = Quaternion.Euler(
            0f,
            target.eulerAngles.y,
            0f
        );

        Vector3 desiredPosition = target.position + targetRotation * offset;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            Time.deltaTime * rotationSmoothSpeed
        );

        transform.LookAt(target.position);
    }
}
