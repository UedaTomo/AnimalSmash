using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;
using UnityEngine.SceneManagement;
using TMPro;

public enum BossState
{
    WAIT,         //待機
    ATTACK,       //攻撃
}
public class BossScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _birdPrefab;
    [SerializeField]
    private GameObject _birdPrefab1;
    [SerializeField]
    private GameObject _redZone;
    [SerializeField]
    private GameObject _redZone1;
    public Transform _birdPoint1;
    public Transform _birdPoint2;
    public int _bossHp = 700;
    public Slider _bossSlider;
    public static int currentHp;
    public GameObject _smash;
    public GameObject _bossSmash;
    public GameObject _playerObj;
    private float time = 0f;
    private TextMeshProUGUI _conboText;
    private Animator birdanim;           //Anim
    public bool BossAttackOn = true;      //Bossが攻撃するかどうか
    [SerializeField] private Transform zone;
    [Header("鳥頻度")]
    [SerializeField] private float _birdStrike = 20.0f;
    [SerializeField] private AudioSource _source;
    [Header("鳴き声")]
    [SerializeField] private AudioClip bear;

    //リザルト演出
    /*public Animator Boss_koya;
    public bool win;
    public bool lose;*/


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        currentHp = _bossHp;
        GameObject obj = GameObject.Find("Conbo");
        _conboText = obj.GetComponent<TextMeshProUGUI>();
        GameObject BossBear = GameObject.Find("BossBear");
        birdanim = BossBear.GetComponent<Animator>();

        /*win = false;
        lose = false;*/
    }
    public void HP(int _conbo, int _damage, int _damageLevel)
    {
        currentHp -= _damage + _damageLevel;
        _conboText.text = _conbo + "れんさ\n" + (_damage + _damageLevel) + "ダメージ";
    }
    // Update is called once per frame
    void Update()
    {
        /*Boss_koya.SetBool("win", win);
        Boss_koya.SetBool("lose", lose);*/

        time += Time.deltaTime;
        if (currentHp <= 0)
        {
            //win = true;
            OnDestroy();
            SceneManager.LoadScene("WinResult");
        }
        if (BossAttackOn)
        {
            if (time > _birdStrike - 7.5f)
            {
                birdanim.SetBool("birdstrike", true);
            }
            //13秒後Attackを呼ぶ
            if (time > _birdStrike)
            {
                time = 0f;
                Attack();
                birdanim.SetBool("birdstrike", false);
                _source.PlayOneShot(bear);
            }
        }
        _bossSlider.value = (int)currentHp;
    }
    private void OnDestroy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            Vector3 effectPosition = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 1f, enemy.transform.position.z);
            //Instantiate(_smash, effectPosition, Quaternion.identity);
            Destroy(enemy);
            //_playerObj.GetComponent<PlayerScript>().GameClear();
        }
        Vector3 bossEffectPosition = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
        //Instantiate(_bossSmash, bossEffectPosition, Quaternion.identity);
        //Destroy(gameObject);
    }
    void target(bool left)
    {

    }
    //鳥生成
    void Attack()
    {
        float x = Random.Range(_birdPoint1.position.x, _birdPoint2.position.x);
        float y = _birdPoint1.position.y;
        float z = Random.Range(_birdPoint1.position.z, _birdPoint2.position.z);
        Vector3 posi = GameObject.Find("Player").transform.position;


        if (zone.GetComponent<BirdStrikeZoneScript>().Left == true)
        {
            Instantiate(_birdPrefab1, new Vector3(x, y, z), _birdPoint1.rotation);
            Instantiate(_redZone, posi, Quaternion.identity);
        }
        else
        {
            Instantiate(_birdPrefab, new Vector3(x, y, z), _birdPoint1.rotation);
            Instantiate(_redZone1, posi, Quaternion.identity);
        }

        //Instantiate(_birdPrefab, _birdPoint1.position, _birdPoint1.rotation);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("destroy"))
        {
            Destroy(other.gameObject);
        }
    }
}