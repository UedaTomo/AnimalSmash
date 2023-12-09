using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
        transform.Rotate(new Vector3(-20, 0, 0) * Time.deltaTime);
    }
    public void BasicDamage(bool enemy)
    {
        if (enemy == true)
            _damage = 40;
        if (enemy == false)
            _damage = 1;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss"))
        {
            other.GetComponent<BossScript>().HP(_damage, _damageLevel);
            Destroy(this.gameObject);
        }
        if (other.CompareTag("enemy"))
        {
            _damageLevel *= 2;
            Instantiate(smash, this.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("destroy"))
        {
            Destroy(this.gameObject);
        }
    }
}