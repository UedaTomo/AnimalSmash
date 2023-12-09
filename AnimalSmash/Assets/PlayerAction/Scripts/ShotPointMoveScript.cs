using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPointMoveScript : MonoBehaviour
{

    [SerializeField] private float sensitivity = 4.0f; // �}�E�X�̊��x
    [SerializeField] private float maxRotationAngle = 60f; // �ő��]�p�x

    private float rotationY = 0f;

    void Update()
    {
        // �}�E�X�̐��������̈ړ��ʂ��擾
        float mouseX = Input.GetAxis("Mouse X");

        // �ړ��ʂɊ��x���|���Ē���
        float horizontalMovement = mouseX * sensitivity;

        // ���݂�Y����]���X�V
        rotationY += horizontalMovement;

        // Y����]�𐧌�
        rotationY = Mathf.Clamp(rotationY, -maxRotationAngle, maxRotationAngle);

        // �I�u�W�F�N�g�̉�]���X�V
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
        Vector3[] points = { transform.position, transform.position, transform.position };
    }
}