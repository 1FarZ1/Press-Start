using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorsound : MonoBehaviour
{
    public AudioSource doorSou;
    // Start is called before the first frame update
    void Start()
    {
        doorSou = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        doorSou.Play();
    }
}
