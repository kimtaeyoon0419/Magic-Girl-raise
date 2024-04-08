using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] int current_HP; // ���� ���� ü��
    [SerializeField] int max_HP; // ���� �� ü��

    [SerializeField] int attackPower; // ���ݷ�

    [SerializeField] TextMeshProUGUI moster_Name; // ȭ��� ������ ���� �̸�
    

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
