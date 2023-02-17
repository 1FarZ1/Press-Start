using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public float Distance = 2.0f;
    public LayerMask layerMask;
    private Camera cam;
    public bool PickedUp = false;
    public float throwForce = 10.0f;
    [HideInInspector]public Rigidbody PickUpItemRb;
    public float speed = 10.0f;
    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {


        if (PickedUp)
        {

            PickUpItemRb.transform.position = Vector3.Lerp(PickUpItemRb.transform.position, PlayerController.Instance.HandPickUp.transform.position, speed * Time.deltaTime);
            PickUpItemRb.transform.rotation = Quaternion.Lerp(PickUpItemRb.transform.rotation, PlayerController.Instance.HandPickUp.transform.rotation, speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PickedUp)
            {
                PickedUp = false;
                PickUpItemRb.GetComponent<Collider>().enabled = true;
                PickUpItemRb.isKinematic = false;
                PickUpItemRb.transform.parent = null;
                PickUpItemRb.AddForce(cam.transform.forward * throwForce, ForceMode.Impulse);
                PickUpItemRb = null;


            }
            else
            {

                RaycastHit hit;
                Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

                if (Physics.Raycast(rayOrigin, cam.transform.forward, out hit, Distance, layerMask))
                {

                    if (hit.collider.tag == "Pickup")
                    {


                        PickedUp = true;
                        PickUpItemRb = hit.collider.GetComponent<Rigidbody>();
                        hit.collider.GetComponent<Collider>().enabled = false;
                        PickUpItemRb.isKinematic = true;

                    }

                }
            }
        }
    }
}

