using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Linq;
using System;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Renderer _target; // 点滅させる対象
    [SerializeField] private float _cycle = 1;// 点滅周期[s]
    [SerializeField] float speed = 3f;
    [SerializeField] Material plane;

    public float stop = 0.5f;
    public float invicible_time = 2.0f;
    private float alpha_sin;
    private float touch_time = 0f;
    private float inv_time = 0f;
    private bool isTouch; //敵に当たったか当たってないか
    private bool Invincible; //無敵時間

    public GameObject damy;
    public GameObject stan;

    public Animator playeranim;
    public bool isMove;
    private bool front;

    // Start is called before the first frame update
    void Start()
    {
        isTouch = false;
        Invincible = false;
        isMove = false;

        playeranim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Transform playertransform = this.transform;
        playeranim.SetBool("walk", isMove);

        if (!isTouch)
        {
            isMove = false;
            front = true;

            //キー入力を取得
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            //移動方向の計算
            Vector3 moveDirection=new Vector3(horizontalInput,0f, verticalInput).normalized;

            //移動方向が変わる場合のみ回転を計算
            if (moveDirection.magnitude >= 0.1f)
            {
                //移動
                Vector3 moveVector = moveDirection * speed * Time.deltaTime;
                transform.Translate(moveVector, Space.World);

                //プレイヤーの正面を移動方向に向ける
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 0.1f);

                isMove = true;
                front = false;
            }

            if (front)
            {
                this.transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }

        if (isTouch)
        {
            touch_time += Time.deltaTime;


            if (touch_time >= stop)
            {
                isTouch = false;
                Invincible = true;
                touch_time = 0f;
            }

        }

        if (Invincible)
        {
            inv_time += Time.deltaTime;

            // 周期cycleで繰り返す値の取得
            // 0～cycleの範囲の値が得られる
            var repeatValue = Mathf.Repeat((float)inv_time, _cycle);

            // 内部時刻timeにおける明滅状態を反映
            _target.enabled = repeatValue >= _cycle * 0.5f;

            //Debug.Log("あたった！");

            if (inv_time >= invicible_time)
            {
                Invincible = false;
                _target.enabled = true;
                inv_time = 0f;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy")|| other.gameObject.CompareTag("rabbit")|| other.gameObject.CompareTag("bird"))
        {
            if (!Invincible)
            {
                isTouch = true;
                Vector3 effectPosition = new Vector3(this.transform.position.x, this.transform.position.y + 2f, this.transform.position.z);
                Instantiate(stan, effectPosition, Quaternion.identity);
            }
        }
    }
}