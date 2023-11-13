using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPointMoveScript : MonoBehaviour
{
    void Update()
    {
        // カメラからマウスがある場所に向かってRayを発射
        RaycastHit hit;

        // レイヤーマスクの設定
        int layerMask = 1 << 8; // "Floor" レイヤーのみを対象にする

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            // Rayが当たった所にカーソルを移動させる
            transform.position = hit.point;
        }
    }
}