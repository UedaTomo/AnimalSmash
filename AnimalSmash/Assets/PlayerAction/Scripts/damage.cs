using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class damage : MonoBehaviour
{
    private int _damageLevel = 1;
    public int _damage = 1; 
    private int _conbo = 0; //ÉRÉìÉ{êî
    public static int _maxcombo = 0;
    public bool bird = false;
    private Rigidbody rb;
    [SerializeField] private GameObject smash;
    [SerializeField] private GameObject _bossHit;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip koyabreak; //åöï®Ç™è≠ÇµïˆÇÍÇÈ
    [SerializeField] private AudioClip enemydie;
    public GameObject _strikeEffect;
    public float rotationSpeed = 5.0f; // âÒì]ÇÃë¨Ç≥
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.angularVelocity = new Vector3(-rotationSpeed, 0, 0); // í«â¡
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        if (bird==true)
        {
            Vector3 effectPosition = new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z);
            Instantiate(_strikeEffect, effectPosition, Quaternion.identity);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss"))
        {
            Vector3 effectPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z-5);
            Instantiate(_bossHit, effectPosition, Quaternion.identity);
            _source.PlayOneShot(koyabreak); //çƒê∂
            other.GetComponent<BossScript>().HP(_conbo,_damage, _damageLevel);
            Destroy(this.gameObject);
        }
        if (other.CompareTag("enemy")|| other.CompareTag("Flock"))
        {
            _conbo++;

            if(_conbo>= 7)
            {
                _damageLevel += 5;
            }
            else
                _damageLevel *= 2;
            Instantiate(smash, this.transform.position, Quaternion.identity);
            _source.PlayOneShot(enemydie); //çƒê∂
            Destroy(other.gameObject);

            if(_maxcombo < _conbo)
            {
                _maxcombo = _conbo;
            }
        }
        if (other.CompareTag("destroy"))
        {
            Destroy(this.gameObject);
        }
    }
}