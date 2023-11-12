using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Linq;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] Material plane;
    public float stop = 3.0f;
    private float alpha_sin;
    private float time = 0f;
    private bool isTouch; //敵に当たったか当たってないか
    public GameObject damy;
    // Start is called before the first frame update
    void Start()
    {
        isTouch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTouch)
        {
            time += Time.deltaTime;
            //Debug.Log("足し算");

            //StartCoroutine("blink");

            if (time >= stop)
            {
                isTouch = false;
                time = 0f;
                //Debug.Log("終わり");
            }
            
        }

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
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            isTouch = true;
        }
    }
    public void GameClear()
    {
        damy.gameObject.SetActive(true);
        Instantiate(damy, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}