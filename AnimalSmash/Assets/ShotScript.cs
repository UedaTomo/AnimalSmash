using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    [SerializeField] private float bounceForce = 500f;
    public GameObject StrikeZone; // �G�̐N�������m����͈͂̃Q�[���I�u�W�F�N�g

    private Rigidbody rb;
    private Collider strikezoneCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody��������܂���B");
        }

        strikezoneCollider = StrikeZone.GetComponent<Collider>();
        if (strikezoneCollider == null)
        {
            Debug.LogError("StrikeZone��Collider��������܂���B");
        }
    }

    //OnTrigger->�ڐG��������֐�

    private void Update()
    {
        // �G�̐N�������m����͈͓��ɓG���N�������ꍇ
        if (strikezoneCollider.bounds.Intersects(rb.GetComponent<Collider>().bounds))
        {
            // �}�E�X�̍��N���b�N�����m
            if (Input.GetMouseButtonDown(0))
            {
                // ���˕Ԃ��͂�������
                Vector3 bounceDirection = (transform.position - StrikeZone.transform.position).normalized;
                rb.AddForce(bounceDirection * bounceForce);
            }
        }
    }
}