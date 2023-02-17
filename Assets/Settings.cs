using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider PlayerSpeed,SFX, Ambient;
    public float sfx, ambient, playerspeed;
    public GameObject[] ON,OFF;
   public AudioSource Ambientsource, SFXsource;

    private void Update()
    {
        Ambientsource.volume = ambient;
        SFXsource.volume = sfx;


        playerspeed = PlayerSpeed.value;
        ambient = Ambient.value;
        sfx = SFX.value;

        if (Ambient.value == 0)
        {
            ON[0].SetActive(false);
            OFF[0].SetActive(true);
        }
        else
        {
            ON[0].SetActive(true);
            OFF[0].SetActive(false);
        }
        if (SFX.value == 0)
        {
            ON[1].SetActive(false);
            OFF[1].SetActive(true);
        }
        else
        {
            ON[1].SetActive(true);
            OFF[1].SetActive(false);
        }



    }

    public void Buttons(int index)
    {
        if (index == 1)
        {
            PlayerSpeed.value += 1/5f;
       

        }else if(index == 2)
        {
            if (Ambient.value > 0)
            {

                Ambient.value = 0;

            }
            else
            {
                Ambient.value = 1;
            }


        }
        else if (index == 3)
        {
            if (SFX.value > 0)
            {
                SFX.value = 0;
            }
            else
            {         
                SFX.value = 1;
            }
        }


    }






}
