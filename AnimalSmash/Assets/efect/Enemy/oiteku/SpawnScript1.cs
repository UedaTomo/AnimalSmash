using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    //共通
    private bool start;
    private bool Frag;
    CountDown countdownscript;
    public GameObject obj;

    //ウサギ
    [SerializeField]
    [Tooltip("enemy")]
    private GameObject createPrefab;
    [SerializeField]
    [Tooltip("SpawnPointA")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("SpawnPointB")]
    private Transform rangeB;

    public float usagi_interval = 10.0f;
    public float levelup_time = 20.0f;//20秒経ったらレベルアップ
    public float _interval = 4.0f; //レベルアップ時に現在のインターバルから引く

    private float lowest_interval = 2.0f;
    private float usagi_spawn_TIME = 0f;
    private float usagi_levelup_TIME = 0f;
    private int SpawnNum = 1;
    private bool usagi_levelup;

    //ヒツジ
    public GameObject Enemy;
    public Transform[] spawnPoint;
    public int hituzi_interval = 5;
    public int hituzi_levelup = 1;
    public int spawnPointNum = 4;
    public int spawnPointWork = 1;
    public float midium_time = 20.0f;
    public float difficult_time = 50.0f;
    public int levelup_interval = 2;

    private float hituzi_levelup_TIME = 0f;
    private float hituzi_spawn_TIME = 0f;
    private int[] randomPosition = new int[3];
    private int[] numbers = new int[4];


    // Start is called before the first frame update
    void Start()
    {
        start = false;
        Frag = false;

        obj = GameObject.Find("Canvas");
        countdownscript = obj.GetComponent<CountDown>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownscript.start)
        {
            if (start == Frag)//最初の敵
            {
                UsagiSpawn();
                SheepSpawn();
                start = true;
            }

            //時間経過
            usagi_levelup_TIME += Time.deltaTime;
            usagi_spawn_TIME += Time.deltaTime;

            hituzi_levelup_TIME += Time.deltaTime;
            hituzi_spawn_TIME += Time.deltaTime;

            if (usagi_interval > lowest_interval)
            {
                if (usagi_levelup_TIME > levelup_time)
                {
                    usagi_levelup = true;
                    usagi_levelup_TIME = 0f;
                }

                if (usagi_levelup)
                {
                    usagi_interval -= _interval;
                    usagi_levelup = false;
                }
            }

            if (usagi_spawn_TIME > usagi_interval)
            {
                for (int i = 0; i < SpawnNum; i++)
                {
                    UsagiSpawn();
                }

                usagi_spawn_TIME = 0f;
            }

            if (spawnPointWork == 1 && hituzi_levelup_TIME >= midium_time)
            {
                spawnPointWork += hituzi_levelup;
                hituzi_interval -= levelup_interval;
            }
            if (spawnPointWork == 2 && hituzi_levelup_TIME >= difficult_time)
            {
                spawnPointWork += hituzi_levelup;
                //hituzi_interval -= levelup_time;
            }

            if (hituzi_spawn_TIME > hituzi_interval)
            {
                SheepSpawn();

                hituzi_spawn_TIME = 0f;
            }
        }
    }

    private void UsagiSpawn()
    {
        float x = Random.Range(rangeA.position.x, rangeB.position.x);
        float y = 3.86f;
        float z = Random.Range(rangeA.position.z, rangeB.position.z);

        Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);
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