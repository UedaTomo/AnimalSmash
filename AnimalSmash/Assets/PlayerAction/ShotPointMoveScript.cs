using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPointMoveScript : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5.0f; // ��]���x

    [SerializeField] private float minRotation = -80.0f; // �ŏ���]�p�x

    [SerializeField] private float maxRotation = 80.0f; // �ő��]�p�x

    private Quaternion initialRotation; // �I�u�W�F�N�g�̏����p�x

    void Start()
    {
        // �I�u�W�F�N�g�̏����p�x���L�^
        initialRotation = transform.rotation;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        // �I�u�W�F�N�g�̈ʒu���X�N���[�����W���烏�[���h���W�ɕϊ�
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        // �}�E�X�ʒu�ƃI�u�W�F�N�g�ʒu�̍������v�Z
        Vector3 delta = mousePos - objectPos;

        // �}�E�X�ʒu�ƃI�u�W�F�N�g�ʒu�̍���������Y����]�p�x���v�Z
        float angle = Mathf.Atan2(delta.x, delta.y) * Mathf.Rad2Deg;

        // ��]�p�x�𐧖�
        angle = Mathf.Clamp(angle, minRotation, maxRotation);

        transform.rotation = initialRotation * Quaternion.Euler(0, angle, 0);

        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
}