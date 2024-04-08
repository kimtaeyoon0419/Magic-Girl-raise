using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] int current_HP; // 몬스터 현재 체력
    [SerializeField] int max_HP; // 몬스터 총 체력

    [SerializeField] int attackPower; // 공격력

    [SerializeField] TextMeshProUGUI moster_HP; // 화면상에 나오는 몬스터의 체력

    private void Start()
    {
        
    }
    private void Update()
    {
        moster_HP.text = ("남은 체력" + current_HP);
    }

    public void takeDMG(int damage)
    {
        current_HP -= damage;
        if(current_HP <= 0)
        {
            Die();
        }
    }
    private void Die()
    {

    }
    
}
