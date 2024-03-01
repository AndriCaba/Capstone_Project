using UnityEngine;

public class LockOnCamera : MonoBehaviour
{
    public Transform target; // The currently locked-on target.
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    public float smoothSpeed = 5f; // Adjust this to control camera follow speed.
    public Vector3 offset; // Offset from the target.

    public bool scriptEnabled;

    private void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
      
    }

    private void LateUpdate()
    {
        if (target == null)
        {
            // Restore original position and rotation when untargeted.
            if (transform.position != originalPosition)
            {
                transform.position = Vector3.Lerp(transform.position, originalPosition, smoothSpeed * Time.deltaTime);
            }
            if (transform.rotation != originalRotation)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, smoothSpeed * Time.deltaTime);
            }
        }
        else
        {
            // Calculate the desired camera position.
            Vector3 desiredPosition = target.position + offset;

            // Smoothly interpolate the current camera position towards the desired position.
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            // Make the camera look at the target.
            transform.LookAt(target);
        }
    }

    // Set the target when an object is clicked.
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public void ClearTarget()
    {
        target = null;
    }
}
