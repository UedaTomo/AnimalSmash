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

/*public enum BossState
{
    WAIT,         //待機
    ATTACK,       //攻撃
}*/
public class tutorialBoss: MonoBehaviour
{
    [SerializeField]
    private GameObject _birdPrefab;
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

    public float HitNum = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        currentHp = _bossHp;
        GameObject obj = GameObject.Find("Conbo");
        _conboText = obj.GetComponent<TextMeshProUGUI>();
        //GameObject BossBear = GameObject.Find("BossBear");
        //birdanim = BossBear.GetComponent<Animator>();
    }
    public void HP(int _conbo, int _damage, int _damageLevel)
    {
        currentHp -= _damage + _damageLevel;
        //_conboText.text = _conbo + "れんさ\n" + (_damage + _damageLevel) + "ダメージ";
    }
    // Update is called once per frame
    void Update()
    {
        //time += Time.deltaTime;
        if (currentHp <= 0)
        {

            OnDestroy();
            //SceneManager.LoadScene("WinResult");
        }
       /*if (BossAttackOn)
        {
            if (time > 5.5)
            {
                birdanim.SetBool("birdstrike", true);
            }
            //13秒後Attackを呼ぶ
            if (time > 13.0f)
            {
                time = 0f;
                Attack();
                birdanim.SetBool("birdstrike", false);
            }
        }*/
        _bossSlider.value = (int)currentHp;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            HitNum += 1;
        }
    }
        private void OnDestroy()
    { 
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject enemy in enemies)
        {
            HitNum++;
            Vector3 effectPosition = new Vector3(enemy.transform.position.x, enemy.transform.position.y + 1f, enemy.transform.position.z);
            //Instantiate(_smash, effectPosition, Quaternion.identity);
            Destroy(enemy);
            //_playerObj.GetComponent<PlayerScript>().GameClear();
        }
        Vector3 bossEffectPosition = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
        //Instantiate(_bossSmash, bossEffectPosition, Quaternion.identity);
        //Destroy(gameObject);

    }

    //鳥生成
   /* void Attack()
    {
        float x = Random.Range(_birdPoint1.position.x, _birdPoint2.position.x);
        float y = _birdPoint1.position.y;
        float z = Random.Range(_birdPoint1.position.z, _birdPoint2.position.z);

        Instantiate(_birdPrefab, new Vector3(x, y, z), _birdPoint1.rotation);
        //Instantiate(_birdPrefab, _birdPoint1.position, _birdPoint1.rotation);
    }*/
}