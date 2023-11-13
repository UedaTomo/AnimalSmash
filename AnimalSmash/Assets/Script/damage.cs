using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    private int _damageLevel = 1;
    private int _damage = 1;
    private Rigidbody rb;
    public GameObject smash;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss"))
        {
            other.GetComponent<BossScript>().HP(_damage, _damageLevel);
            Destroy(gameObject);
        }
        if (other.CompareTag("enemy"))
        {
            _damageLevel *= 2;
            Instantiate(smash, this.transform.position, Quaternion.identity);
            Debug.Log(_damageLevel);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("destroy"))
        {
            Destroy(gameObject);
        }
    }
}