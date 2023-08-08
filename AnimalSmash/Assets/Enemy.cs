using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;        // �^�[�Q�b�g
    public float shrinkRate = 1.0f; // �k����

    private NavMeshAgent myAgent;
    private Vector3 initialScale;
    private float initialDistance;

    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        initialScale = transform.localScale;
        initialDistance = Vector3.Distance(transform.position, target.position);
    }

    private void Update()
    {
        myAgent.SetDestination(target.position);
        // �^�[�Q�b�g�Ɉړ�
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        // �I�u�W�F�N�g�ƃ^�[�Q�b�g�̋������擾
        float scale = Mathf.Lerp(1.0f, initialScale.x * shrinkRate, distanceToTarget / initialDistance);
        // �������߂Â��ɂ�ăI�u�W�F�N�g���k��
        transform.localScale = new Vector3(scale, scale, scale);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("destroy"))
        {
            Destroy(gameObject);
        }
    }
}
