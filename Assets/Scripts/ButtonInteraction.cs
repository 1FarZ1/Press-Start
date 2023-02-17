using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public DoorInteract TargetDoor;
 

    public float CloseTime;

    private float CloseTimer;

    private Animator ButtonAnim;
    private bool Effective;
    private void Start()
    {
        ButtonAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Effective)
        {
            CloseTimer -= Time.deltaTime;
            if (CloseTimer < 0)
            {
                Effective = false;
            }
        }

        if (Effective)
            TargetDoor.OpenDoor();
        else
            TargetDoor.CloseDoor();
    }

    private void OnTriggerStay(Collider other)
    {
        ButtonAnim.SetBool("Clicked", true);
        Effective = true;
        CloseTimer = CloseTime;
    
    }
    private void OnTriggerEnter(Collider other)
    {
        //AudioManager.Instance.PlaySFX("click");
    }


    private void OnTriggerExit(Collider other)
    {
        ButtonAnim.SetBool("Clicked", false);
    }
}
