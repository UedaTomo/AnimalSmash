using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Linq;

public class PlayerScript : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        isTouch = false;
        Invincible = false;
    }

    // Update is called once per frame
    void Update()
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            if (!Invincible)
            {
                isTouch = true;
            }
        }
    }
}