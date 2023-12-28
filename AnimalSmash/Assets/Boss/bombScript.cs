using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class bombScript : MonoBehaviour
{
    public float speed = 0.6f;
    private float _moveTime = 2.0f;
    private float _time = 0f;
    private GameObject _player;
    public GameObject birdbody;
    public Transform birdHight;     // 移動後高さ
    Vector3 preposition;            // 移動前位置
    Vector3 postposition;           // 移動後位置
    float rate;
    bool _moving = true;           //上から登場
    bool _birdStrike = false;       //プレイヤーに向かって突進
    public GameObject _strikeEffect;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip b1; //羽ばたく音
    [SerializeField] private AudioClip b2; //風切り
    [SerializeField] private AudioClip b3; //ゴゴゴ
    private GameObject target; // 追尾対象のオブジェクト
    public bool Left = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.6f;
        Transform transform = gameObject.GetComponent<Transform>();
        preposition = transform.position;
        postposition = new Vector3(preposition.x, birdHight.position.y, preposition.z);   // 移動後位置
        _source.PlayOneShot(b1); //再生
        if (Left)
        {
            target = GameObject.Find("BirdStrikePoint1");
        }
        else
            target = GameObject.Find("BirdStrikePoint2");
    }

    // Update is called once per frame
    void Update()
    {

        if (_moving == true)
        {
            // 経過時間を過ぎたときの処理
            if (_time >= _moveTime)
            {
                _moving = false;
                _player = GameObject.FindWithTag("Player");
                _birdStrike = true;

                // 一度だけ向きを調整
                Vector3 direction = (target.transform.position - transform.position).normalized;
                transform.up = direction;

                _source.PlayOneShot(b2); //再生
                _source.loop = !_source.loop;
                _source.PlayOneShot(b3); //再生
                birdbody.transform.eulerAngles = new Vector3(90.179f, 430.501f, 250.048f);
            }
            rate = Mathf.Clamp01(_time / _moveTime);   // 割合計算
            gameObject.transform.position = Vector3.Lerp(preposition, postposition, rate);
        }
        _time += Time.deltaTime;  // 経過時間の加算

        if (_birdStrike == true)
        {
            Vector3 effectPosition = new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z);
            Instantiate(_strikeEffect, effectPosition, Quaternion.identity);
            if (_time >= 3.0)
                speed += 0.18f;
            // プレイヤーの方向に向かって加速しながら突進
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