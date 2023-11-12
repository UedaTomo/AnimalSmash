using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandedScript : MonoBehaviour
{
    public GameObject shotPoint; // �{�[�����˃|�C���g
    public GameObject bulletPrefab; // �{�[���̃v���n�u
    [SerializeField] private float bulletSpeed = 10.0f; // �{�[���̑��x

    private GameObject targetEnemy = null; // ���݂̃^�[�Q�b�g�ƂȂ� enemy �^�O�̃I�u�W�F�N�g

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && targetEnemy != null)
        {
            Destroy(targetEnemy); // ���݂̃^�[�Q�b�g��j������
            Shooting();

            //Debug.Log("L shot");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            targetEnemy = other.gameObject; // enemy �^�O�����I�u�W�F�N�g���^�[�Q�b�g�ɐݒ�

            //Debug.Log("L target");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == targetEnemy)
        {
            targetEnemy = null; // �^�[�Q�b�g�ƂȂ� enemy �^�O�̃I�u�W�F�N�g���̈�O�ɏo���� null �ɐݒ�
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
