using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandedScript : MonoBehaviour
{

    public GameObject shotPoint; // �{�[�����˃|�C���g
    public GameObject bulletPrefab; // �{�[���̃v���n�u
    public GameObject sheepBullet; //�ł��Ԃ����r�̃I�u�W�F�N�g
    public GameObject rabbitBullet; //�ł��Ԃ����e�̃I�u�W�F�N�g
    public GameObject birdBullet; //�ł��Ԃ������̃I�u�W�F�N�g

    [SerializeField] private float bulletSpeed = 10.0f; // �{�[���̑��x
    //[SerializeField] private float minAngle = -45.0f; // �ŏ��p�x
    //[SerializeField] private float maxAngle = 45.0f; // �ő�p�x

    private GameObject targetEnemy = null; // ���݂̃^�[�Q�b�g�ƂȂ� enemy �^�O�̃I�u�W�F�N�g
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && targetEnemy != null)
        {
            Destroy(targetEnemy); // ���݂̃^�[�Q�b�g��j������
            Shooting();

            Debug.Log("L shot");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            targetEnemy = other.gameObject; // enemy �^�O�����I�u�W�F�N�g���^�[�Q�b�g�ɐݒ�
            bulletPrefab = sheepBullet;
        }
        if (other.CompareTag("bird"))
        {
            targetEnemy = other.gameObject; // bird �^�O�����I�u�W�F�N�g���^�[�Q�b�g�ɐݒ�
            bulletPrefab = birdBullet;
        }
        if (other.CompareTag("rabbit"))
        {
            targetEnemy = other.gameObject; // rabbit �^�O�����I�u�W�F�N�g���^�[�Q�b�g�ɐݒ�
            bulletPrefab = rabbitBullet;
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