using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemRequest : MonoBehaviour
{
    public UnityEvent UseEvent;
    public string ItemName;
    public bool UseDestroy = true;
    public bool CheckForUse;
    private bool Inrange, Opened;
    public string InteractionName;
    public AudioSource SoundEffect1;
    public AudioSource SoundEffect2;

    public void Update()
    {
        if (!CheckForUse)
            Opened = false;
        if (Inrange && !Opened)
        {
            if (PlayerController.Instance.GetComponent<PlayerController>().CurrentItem != "" && ItemName == PlayerController.Instance.GetComponent<PlayerController>().CurrentItem)
            {
                if (GetComponent<Collider>().enabled)
                {
                    GUIController.Instance.OneFrameText(GUIController.Instance.InteractionText, "Press E to " + InteractionName);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        UseEvent.Invoke();
                        if (SoundEffect1 != null)
                            SoundEffect1.Play();
                        if (UseDestroy)
                            PlayerController.Instance.GetComponent<PlayerController>().CurrentItem = "";

                        Opened = true;
                        if (SoundEffect2 != null)
                        {
                            SoundEffect2.Play();
                            StartCoroutine(StopSound(2f, SoundEffect2));

                        }

                    }
                }
            }
            else
            {
                GUIController.Instance.OneFrameText(GUIController.Instance.InteractionText, "You need a " + ItemName + " to " + InteractionName);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PlayerController.Instance.gameObject)
        {
            Inrange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == PlayerController.Instance.gameObject)
        {
            Inrange = false;
        }
    }
    private IEnumerator StopSound(float t, AudioSource audio)
    {
        yield return new WaitForSeconds(t);
        audio.Stop();

    }

}
