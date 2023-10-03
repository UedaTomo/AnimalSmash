using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    [SerializeField] private float bounceForce = 500f;
    public GameObject StrikeZone; // 敵の侵入を検知する範囲のゲームオブジェクト

    private Rigidbody rb;
    private Collider strikezoneCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbodyが見つかりません。");
        }

        strikezoneCollider = StrikeZone.GetComponent<Collider>();
        if (strikezoneCollider == null)
        {
            Debug.LogError("StrikeZoneにColliderが見つかりません。");
        }
    }

    //OnTrigger->接触判定を取る関数

    private void Update()
    {
        // 敵の侵入を検知する範囲内に敵が侵入した場合
        if (strikezoneCollider.bounds.Intersects(rb.GetComponent<Collider>().bounds))
        {
            // マウスの左クリックを検知
            if (Input.GetMouseButtonDown(0))
            {
                // 跳ね返す力を加える
                Vector3 bounceDirection = (transform.position - StrikeZone.transform.position).normalized;
                rb.AddForce(bounceDirection * bounceForce);
            }
        }
    }
}