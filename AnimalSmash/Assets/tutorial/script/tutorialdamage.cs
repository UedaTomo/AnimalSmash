using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class tutorialdamage: MonoBehaviour
{
    private int _damageLevel = 1;
    public int _damage = 1;
    private int _conbo = 0; //コンボ数
    private Rigidbody rb;
    [SerializeField] private GameObject smash;
    [SerializeField] private GameObject _bossHit;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip koyabreak; //建物が少し崩れる
    [SerializeField] private AudioClip enemydie;
    public float rotationSpeed = 5.0f; // 回転の速さ

    public float HitNum = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.angularVelocity = new Vector3(-rotationSpeed, 0, 0); // 追加
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss"))
        {
            Vector3 effectPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 5);
            Instantiate(_bossHit, effectPosition, Quaternion.identity);
            _source.PlayOneShot(koyabreak); //再生
            other.GetComponent<tutorialBoss>().HP(_conbo, _damage, _damageLevel);
            Destroy(this.gameObject);
            HitNum++;
        }
        if (other.CompareTag("enemy"))
        {
            _conbo++;
            _damageLevel *= 2;
            Instantiate(smash, this.transform.position, Quaternion.identity);
            _source.PlayOneShot(enemydie); //再生
            Destroy(other.gameObject);
        }
        if (other.CompareTag("destroy"))
        {
            Destroy(this.gameObject);
        }
    }
}