using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandedScript : MonoBehaviour
{
    public GameObject shotPoint; // ボール発射ポイント
    public GameObject bulletPrefab; // ボールのプレハブ
    [SerializeField] private float bulletSpeed = 10.0f; // ボールの速度
    [SerializeField] private float minAngle = -45.0f; // 最小角度
    [SerializeField] private float maxAngle = 45.0f; // 最大角度

    private GameObject targetEnemy = null; // 現在のターゲットとなる enemy タグのオブジェクト

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && targetEnemy != null)
        {
            Destroy(targetEnemy); // 現在のターゲットを破棄する
            Shooting(); 

            Debug.Log("R shot");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            targetEnemy = other.gameObject; // enemy タグを持つオブジェクトをターゲットに設定

            Debug.Log("R target");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == targetEnemy)
        {
            targetEnemy = null; // ターゲットとなる enemy タグのオブジェクトが領域外に出たら null に設定
        }
    }

    private void Shooting()
    {
        // マウスからのクリック位置をワールド座標に変換
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // ボールを発射する処理
            GameObject ball = Instantiate(bulletPrefab); // Bullet プレハブを生成
            ball.transform.position = shotPoint.transform.position;

            // ボールの速度を設定
            Rigidbody bulletRigidbody = ball.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                // クリックした位置を向く方向を計算
                Vector3 shootDirection = hit.point - shotPoint.transform.position;
                shootDirection.Normalize();

                // Y軸回転を制限
                float angle = Vector3.SignedAngle(Vector3.forward, shootDirection, Vector3.up);
                angle = Mathf.Clamp(angle, minAngle, maxAngle); // 角度を制限

                // 制限された角度を元に方向を再計算
                Quaternion rotation = Quaternion.Euler(0, angle, 0);
                Vector3 limitedDirection = rotation * Vector3.forward;

                // ボールの速度を設定
                bulletRigidbody.velocity = limitedDirection * bulletSpeed;
            }

            // 必要に応じてボールの発射音やエフェクトを再生するなどの処理を追加できます
        }
    }
}