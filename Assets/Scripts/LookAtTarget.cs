using UnityEngine;
using Cinemachine;
public class LookAtTarget : MonoBehaviour
{
  public Transform target;
    public float followSpeed = 5f;

    private CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        // Assuming the CinemachineVirtualCamera is on the same GameObject
        virtualCamera = GetComponent<CinemachineVirtualCamera>();

        // Set the LookAt target for the virtual camera
        if (virtualCamera != null && target != null)
        {
          
            virtualCamera.LookAt = target;
        }
    }

    void Update()
    {
        if (target != null)
        {
            FollowTarget();
        }
    }

    void FollowTarget()
    {
        // Smoothly follow the target using Cinemachine
        transform.position = Vector3.Lerp(transform.position, target.position, followSpeed * Time.deltaTime);
}
}
