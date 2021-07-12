using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SafeNet : MonoBehaviour
{
    public GameObject Dead;
    public GameObject Win;

    private Text text;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag != "Player")
        {
            Destroy(col.gameObject);
        }
        else
        {
            Destroy(col.gameObject);

            Dead.GetComponent<Text>().enabled = true;

            Invoke("LoadTitle", 3);
        }
    }

    private void LoadTitle()
    {
        Dead.GetComponent<Text>().enabled = false;
        Win.GetComponent<Text>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene("Title");
    }
}
