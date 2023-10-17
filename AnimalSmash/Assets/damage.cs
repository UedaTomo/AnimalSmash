using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    private int _damageLevel = 1;
    private int _damage = 1;
    public GameObject _bossObj;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss"))
        {
            _bossObj.GetComponent<BossScript>().HP(_damage, _damageLevel);
            Destroy(gameObject);
        }
        if (other.CompareTag("enemy"))
            _damageLevel *= 2;
    }
}
