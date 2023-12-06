using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPointMoveScript : MonoBehaviour
{
    void Update()
    {
        // �J��������}�E�X������ꏊ�Ɍ�������Ray�𔭎�
        RaycastHit hit;
        // layer7��9��"Player"��"Attack"�ɂ͓�����Ȃ����߂̃}�X�N
        int layerMask = ~(1 << 7 | 1 << 9);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            // Ray�������������ɃJ�[�\�����ړ�������
            transform.position = hit.point;
        }
    }
}