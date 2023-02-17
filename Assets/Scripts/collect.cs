using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{ 
    private void OnTriggerEnter(Collider other) {
        if(other.transform.GetComponent<PlayerController>()){
            PlayerController.Instance.CounterScore += 1;
            Destroy(gameObject);
            // AudioManager.Instance.PlaySFX("coin");

        }
    }
}
