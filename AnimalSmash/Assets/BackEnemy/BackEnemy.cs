using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class BackEnemy : MonoBehaviour
{
    public Transform[] Targets;
    public float speed = 5.0f;
    private int destPoint = 0;
    private float Scale = 0.0002f;

    void Start()
    {

    }

    void Update()
    { 
        if (transform.position.x < 0)
        {
            destPoint = 0;
            transform.position = Vector3.MoveTowards(transform.position, Targets[destPoint].position, speed * Time.deltaTime);
        }
        else
        {
            destPoint = 1;
            transform.position = Vector3.MoveTowards(transform.position, Targets[destPoint].position, speed * Time.deltaTime);
        }

        transform.localScale -= new Vector3(Scale, Scale, Scale);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("destroy"))
        {
            Destroy(gameObject);
        }
    }
}
