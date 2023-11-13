using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float move = 5.0f;
    public float Up = -6.0f;
    public float Down = -3.0f;
    public float UpDown = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(this.transform.position.y < Up)
        {
            Vector3 position = new Vector3(0, UpDown, move);
            transform.Translate(position);
        }
        else
        {
            Vector3 position = new Vector3(0, -UpDown, move);
            transform.Translate(position);
        }*/

        //this.transform.position = new Vector3(this.transform.position.x, Mathf.PingPong(Time.time, 10), move * Time.deltaTime);

        Vector3 position = new Vector3(0, 0, -move);
        transform.Translate(position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("destroy"))
        {
            Destroy(gameObject);
        }
    }
}

