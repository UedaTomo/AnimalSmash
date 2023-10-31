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


    //List<int> numbers = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
       
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

                pos.x = spawnPoint[randomPosition[i]].position.x - 2.0f;
                pos.z = spawnPoint[randomPosition[i]].position.z - 2.0f;
                newEnemy1.transform.position = pos;

                pos.x = spawnPoint[randomPosition[i]].position.x + 4.0f;
                newEnemy2.transform.position = pos;
            }

            //Debug.Log(randomPosition[0]);
            //Debug.Log(randomPosition[1]);
            //Debug.Log(randomPosition[2]);


            time = 0f;
        }
    }
}
