using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float move = 0.01f;
    public float Up = -6.0f;
    public float Down = 0f;
    public float UpDown = 0.1f;
    public GameObject obj;

    PauseScript pausescript;

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Player");
        pausescript = obj.GetComponent<PauseScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pausescript.enemy_pause)
        {
            Vector3 position = new Vector3(0, Down, move);
            transform.Translate(position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("destroy"))
        {
            Destroy(gameObject);
        }
    }
}

