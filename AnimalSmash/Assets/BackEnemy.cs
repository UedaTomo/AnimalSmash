using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class BackEnemy : MonoBehaviour
{
    public GameObject Enemy;
    public Transform[] points;
    private int destPoint = 0;
    private float Scale = 0.0003f;
    private NavMeshAgent agent;
    private Vector3 pos;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        pos = Enemy.transform.position;
    }

    void Update()
    {
        if (pos.x < 0)
        {
            destPoint = 0;
            agent.destination = points[destPoint].position;
        }
        else
        {
            destPoint = 1;
            agent.destination = points[destPoint].position;
        }

        this.transform.localScale -= new Vector3(Scale, Scale, Scale);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("destroy"))
        {
            Destroy(gameObject);
        }
    }
}
