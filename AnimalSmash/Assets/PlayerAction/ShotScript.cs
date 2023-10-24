using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public GameObject shotPoint; // ボール発射ポイント
    public GameObject bulletPrefab; // ボールのプレハブ
    [SerializeField] private float bulletSpeed = 10.0f; // ボールの速度

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(other.gameObject); // enemy タグを持つオブジェクトを破棄する

                Shooting(); // ボールを発射する処理を行う
            }
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

