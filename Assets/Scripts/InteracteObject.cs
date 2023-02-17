using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class InteracteObject : MonoBehaviour
{
    public UnityEvent InteractEvent;
    public UnityEvent EndInteractEvent;
    public Transform EndInteractionPos;
    public string InteractionName;
    private bool CanInteract;
    private bool Interacting;

    private void Update()
    {
        if(!Interacting && CanInteract ) {
            GUIController.Instance.OneFrameText(GUIController.Instance.InteractionText, "Press E to " + InteractionName);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interacting = true;
                InteractEvent.Invoke();
              
            }
        }
        if(Interacting && Input.GetKeyDown(KeyCode.Escape)){
            Interacting = false;

            EndInteractEvent.Invoke();
        
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == PlayerController.Instance.transform)
            CanInteract = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.transform == PlayerController.Instance.transform)
            CanInteract = false;
    }
}
