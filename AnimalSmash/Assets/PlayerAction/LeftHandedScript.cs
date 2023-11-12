using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandedScript : MonoBehaviour
{
    public GameObject shotPoint; // ボール発射ポイント
    public GameObject bulletPrefab; // ボールのプレハブ
    [SerializeField] private float bulletSpeed = 10.0f; // ボールの速度

    private GameObject targetEnemy = null; // 現在のターゲットとなる enemy タグのオブジェクト

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && targetEnemy != null)
        {
            Destroy(targetEnemy); // 現在のターゲットを破棄する
            Shooting();

            //Debug.Log("L shot");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            targetEnemy = other.gameObject; // enemy タグを持つオブジェクトをターゲットに設定

            //Debug.Log("L target");
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
        // ボールを発射する処理
        GameObject ball = Instantiate(bulletPrefab); // Bulletプレハブを生成
        ball.transform.position = shotPoint.transform.position;

        // ボールの速度を設定
        Rigidbody bulletRigidbody = ball.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = shotPoint.transform.forward * bulletSpeed;
        }

        // 必要に応じてボールの発射音やエフェクトを再生するなどの処理を追加できる
    }
}
