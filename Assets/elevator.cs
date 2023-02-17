using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform[] waypoints;
    public bool Done = true;

    int currentWaypoint = 0;
     private float startTime; 
    private float journeyLength; 

    void Start()
    {
        transform.position = waypoints[currentWaypoint].transform.position;
          startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, waypoints[currentWaypoint].transform.position);
    }

    public void MoveElevatorUp(){
        if(!Done){
            return;
        }
        Done=false;
       currentWaypoint= currentWaypoint < waypoints.Length - 1 ? currentWaypoint + 1 : waypoints.Length - 1;
       MoveElv(currentWaypoint);
    }
    public void MoveElevatorDown(){
        if(!Done){
            return;
        }
        Done=false;
        currentWaypoint = currentWaypoint > 0 ? currentWaypoint - 1 : 0;
        MoveElv(currentWaypoint);
    }
    private void MoveElv(int currentWaypoint) { 

         float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        LeanTween.move(this.gameObject, waypoints[currentWaypoint].transform.position, speed).setEase(LeanTweenType.easeOutExpo);
        LeanTween.delayedCall(this.gameObject, speed, () => { Done = true; });
    }
    }