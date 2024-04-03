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

    private void Start()
    {
        // lockCamera = cameraController.GetComponent<LockOnCamera>();  // Initialize it once
        // lockCamera.enabled = false;

        
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

                    
                    cameraController.Lock(selectedObject);


                }
                   
            }
            
        }
            if (Input.GetMouseButtonDown(1))  // Right click
        {
          cameraController.Goback();
        }

        // Draw a debug line to visualize the interaction range
        Debug.DrawRay(interactorSource.position, interactorSource.forward * interactRange, Color.blue);
    }


}
