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
    private bool isTouch; //�G�ɓ����������������ĂȂ���
    private bool Invincible; //���G����
    private bool front;


    public GameObject damy;
    public GameObject stan;
    public Animator playeranim;
    public bool isMove;

    public GameObject tuto;
    tutorial Tutorial;

    // Start is called before the first frame update
    void Start()
    {
        tuto = GameObject.Find("tutorial");
        Tutorial = tuto.GetComponent<tutorial>();
        playeranim = GetComponent<Animator>();

        isTouch = false;
        Invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        playeranim.SetBool("walk", isMove);

        if (Tutorial.AblePlay)
        {
            if (!isTouch)
            {
                isMove = false;
                front = true;

                // W�L�[�i�O���ړ��j
                if (Input.GetKey(KeyCode.W) || Input.GetAxis("Vertical") > 0)
                {
                    this.transform.localRotation = Quaternion.Euler(0, 180, 0);
                    transform.position += speed * -transform.forward * Time.deltaTime;
                    isMove = true;
                    front = false;
                }

                // S�L�[�i����ړ��j
                if (Input.GetKey(KeyCode.S) || Input.GetAxis("Vertical") < 0)
                {
                    this.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    transform.position += speed * -transform.forward * Time.deltaTime;
                    isMove = true;
                    front = false;
                }

                // D�L�[�i�E�ړ��j
                if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0)
                {
                    this.transform.localRotation = Quaternion.Euler(0, 270, 0);
                    transform.position += speed * -transform.forward * Time.deltaTime;
                    isMove = true;
                    front = false;
                }

                // A�L�[�i���ړ��j
                if (Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < 0)
                {
                    this.transform.localRotation = Quaternion.Euler(0, 90, 0);
                    transform.position += speed * -transform.forward * Time.deltaTime;
                    isMove = true;
                    front = false;
                }

                if(front)
                {
                    this.transform.localRotation = Quaternion.Euler(0, 180, 0);
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