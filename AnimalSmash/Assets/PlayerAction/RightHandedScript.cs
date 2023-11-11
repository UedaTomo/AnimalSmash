using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandedScript : MonoBehaviour
{
    public GameObject shotPoint; // �{�[�����˃|�C���g
    public GameObject bulletPrefab; // �{�[���̃v���n�u
    [SerializeField] private float bulletSpeed = 10.0f; // �{�[���̑��x
    [SerializeField] private float minAngle = -45.0f; // �ŏ��p�x
    [SerializeField] private float maxAngle = 45.0f; // �ő�p�x

    private GameObject targetEnemy = null; // ���݂̃^�[�Q�b�g�ƂȂ� enemy �^�O�̃I�u�W�F�N�g

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && targetEnemy != null)
        {
            Destroy(targetEnemy); // ���݂̃^�[�Q�b�g��j������
            Shooting(); 

            Debug.Log("R shot");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            targetEnemy = other.gameObject; // enemy �^�O�����I�u�W�F�N�g���^�[�Q�b�g�ɐݒ�

            Debug.Log("R target");
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
        // �}�E�X����̃N���b�N�ʒu�����[���h���W�ɕϊ�
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // �{�[���𔭎˂��鏈��
            GameObject ball = Instantiate(bulletPrefab); // Bullet �v���n�u�𐶐�
            ball.transform.position = shotPoint.transform.position;

            // �{�[���̑��x��ݒ�
            Rigidbody bulletRigidbody = ball.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                // �N���b�N�����ʒu�������������v�Z
                Vector3 shootDirection = hit.point - shotPoint.transform.position;
                shootDirection.Normalize();

                // Y����]�𐧌�
                float angle = Vector3.SignedAngle(Vector3.forward, shootDirection, Vector3.up);
                angle = Mathf.Clamp(angle, minAngle, maxAngle); // �p�x�𐧌�

                // �������ꂽ�p�x�����ɕ������Čv�Z
                Quaternion rotation = Quaternion.Euler(0, angle, 0);
                Vector3 limitedDirection = rotation * Vector3.forward;

                // �{�[���̑��x��ݒ�
                bulletRigidbody.velocity = limitedDirection * bulletSpeed;
            }

            // �K�v�ɉ����ă{�[���̔��ˉ���G�t�F�N�g���Đ�����Ȃǂ̏�����ǉ��ł��܂�
        }
    }
}