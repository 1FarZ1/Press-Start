using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElvButton : MonoBehaviour
{
    public GameObject elevator;
    private elevator Elv;
    // check if its up button or down button
    public bool upButton;
    
     private void Start() {
                Elv=elevator.GetComponent<elevator>();    
    }
    // Detect the collision with the player not the trigger
    private void OnTriggerEnter(Collider other)
    {
        print("Collided");
        // If the player is colliding with the button
        if (other.gameObject.tag == "Player")
        {   

            
            if(upButton){
                Elv.MoveElevatorUp();
            }
            else{
                Elv.MoveElevatorDown();
            }
      
        }
    }
  
}
