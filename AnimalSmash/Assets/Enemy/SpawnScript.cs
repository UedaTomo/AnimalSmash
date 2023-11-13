using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField]
    [Tooltip("enemy")]
    private GameObject createPrefab;
    [SerializeField]
    [Tooltip("SpawnPointA")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("SpawnPointB")]
    private Transform rangeB;

    public float interval = 10.0f;
    public float levelup_time = 20.0f;
    public float _interval = 8.0f;

    private float lowest_interval;
    private bool levelup;
    private float time = 0f;
    private float TIME = 0f;
    private float Destroytime;
    private int SpawnNum = 1;

    // Start is called before the first frame update
    void Start()
    {
        //time = 5.0f;
        levelup = false;
        lowest_interval = interval - (_interval * 1);
        UsagiSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        TIME += Time.deltaTime;
        time = time + Time.deltaTime;

        if (interval > lowest_interval)
        {
            if (TIME > levelup_time)
            {
                levelup = true;
                TIME = 0f;
            }

            if (levelup)
            {
                Debug.Log("aaa");
                interval -= _interval;
                levelup = false;
            }
        }

        if (time > interval)
        {
            for(int i = 0; i < SpawnNum; i++)
            {
                UsagiSpawn();
            }

            time = 0f;
        }
    }

    private void UsagiSpawn()
    {
        float x = Random.Range(rangeA.position.x, rangeB.position.x);
        float y = 3.86f;
        float z = Random.Range(rangeA.position.z, rangeB.position.z);

        Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);
    }
}
