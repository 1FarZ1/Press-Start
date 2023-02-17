using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clicksound : MonoBehaviour
{
    public AudioSource click ;

    // Start is called before the first frame update
    void Start()
    {
        click = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        click.Play();
    }
}
