using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;
    public Transform originalTarget; // The target to lock onto
    public CinemachineVirtualCamera virtualCamera; // Reference to your Cinemachine Virtual Camera

    void Start()
    {
        if (virtualCamera == null)
        {
            // Assign the Cinemachine Virtual Camera component if not assigned in the Inspector
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
            
        }
        virtualCamera.m_Lens.FieldOfView = 70; 
    }

    void Update()
    {
    //   virtualCamera.LookAt = target;
    }


    public void Lock(Transform newtarget)
    {
         virtualCamera.LookAt = newtarget;
        virtualCamera.m_Lens.FieldOfView = 90;
       virtualCamera.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset.y = 0.9f;
    
        // if (target != null && virtualCamera != null)
        // {
        //     // Set the Cinemachine Virtual Camera's Look At target
        //     virtualCamera.LookAt = target;
        // }
    }
    public void Goback()
    {
         virtualCamera.LookAt = originalTarget;
        virtualCamera.m_Lens.FieldOfView = 70; 
        virtualCamera.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset.y = 0.4f;// default fov
        // if (target != null && virtualCamera != null)
        // {
        //     // Set the Cinemachine Virtual Camera's Look At target
        //     virtualCamera.LookAt = target;
        // }
    }
    
}
