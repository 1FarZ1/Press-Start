using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    public Transform IslandSpawnPoint;
    public string IslandName;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            if (PlayerController.Instance.CurrentIsland != this)
            {
                GUIController.Instance.NewIslandUnlocked();
                //AudioManager.Instance.PlaySFX("missioncompleted");
            }
            PlayerController.Instance.CurrentIsland = this;
        }
    }
}
