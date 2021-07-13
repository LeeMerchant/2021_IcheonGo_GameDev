using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] points;
    public GameObject monsterPrefab;
    public GameObject bossPrefab;

    public float createTime;
    public int maxMonster = 10;
    public bool isGameOver = false;

    void Start()
    {
        points = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();

        if (points.Length > 0)
        {
            StartCoroutine(this.CreateMonster());
        }
    }

    IEnumerator CreateMonster()
    {
        while (!isGameOver)
        {
            int monsterCount = (int)GameObject.FindGameObjectsWithTag("MONSTER").Length;

            if (monsterCount < maxMonster)
            {
                yield return new WaitForSeconds(createTime);

                int idx = Random.Range(1, points.Length);
                
                if(Random.Range(0, 10) == 9)
                {
                    Instantiate(bossPrefab, points[idx].position, points[idx].rotation);
                }
                else
                {
                    Instantiate(monsterPrefab, points[idx].position, points[idx].rotation);

                }
            }
            else
            {
                yield return null;
            }
        }
    }
}
