using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandedScript : MonoBehaviour
{
    public GameObject shotPoint; // ボール発射ポイント
    public GameObject bulletPrefab; // ボールのプレハブ
    public GameObject sheepBullet; //打ち返した羊のオブジェクト
    public GameObject rabbitBullet; //打ち返した兎のオブジェクト
    public GameObject birdBullet; //打ち返した鳥のオブジェクト
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip FlockSE;
    bool FlockShot = false;

    [SerializeField] private float bulletSpeed = 10.0f; // ボールの速度

    private GameObject targetEnemy = null; // 現在のターゲットとなる enemy タグのオブジェクト
    private void Update()
    {
        if (Input.GetButtonDown("Shot")) // マウスクリックまたはコントローラーのRトリガーボタンが押されたら
        {

            if (targetEnemy != null)
            {
                Destroy(targetEnemy); // 現在のターゲットを破棄する
                Shooting();
            }
            if(FlockShot)
            {
                Shooting() ;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            targetEnemy = other.gameObject; // enemy タグを持つオブジェクトをターゲットに設定
            bulletPrefab = sheepBullet;
        }
        if (other.CompareTag("bird"))
        {
            targetEnemy = other.gameObject; // bird タグを持つオブジェクトをターゲットに設定
            bulletPrefab = birdBullet;
        }
        if (other.CompareTag("rabbit"))
        {
            targetEnemy = other.gameObject; // rabbit タグを持つオブジェクトをターゲットに設定
            bulletPrefab = rabbitBullet;
        }
        if (other.CompareTag("Flock"))
        {
            FlockShot = true;
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
        if(FlockShot)
        {
            _source.PlayOneShot(FlockSE);
            FlockShot = false;
        }
        else
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
}