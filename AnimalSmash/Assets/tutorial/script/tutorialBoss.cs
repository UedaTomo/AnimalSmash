using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;
using UnityEngine.SceneManagement;

/*public enum BossState
{
    WAIT,         //�ҋ@
    ATTACK,       //�U��
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

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        currentHp = _bossHp;
    }
    public void HP(int damage, int damageLevel)
    {
        currentHp -= damage + damageLevel;
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        _bossSlider.value = (int)currentHp;
    }
    /*private void OnDestroy()
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
    //������
    void Attack()
    {
        float x = Random.Range(_birdPoint1.position.x, _birdPoint2.position.x);
        float y = _birdPoint1.position.y;
        float z = Random.Range(_birdPoint1.position.z, _birdPoint2.position.z);

        Instantiate(_birdPrefab, new Vector3(x, y, z), _birdPoint1.rotation);
        //Instantiate(_birdPrefab, _birdPoint1.position, _birdPoint1.rotation);
    }*/
}