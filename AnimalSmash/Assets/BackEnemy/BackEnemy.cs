using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class BackEnemy : MonoBehaviour
{
    public Transform[] Targets;
    public float speed = 5.0f;
    private float StartPos;
    private int destPoint = 0;

    void Start()
    {
        StartPos = Mathf.Floor(this.transform.position.z);//–{”Ô‚Å•Ï‚¦‚é

    }

    void Update()
    { 
        if (StartPos >= 0)
        {
            destPoint = 0;
            this.transform.position = Vector3.MoveTowards(transform.position, Targets[destPoint].position, speed * Time.deltaTime);
        }
        else
        {
            destPoint = 1;
            this.transform.position = Vector3.MoveTowards(transform.position, Targets[destPoint].position, speed * Time.deltaTime);
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
