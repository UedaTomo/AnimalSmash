using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPointMoveScript : MonoBehaviour
{
    void Update()
    {
        // �J��������}�E�X������ꏊ�Ɍ�������Ray�𔭎�
        RaycastHit hit;

        // ���C���[�}�X�N�̐ݒ�
        int layerMask = 1 << 8; // "Floor" ���C���[�݂̂�Ώۂɂ���

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            // Ray�������������ɃJ�[�\�����ړ�������
            transform.position = hit.point;
        }
    }
}