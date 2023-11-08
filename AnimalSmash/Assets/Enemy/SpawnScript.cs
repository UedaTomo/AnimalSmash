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

    private float time;
    private float Destroytime;

    // Start is called before the first frame update
    void Start()
    {
        time = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if (time > 10.0f)
        {
            for(int i = 0; i < 4; i++)
            {

            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            float y = 3.86f;
            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            Instantiate(createPrefab, new Vector3(x, y, z), createPrefab.transform.rotation);
            }

            time = 0f;
        }
    }
}