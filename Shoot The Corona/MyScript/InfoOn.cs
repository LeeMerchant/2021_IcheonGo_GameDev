using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoOn : MonoBehaviour
{
    public GameObject Info;

    void Start()
    {
        Info.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void EnterInfo()
    {
        Info.SetActive(true);
    }

    public void ExitInfo()
    {
        Info.SetActive(false);
    }
}
