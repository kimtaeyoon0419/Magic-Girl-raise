using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] int current_HP; // 몬스터 현재 체력
    [SerializeField] int max_HP; // 몬스터 총 체력

    [SerializeField] int attackPower; // 공격력

    [SerializeField] TextMeshProUGUI moster_Name; // 화면상에 나오는 몬스터 이름
    

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FireSkill_1"))
        {
            PlayerStatManager.instance.attackPower -= current_HP;
        }
    }
}
