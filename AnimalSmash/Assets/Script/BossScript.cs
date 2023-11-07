using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    WAIT,         //ë“ã@
    ATTACK,       //çUåÇ
}
public class BossScript : MonoBehaviour
{
    public GameObject _bombPrefab;
    public Transform _bossPoint;
    public int _bossHp = 25;
    // Start is called before the first frame update
    void Start()
    {
        Attack();
    }
    void SetAi()
    {

    }
    public void HP(int damage,int damageLevel)
    {
        _bossHp -= damage+damageLevel;
    }
    // Update is called once per frame
    void Update()
    {
        if(_bossHp <= 0)
        {
            Destroy(gameObject);
        }

    }
    void Attack()
    {
        _bombPrefab = Instantiate(_bombPrefab, _bossPoint.position, _bossPoint.rotation); //îöíeê∂ê¨
    }
}
