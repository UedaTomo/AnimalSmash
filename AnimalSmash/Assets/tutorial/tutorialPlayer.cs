using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Linq;
using System;

public class tutorialPlayer : MonoBehaviour
{
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

    public GameObject tuto;
    tutorial Tutorial;

    // Start is called before the first frame update
    void Start()
    {
        tuto = GameObject.Find("tutorial");
        Tutorial = tuto.GetComponent<tutorial>();

        isTouch = false;
        Invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Tutorial.AblePlay)
        {
            if (!isTouch)
            {
                // Wキー（前方移動）
                if (Input.GetKey(KeyCode.W) || Input.GetAxis("Vertical") > 0)
                {
                    transform.position += speed * transform.forward * Time.deltaTime;
                }

                // Sキー（後方移動）
                if (Input.GetKey(KeyCode.S) || Input.GetAxis("Vertical") < 0)
                {
                    transform.position -= speed * transform.forward * Time.deltaTime;
                }

                // Dキー（右移動）
                if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0)
                {
                    transform.position += speed * transform.right * Time.deltaTime;
                }

                // Aキー（左移動）
                if (Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < 0)
                {
                    transform.position -= speed * transform.right * Time.deltaTime;
                }

            }

            if (isTouch)
            {
                touch_time += Time.deltaTime;

                //StartCoroutine("blink");

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

                if (inv_time >= invicible_time)
                {
                    Invincible = false;
                    inv_time = 0f;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
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