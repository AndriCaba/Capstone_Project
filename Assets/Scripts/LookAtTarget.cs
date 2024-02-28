using UnityEngine;
using Cinemachine;
public class LookAtTarget : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    public Transform playerTransform;  // Assign player transform in the inspector
    public Transform enemyTransform;   // Assign enemy transform in the inspector

    private CinemachineVirtualCamera virtualCamera;

    void Start()
    {

        originalPosition = transform.position;
        originalRotation = transform.rotation;


        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        if (virtualCamera != null && playerTransform != null)
        {
            // Set player as the initial follow target
            virtualCamera.Follow = playerTransform;
        }
    }

    void Update()
    {
        // Example: Switch follow target to enemy when a condition is met
        if (Input.GetKeyDown(KeyCode.T))  // Change this condition based on your game logic
        {
         
        }
    }

    public void SwitchToEnemyTarget(Transform enemyTransform)
    {
        if (virtualCamera != null && enemyTransform != null)
        {
            virtualCamera.LookAt = enemyTransform;
        }
    }
    private void LateUpdate()
    {
        

    }
}
