using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    //����
    private bool start;
    private bool Frag;
    CountDown countdownscript;
    MoveEnemy moveenemy;
    public GameObject obj;

    //�E�T�M
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
    public float usagi_levelup_time = 15.0f;//15�b�o�����烌�x���A�b�v
    public float _interval = 2.0f; //���x���A�b�v���Ɍ��݂̃C���^�[�o���������
    public Material usagi;
    public Material Powerup_usagi;

    private float usagi_lowest_interval = 1.0f;
    private float usagi_spawn_TIME = 0f;
    private float usagi_levelup_TIME = 0f;
    private int SpawnNum = 1;
    private bool usagi_levelup;

    //�q�c�W(�P��)
    public float hituzi_spawn_interval = 5.0f; 
    public float hituzi_interval_1;
    public float hituzi_interval_2;
    public float hituzi_levelup_time = 10.0f; //�q�c�W��10�b�o�����烌�x���A�b�v

    private float hituzi_levelup__TIME = 0f;
    private float hituzi_lowest_interval = 0f;
    private float hituzi_spawn_TIME = 0f;
    private float hituzi_levelup_TIME = 0f;
    private float hituzi_second = 0f;
    private int SpawnNumber = 1;
    private int count;
    private bool hituzi_levelup;
    private bool start_spawn;

    //�q�c�W(�c��)
    public GameObject Enemys;
    public GameObject Enemy;
    public Transform[] spawnPoint;
    public float Flock_hituzi_interval;
    public int Flock_hituzi_levelup = 1;
    public int spawnPointNum = 5; //�X�|�[���|�C���g�̐�
    public int spawnPointWork = 1;
    public float midium_time = 20.0f;
    public float difficult_time = 50.0f;
    public int levelup_interval = 2;

    //private float hituzi_levelup_TIME = 0f;
    private float Flock_hituzi_spawn_TIME = 0f;
    private float hituzi_spawn_TIME_1 = 0f;
    private float hituzi_spawn_TIME_2 = 0f;
    private int[] randomPosition = new int[3];
    private int[] numbers = new int[4];
    private int recode = 6; //�O�Ƀq�c�W�c�̂��X�|�[�������Ƃ���
    private int RumdomSpawn;


    // Start is called before the first frame update
    void Start()
    {
        start = false;
        Frag = false;

        start_spawn = false;

        obj = GameObject.Find("Canvas");
        countdownscript = obj.GetComponent<CountDown>();
        moveenemy = createPrefab.GetComponent<MoveEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownscript.start)
        {
            if (start == Frag)//�ŏ��̓G
            {
                createPrefab.GetComponent<MeshRenderer>().material = usagi;
                UsagiSpawn();
                FlockSheepSpawn();
                start = true;
            }

            //���Ԍo��
            usagi_levelup_TIME += Time.deltaTime;
            usagi_spawn_TIME += Time.deltaTime;

            hituzi_spawn_TIME += Time.deltaTime;
            hituzi_spawn_TIME_1 += Time.deltaTime;
            hituzi_spawn_TIME_2 += Time.deltaTime;
            hituzi_levelup_TIME += Time.deltaTime;

            Flock_hituzi_spawn_TIME += Time.deltaTime;

            //�E�T�M���x���A�b�v
            /*if (usagi_interval > usagi_lowest_interval)
            {
                if (usagi_levelup_TIME > usagi_levelup_time)
                {
                    usagi_levelup = true;
                    usagi_levelup_TIME = 0f;
                }

                if (usagi_levelup)
                {
                    usagi_interval -= _interval;
                    usagi_levelup = false;
                }
            }*/

            //�q�c�W���x���A�b�v
            if (hituzi_spawn_interval > hituzi_lowest_interval)
            {
                if (hituzi_levelup_TIME > hituzi_levelup_time)
                {
                    hituzi_levelup = true;
                    hituzi_levelup_TIME = 0f;
                }

                if (hituzi_levelup)
                {
                    hituzi_spawn_interval -= _interval;
                    Debug.Log("level");
                    hituzi_levelup = false;
                }

                if (hituzi_spawn_interval <= 1.0f)
                {
                    hituzi_spawn_interval = 0f;
                    Debug.Log("levelfinish");
                }
            }

            //�E�T�Mspawn
            if (usagi_spawn_TIME > usagi_interval)
            {
                int random = Random.Range(0, 8);

                if (random == 0)
                {
                    createPrefab.GetComponent<MeshRenderer>().material = Powerup_usagi;
                    moveenemy.move = 0.2f;
                }
                else
                {
                    createPrefab.GetComponent<MeshRenderer>().material = usagi;
                    moveenemy.move = 0.05f;
                }

                for (int i = 0; i < SpawnNum; i++)
                {
                    UsagiSpawn();
                }

                usagi_spawn_TIME = 0f;
            }

            /*if (spawnPointWork == 1 && hituzi_levelup_TIME >= midium_time)
            {
                spawnPointWork += Flock_hituzi_levelup;
                Flock_hituzi_interval -= levelup_interval;
            }
            if (spawnPointWork == 2 && hituzi_levelup_TIME >= difficult_time)
            {
                spawnPointWork += Flock_hituzi_levelup;
                //Flock_hituzi_interval -= usagi_levelup_time;
            }*/

            /*if (hituzi_levelup_TIME >= midium_time)
            {
                hituzi_spawn_interval = 3.0f;
            }
            if (hituzi_levelup_TIME >= difficult_time)
            {

            }*/

            //�q�c�W�i�́jspawn
            /*if (hituzi_spawn_TIME > hituzi_spawn_interval)
            {
                SheepSpawn();

                hituzi_spawn_TIME = 0f;
            }
            if (hituzi_spawn_TIME_1 > hituzi_interval_1)
            {
                SheepSpawn();

                hituzi_spawn_TIME_1 = 0f;
            }
            if (hituzi_spawn_TIME_2 > hituzi_interval_2)
            {
                SheepSpawn();

                hituzi_spawn_TIME = 0f;
                hituzi_spawn_TIME_1 = 0f;
                hituzi_spawn_TIME_2 = 0f;
            }*/

            if (hituzi_spawn_TIME > hituzi_spawn_interval)
            {
                if (start_spawn == Frag)
                {
                    SheepSpawn();
                    start_spawn = true;
                    count = 0;
                }

                if(start_spawn)
                {
                    hituzi_second += Time.deltaTime;

                    if (hituzi_second > 1.0f)
                    {
                        SheepSpawn();

                        count++;
                        hituzi_second = 0f;
                    }
                    if (count >= 2)
                    {
                        hituzi_spawn_TIME = 0f;
                        start_spawn = false;
                    }
                }
            }

            //�q�c�W�i�c�́jspawn
            if (Flock_hituzi_spawn_TIME > Flock_hituzi_interval)
            {
                FlockSheepSpawn();

                Flock_hituzi_spawn_TIME = 0f;
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
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            float y = 3.86f;
            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            Instantiate(Enemy, new Vector3(x, y, z), Enemy.transform.rotation);
    }

    private void FlockSheepSpawn()
    {
        /*for (int i = 0; i < spawnPointNum; i++)
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
            GameObject newEnemy = Instantiate(Enemys);
            GameObject newEnemy1 = Instantiate(Enemys);
            GameObject newEnemy2 = Instantiate(Enemys);
            Vector3 pos = spawnPoint[randomPosition[i]].position;

            newEnemy.transform.position = spawnPoint[randomPosition[i]].position;

            Vector3 left = new Vector3(-0.7f, 0, 1.0f);
            newEnemy1.transform.position = pos + left;

            Vector3 right = new Vector3(0.7f, 0, 1.0f);
            newEnemy2.transform.position = pos + right;
        }*/
            do
            {
                RumdomSpawn = Random.Range(0, spawnPointNum);

            } while (RumdomSpawn == recode);

            GameObject newEnemy = Instantiate(Enemys);
            GameObject newEnemy1 = Instantiate(Enemys);
            GameObject newEnemy2 = Instantiate(Enemys);
            Vector3 pos = spawnPoint[RumdomSpawn].position;

            newEnemy.transform.position = spawnPoint[RumdomSpawn].position;

            Vector3 left = new Vector3(-0.7f, 0, 1.0f);
            newEnemy1.transform.position = pos + left;

            Vector3 right = new Vector3(0.7f, 0, 1.0f);
            newEnemy2.transform.position = pos + right;

            recode = RumdomSpawn;
    }
}