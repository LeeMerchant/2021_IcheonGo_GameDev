using System.Collections;
using System.Collections.Generic;
using Unity.FPS.AI;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Gay : MonoBehaviour
{
    public GameObject GM;
    public GameObject scoretext;

    public int Killcount;

    void Start()
    {
        GM = GameObject.Find("GameManager");

        Killcount = GM.GetComponent<EnemyManager>().NoK;

        scoretext.GetComponent<Text>().text = Killcount.ToString();
    }

    void Update()
    {
        
    }
}
