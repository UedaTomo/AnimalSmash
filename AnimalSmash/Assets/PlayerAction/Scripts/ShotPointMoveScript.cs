using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPointMoveScript : MonoBehaviour
{

    [SerializeField] private float sensitivity = 4.0f; // マウスの感度
    [SerializeField] private float maxRotationAngle = 60f; // 最大回転角度

    private float rotationY = 0f;

    void Update()
    {
        // マウスの水平方向の移動量を取得
        float mouseX = Input.GetAxis("Mouse X");

        // 移動量に感度を掛けて調整
        float horizontalMovement = mouseX * sensitivity;

        // 現在のY軸回転を更新
        rotationY += horizontalMovement;

        // Y軸回転を制限
        rotationY = Mathf.Clamp(rotationY, -maxRotationAngle, maxRotationAngle);

        // オブジェクトの回転を更新
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
        Vector3[] points = { transform.position, transform.position, transform.position };
    }
}