using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public GameObject Textobj;
    public GameObject Late;
    public GameObject Wintime;
    public GameObject Win;
    public GameObject Win2;

    private float time_start;
    public float time_current;
    private float time_Max = 40f;

    private UnityEngine.UI.Text text;
    private UnityEngine.UI.Text Wintimetext;

    private float timer;
    private float waitingTime;

    private void Start()
    {
        text = Textobj.GetComponent<Text>();

        time_start = 0f;
        time_current = 0f;

        timer = 0.0f;
        waitingTime = 1f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitingTime)
        {
            time_current = time_current + (1f/60f * 4f);
            int timeint = (int)time_current;
            text.text = timeint.ToString();

            timer = 0;
        }

        if (time_current > time_Max)
        {
            Late.GetComponent<Text>().enabled = true;

            Invoke("LoadTitle", 3);
        }
    }

    public void win()
    {
        Win.GetComponent<Text>().enabled = true;
        Win2.GetComponent<Text>().enabled = true;

        Wintimetext = Wintime.GetComponent<Text>();
        int a = (int)time_current;
        Wintimetext.text = a.ToString();
        Wintime.GetComponent<Text>().enabled = true;

        Invoke("LoadTitle", 3);
    }

    void LoadTitle()
    {
        Late.GetComponent<Text>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene("Title");
    }
}
