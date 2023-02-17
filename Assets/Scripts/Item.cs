using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string ItemName;
    public bool Pickable;
    private bool Picked;
    private bool InRange;
    public void CanPick(int Time)
    {
        StartCoroutine(ICanPick(Time));
    }

    IEnumerator ICanPick(int Time)
    {
        yield return new WaitForSeconds(Time);
        Pickable = true;
    }
    public void Update()
    {
        if(InRange && Pickable && !Picked)
        {
            GUIController.Instance.OneFrameText(GUIController.Instance.InteractionText, "Press E to pick the " + ItemName);
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerController.Instance.CurrentItem = ItemName;
                Picked = true;
                 
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == PlayerController.Instance.gameObject)
        {
            InRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == PlayerController.Instance.gameObject)
        {
            InRange = false;
        }
    }
}
