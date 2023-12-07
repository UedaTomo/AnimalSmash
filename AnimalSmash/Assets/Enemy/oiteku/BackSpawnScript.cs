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
    public int interval = 5;
    public int levelup = 1;
    public int spawnPointNum = 4;
    public int spawnPointWork = 1;
    public float midium_time = 20.0f;
    public float difficult_time = 50.0f;
    public int levelup_time = 2;

    private float TIME = 0f;
    private float spawn_time = 0f;
    private int[] randomPosition = new int[3];
    private int[] numbers = new int[4];

    // Start is called before the first frame update
    void Start()
    {
        SheepSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        TIME += Time.deltaTime;
        spawn_time += Time.deltaTime;

        if (spawnPointWork == 1 && TIME >= midium_time)
        {
            spawnPointWork += levelup;
            interval -= levelup_time;
        }
        if (spawnPointWork == 2 && TIME >= difficult_time)
        {
            spawnPointWork += levelup;
            //interval -= levelup_time;
        }

        if (spawn_time > interval)
        {
            SheepSpawn();

            spawn_time = 0f;
        }
    }

    private void SheepSpawn()
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

                Vector3 left = new Vector3(-0.7f, 0, 1.0f);
                newEnemy1.transform.position = pos + left;

                Vector3 right = new Vector3(0.7f, 0, 1.0f);
                newEnemy2.transform.position = pos + right;
            }
    }
}
