using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // W�L�[�i�O���ړ��j
<<<<<<< HEAD
        if (Input.GetKey(KeyCode.W) || Input.GetAxis("Vertical") > 0)
=======
        if (Input.GetKey(KeyCode.W)  || Input.GetAxis("Vertical") > 0)
>>>>>>> d7995274099d05b1fcb1b7b7160a0f7b4caf30f2
        {
            transform.position += speed * transform.forward * Time.deltaTime;
        }

        // S�L�[�i����ړ��j
        if (Input.GetKey(KeyCode.S) || Input.GetAxis("Vertical") < 0)
        {
            transform.position -= speed * transform.forward * Time.deltaTime;
        }

        // D�L�[�i�E�ړ��j
        if (Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0)
        {
            transform.position += speed * transform.right * Time.deltaTime;
        }

        // A�L�[�i���ړ��j
        if (Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < 0)
        {
            transform.position -= speed * transform.right * Time.deltaTime;
        }
    }
}