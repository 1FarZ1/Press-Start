using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GUIController : MonoBehaviour
{
    public static GUIController Instance;
    public TextMeshProUGUI CollectableText;
    public TextMeshProUGUI CurrentIslandText;
    [Header("Helpers Text")]
    public Text InteractionText;
    public Text InputsText;
    public GameObject NewIslandObject;
    public float NewIslandTime = 3;
    [Header("Pause Menu")]
    public GameObject InGameUIObject;
    public GameObject PauseMenuObject;

    void Start()
    {
        Instance = this;
        InteractionText.gameObject.SetActive(false);
        InputsText.gameObject.SetActive(false);
        ExitPause();

        //Lock The Cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

  
    void Update()
    {

        CollectableText.text = PlayerController.Instance.CounterScore.ToString();
        CurrentIslandText.text = PlayerController.Instance.CurrentIsland.IslandName;

        if (Input.GetKeyDown(KeyCode.Escape))
            EnterPause();
    }

    public void OneFrameText(Text TMP, string txt)
    {
        if (gameObject.activeSelf)
        {
            TMP.gameObject.SetActive(true);
            TMP.text = txt;
            StartCoroutine(IDisableText(TMP));
        }
    }
    public IEnumerator IDisableText(Text TMP)
    {
        yield return new WaitForEndOfFrame();
        TMP.gameObject.SetActive(false);
    }

    public void MoveValue(ref float value, float Destination, float speed)
    {
        if(value < Destination)
            value = Mathf.Clamp(value + Time.deltaTime, value, Destination);

        if (value > Destination)
            value = Mathf.Clamp(value - Time.deltaTime, Destination, value);
    }


    public void NewIslandUnlocked()
    {
        NewIslandObject.SetActive(true);
        StartCoroutine(INewIslandUnlocked());
    }

    private IEnumerator INewIslandUnlocked()
    {
        yield return new WaitForSeconds(NewIslandTime);
        NewIslandObject.SetActive(false);
    }

    public void EnterPause()
    {
        InGameUIObject.SetActive(false);
        PauseMenuObject.SetActive(true);
        Time.timeScale = 0;
        CameraController.Instance.CanMove = false;

        //UnLock The Cursor
        Cursor.lockState = CursorLockMode.None;

    }
    public void ExitPause()
    {
        InGameUIObject.SetActive(true);
        PauseMenuObject.SetActive(false);
        Time.timeScale = 1;
        CameraController.Instance.CanMove = true;

        //Lock The Cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadScene(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }
}
