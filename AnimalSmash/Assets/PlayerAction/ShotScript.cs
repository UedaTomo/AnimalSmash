using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public GameObject shotPoint; // �{�[�����˃|�C���g
    public GameObject bulletPrefab; // �{�[���̃v���n�u
    [SerializeField] private float bulletSpeed = 10.0f; // �{�[���̑��x

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(other.gameObject); // enemy �^�O�����I�u�W�F�N�g��j������

                Shooting(); // �{�[���𔭎˂��鏈�����s��
            }
        }
    }

    private void Shooting()
    {
        // �{�[���𔭎˂��鏈��
        GameObject ball = Instantiate(bulletPrefab); // Bullet�v���n�u�𐶐�
        ball.transform.position = shotPoint.transform.position;

        // �{�[���̑��x��ݒ�
        Rigidbody bulletRigidbody = ball.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = shotPoint.transform.forward * bulletSpeed;
        }

        // �K�v�ɉ����ă{�[���̔��ˉ���G�t�F�N�g���Đ�����Ȃǂ̏�����ǉ��ł���
    }
}

