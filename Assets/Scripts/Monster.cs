using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] int current_HP; // ���� ���� ü��
    [SerializeField] int max_HP; // ���� �� ü��

    [SerializeField] int attackPower; // ���ݷ�

    [SerializeField] TextMeshProUGUI moster_HP; // ȭ��� ������ ������ ü��

    private void Start()
    {
        
    }
    private void Update()
    {
        moster_HP.text = ("���� ü��" + current_HP);
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
