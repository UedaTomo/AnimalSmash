using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    WAIT,         //ë“ã@
    ATTACK,       //çUåÇ
    SPECIALATTACK,//ïKéE

}
public class BossScript : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform BossPoint;
    // Start is called before the first frame update
    void Start()
    {
        Attack();
    }
    void SetAi()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    void Attack()
    {
        bombPrefab = Instantiate(bombPrefab, BossPoint.position, BossPoint.rotation); //îöíeê∂ê¨
    }
}
