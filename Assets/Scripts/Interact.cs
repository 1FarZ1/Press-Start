using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Interact : MonoBehaviour
{
    public string InteractionName;
    public UnityEvent InteractEvent;
    public bool InteractOneTime;
    private bool CanInteract;
    
    private bool Interacted;

    void Update()
    {
        if(CanInteract && !Interacted && InteractOneTime || CanInteract && !InteractOneTime)
        {
            GUIController.Instance.InteractionText.gameObject.SetActive(true);
            GUIController.Instance.InteractionText.text = "Press E to " + InteractionName;
            if (Input.GetKeyDown(KeyCode.E))
            {
                GUIController.Instance.InteractionText.gameObject.SetActive(false);
                Interacted = true;
                InteractEvent.Invoke();
                //AudioManager.Instance.PlaySFX("dooropening");


            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == PlayerController.Instance.gameObject)
        {
            CanInteract = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == PlayerController.Instance.gameObject)
        {
            GUIController.Instance.InteractionText.gameObject.SetActive(false);
            CanInteract = false;

        }

    }
}
