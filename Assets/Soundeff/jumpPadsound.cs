using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPadsound : MonoBehaviour
{
    public AudioSource jumpSound ;
    // Start is called before the first frame update
    void Start()
    {

        jumpSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpSound.Play();
    }
}