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
    public int spawnPointNum = 6;
    public int spawnPointWork = 3;
    private int[] numbers = new int[6];
    private float time = 0f;
    private int[] randomPosition = new int[3];

    // Start is called before the first frame update
    void Start()
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

            newEnemy.transform.position = spawnPoint[randomPosition[i]].position;

            Vector3 left = new Vector3(1.0f, 0, -0.7f);
            //pos.z = spawnPoint[randomPosition[i]].position.z - 1.0f; //x,z‚ð•Ï‚¦‚æ‚¤
            //pos.x = spawnPoint[randomPosition[i]].position.x + 1.0f;
            newEnemy1.transform.position = pos + left;

            Vector3 right = new Vector3(1.0f, 0, 0.7f);
            //pos.z = spawnPoint[randomPosition[i]].position.z + 2.0f;
            newEnemy2.transform.position = pos + right;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >interval)
        {
            for(int i = 0; i < spawnPointNum ;i++)
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
            for (int i=0;i<spawnPointWork;i++)
            {
                randomPosition[i] = numbers[i];
            }

            for (int i = 0;i < spawnPointWork; i++)
            {
                GameObject newEnemy = Instantiate(Enemy);
                GameObject newEnemy1 = Instantiate(Enemy);
                GameObject newEnemy2 = Instantiate(Enemy);
                Vector3 pos = spawnPoint[randomPosition[i]].position;

                newEnemy.transform.position = spawnPoint[randomPosition[i]].position;

                Vector3 left = new Vector3(1.0f, 0, -0.7f);
                //pos.z = spawnPoint[randomPosition[i]].position.z - 1.0f; //x,z‚ð•Ï‚¦‚æ‚¤
                //pos.x = spawnPoint[randomPosition[i]].position.x + 1.0f;
                newEnemy1.transform.position = pos + left;

                Vector3 right = new Vector3(1.0f, 0, 0.7f);
                //pos.z = spawnPoint[randomPosition[i]].position.z + 2.0f;
                newEnemy2.transform.position = pos + right;
            }

            time = 0f;
        }
    }
}
