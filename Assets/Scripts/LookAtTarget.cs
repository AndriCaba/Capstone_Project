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
    }

    void Update()
    {
    //   virtualCamera.LookAt = target;
    }


    public void Lock(Transform newtarget)
    {
         virtualCamera.LookAt = newtarget;
        virtualCamera.m_Lens.FieldOfView = 90;
    
        // if (target != null && virtualCamera != null)
        // {
        //     // Set the Cinemachine Virtual Camera's Look At target
        //     virtualCamera.LookAt = target;
        // }
    }
    public void Goback()
    {
         virtualCamera.LookAt = originalTarget;
        virtualCamera.m_Lens.FieldOfView = 60; // default fov
        // if (target != null && virtualCamera != null)
        // {
        //     // Set the Cinemachine Virtual Camera's Look At target
        //     virtualCamera.LookAt = target;
        // }
    }
    
}
