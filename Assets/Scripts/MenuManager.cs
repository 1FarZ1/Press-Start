using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject Fade;
    public GameObject[] disableOBJ;
    public GameObject settings;
   public void Play(string scenename)
    {
        Fade.GetComponent<Animator>().SetTrigger("Fade");
        StartCoroutine(WaitFadeAnimation(scenename));
     
    }

    public void Settings()
    {
        for (int i = 0; i < disableOBJ.Length; i++)
        {
            disableOBJ[i].SetActive(false);
        }
        settings.SetActive(true);

    }
    public void back()
    {
        for (int i = 0; i < disableOBJ.Length; i++)
        {
            disableOBJ[i].SetActive(true);
        }
        settings.SetActive(false);
    }



    public void Exit()
    {
        Application.Quit();
    }

    private IEnumerator WaitFadeAnimation(string scenename)
    {
        yield return new WaitForSeconds(1);
       SceneManager.LoadScene(scenename);
    }
    


}
