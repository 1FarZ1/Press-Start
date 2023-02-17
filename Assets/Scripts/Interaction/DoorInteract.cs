using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    
    private Animator DoorAnim;
    private void Start()
    {
        DoorAnim = GetComponent<Animator>();
    }
    public void InteractWithDoor()
    {
        DoorAnim.SetBool("Open", !DoorAnim.GetBool("Open"));
    }

    public void OpenDoor()
    {
       


        DoorAnim.SetBool("Open", true);
      
    }
    public void CloseDoor()
    {
        DoorAnim.SetBool("Open", false);
    }
}
