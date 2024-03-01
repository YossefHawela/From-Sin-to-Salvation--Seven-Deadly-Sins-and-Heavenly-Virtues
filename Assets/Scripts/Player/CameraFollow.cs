using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target to follow
    public float smoothSpeed = 0.125f; // Smoothing factor

    private Vector3 offset; // Offset between camera and target

    void Start()
    {
        // Calculate the initial offset
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position with some delay
            Vector3 desiredPosition = target.position + offset;

            // Smoothly interpolate between the current position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Set the camera's position to the smoothed position
            transform.position = smoothedPosition;
        }
    }
}
