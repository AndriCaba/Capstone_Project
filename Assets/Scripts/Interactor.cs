using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact();
}

public class Interactor : MonoBehaviour
{
    public LookAtTarget cameraControler;
    public LayerMask SelectObjectLayer;
    public Transform InteractorSource;
    public float InteractRange;

    private void Start()
    {
        LookAtTarget LockCamera = GetComponent<LookAtTarget>();
        LockCamera.enabled = false;


        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))//change to right click
        {
            LookAtTarget LockCamera = GetComponent<LookAtTarget>();
            Ray ray = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {

                    /*interactObj.Interact();*/
                    LockCamera.SwitchToEnemyTarget(InteractorSource);
                }
            }
        }

        // Draw a debug line to visualize the interaction range
        Debug.DrawRay(InteractorSource.position, InteractorSource.forward * InteractRange, Color.blue);
    }
   

}
