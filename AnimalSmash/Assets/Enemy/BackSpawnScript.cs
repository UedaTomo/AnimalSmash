using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Linq;

public class BackSpawnScript : MonoBehaviour
{
    public float speed = 10f;
    public GameObject Enemy;
    public Transform[] spawnPoint;
    public float interval = 5f;
    public int spawnPointNum = 4;
    public int spawnPointWork = 2;
    private int[] numbers = new int[4];
    private float time = 0f;
    private int[] randomPosition = new int[2];

    // Start is called before the first frame update
    void Start()
    {
        BackSpawn();
        
    }

    // Update is called once per frame
    void Update()
    {
        BackSpawn();
       
    }

    private void BackSpawn()
    {
        time += Time.deltaTime;

        if (time > interval)
        {
            for (int i = 0; i < spawnPointNum; i++)
            {
                numbers[i] = i;
            }
            for (int i = 0; i < spawnPointNum; i++)
            {
                int temp = numbers[i];
                int randomIndex = Random.Range(0, spawnPointNum);
                numbers[i] = numbers[randomIndex];
                numbers[randomIndex] = temp;
            }
            for (int i = 0; i < spawnPointWork; i++)
            {
                randomPosition[i] = numbers[i];
            }

            for (int i = 0; i < spawnPointWork; i++)
            {
                GameObject newEnemy = Instantiate(Enemy);
                GameObject newEnemy1 = Instantiate(Enemy);
                GameObject newEnemy2 = Instantiate(Enemy);
                Vector3 pos = spawnPoint[randomPosition[i]].position;

                newEnemy.transform.position = pos;

                Vector3 left = new Vector3(-0.7f, 0, 1.0f);
                newEnemy1.transform.position = pos + left;

                Vector3 right = new Vector3(0.7f, 0, 1.0f);
                newEnemy2.transform.position = pos + right;
            }

            time = 0f;
        }
    }
}
