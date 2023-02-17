using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform destination;
    public float force = 10f;
    public float RotationForce = 2f;
    // public GameObject particles;
    // public AudioSource sound;

    private void OnTriggerEnter(Collider other)
    {
       

       if(other.CompareTag("Player")){
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            other.transform.position = destination.transform.position ;
            other.gameObject.GetComponent<CharacterController>().enabled = true;
            if(PlayerController.Instance.GetComponent<PickUpItem>().PickUpItemRb)
                PlayerController.Instance.GetComponent<PickUpItem>().PickUpItemRb.position = PlayerController.Instance.HandPickUp.transform.position;
       }
       else{

            // make it like the door is throwing it 
            other.transform.position = destination.transform.position;  
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.AddForce(-1 * transform.right * force, ForceMode.Impulse);
                // also add some rotation to it
                rb.AddTorque(transform.up * RotationForce, ForceMode.Impulse);
            }
       }

      
                        // particles.SetActive(true);
            // sound.Play();
        
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         particles.SetActive(false);
    //     }
    // }
}

