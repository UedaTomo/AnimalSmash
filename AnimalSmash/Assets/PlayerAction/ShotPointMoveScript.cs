using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPointMoveScript : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5.0f; // 回転速度

    [SerializeField] private float minRotation = -80.0f; // 最小回転角度

    [SerializeField] private float maxRotation = 80.0f; // 最大回転角度

    private Quaternion initialRotation; // オブジェクトの初期角度

    void Start()
    {
        // オブジェクトの初期角度を記録
        initialRotation = transform.rotation;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        // オブジェクトの位置をスクリーン座標からワールド座標に変換
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        // マウス位置とオブジェクト位置の差分を計算
        Vector3 delta = mousePos - objectPos;

        // マウス位置とオブジェクト位置の差分を元にY軸回転角度を計算
        float angle = Mathf.Atan2(delta.x, delta.y) * Mathf.Rad2Deg;

        // 回転角度を制約
        angle = Mathf.Clamp(angle, minRotation, maxRotation);

        transform.rotation = initialRotation * Quaternion.Euler(0, angle, 0);

        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
}