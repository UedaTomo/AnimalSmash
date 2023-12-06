using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPointMoveScript : MonoBehaviour
{
    void Update()
    {
        // カメラからマウスがある場所に向かってRayを発射
        RaycastHit hit;
        // layer7と9の"Player"と"Attack"には当たらないためのマスク
        int layerMask = ~(1 << 7 | 1 << 9);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            // Rayが当たった所にカーソルを移動させる
            transform.position = hit.point;
        }
    }
}