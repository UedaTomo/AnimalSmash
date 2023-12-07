using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombScript : MonoBehaviour
{
    public float speed = 0.6f;
    private float _moveTime = 2.0f;
    private float _time = 0f;
    private GameObject _player;
    public Transform birdHight;     // �ړ��㍂��
    Vector3 preposition;            // �ړ��O�ʒu
    Vector3 postposition;           // �ړ���ʒu
    float rate;
    bool _moving = true;           //�ォ��o��
    bool _birdStrike = false;       //�v���C���[�Ɍ������ēːi
    public GameObject _strikeEffect;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.6f;
        Transform transform = gameObject.GetComponent<Transform>();
        preposition = transform.position;
        postposition = new Vector3(preposition.x, birdHight.position.y, preposition.z);   // �ړ���ʒu
    }

    // Update is called once per frame
    void Update()
    {

        if (_moving == true)
        {
            // �o�ߎ��Ԃ��߂����Ƃ��̏���
            if (_time >= _moveTime)
            {
                _moving = false;
                _player = GameObject.FindWithTag("Player");
                _birdStrike = true;

                // ��x���������𒲐�
                Vector3 direction = (_player.transform.position - transform.position).normalized;
                transform.up = direction;
            }
            rate = Mathf.Clamp01(_time / _moveTime);   // �����v�Z
            gameObject.transform.position = Vector3.Lerp(preposition, postposition, rate);
        }
        _time += Time.deltaTime;  // �o�ߎ��Ԃ̉��Z

        if (_birdStrike == true)
        {
            Vector3 effectPosition = new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z);
            Instantiate(_strikeEffect, effectPosition, Quaternion.identity);
            if (_time >= 3.0)
                speed += 0.1f;
            // �v���C���[�̕����Ɍ������ĉ������Ȃ���ːi
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("destroy"))
        {
            Destroy(gameObject);
        }
    }
}