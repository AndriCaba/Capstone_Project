using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IInteractable
{
    void Interact();
}

public class Interactor : MonoBehaviour
{
    // public LockOnCamera cameraController;
    public LookAtTarget cameraController;
    public Transform interactorSource;
    public float interactRange;
    public LayerMask selectableObjectsLayer;
    public AimStateManager aimStateManager;
  
    private void Start()
    {
        // lockCamera = cameraController.GetComponent<LockOnCamera>();  // Initialize it once
        // lockCamera.enabled = false;

        aimStateManager.enabled = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Right click
        {
            // lockCamera.enabled = true;
            Debug.Log("This is a log message"); 
            Ray ray = new Ray(interactorSource.position, interactorSource.forward);
            
            if (Physics.Raycast(ray, out RaycastHit hitInfo, interactRange, selectableObjectsLayer))
            {
               Transform selectedObject = hitInfo.transform;
              


                if (selectedObject.CompareTag("Selectable")) {

                    
                    aimStateManager.enabled = false;
                    cameraController.Lock(selectedObject);


                }
                   
            }
            
        }
            if (Input.GetMouseButtonDown(1))  // Right click
                {
                    aimStateManager.enabled = true;
                    cameraController.Goback();
                }

        // Draw a debug line to visualize the interaction range
        Debug.DrawRay(interactorSource.position, interactorSource.forward * interactRange, Color.blue);
    }


}
