using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;        // ターゲット
    //public float shrinkRate = 1.0f; // 縮小率
    public float Speed = 3.0f;
    //private NavMeshAgent myAgent;
    //private Vector3 initialScale;
    //private float initialDistance;


    private void Start()
    {
        //myAgent = GetComponent<NavMeshAgent>();
        //initialScale = transform.localScale;
        //initialDistance = Vector3.Distance(transform.position, target.position);
    }

    private void Update()
    {
        transform.Translate(0, 0, Speed * -Time.deltaTime);

        //myAgent.SetDestination(target.position);
        // ターゲットに移動
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        // オブジェクトとターゲットの距離を取得
        //float scale = Mathf.Lerp(1.0f, initialScale.x * shrinkRate, distanceToTarget / initialDistance);
        // 距離が近づくにつれてオブジェクトを縮小
        //transform.localScale = new Vector3(scale, scale, scale);

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("destroy"))
        {
            Destroy(gameObject);
        }
    }
}