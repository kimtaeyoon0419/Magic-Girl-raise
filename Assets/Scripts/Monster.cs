using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] int current_HP; // ���� ���� ü��
    [SerializeField] int max_HP; // ���� �� ü��
    [SerializeField] float speed; // ������ ������ �ӵ�

    [SerializeField] int attackPower; // ���ݷ�

    [SerializeField] TextMeshProUGUI moster_HP; // ȭ��� ������ ������ ü��


    [Header("�����ɽ�Ʈ")]
    [SerializeField] float layLineSize;
    [SerializeField] LayerMask isLayer;

    private void Start()
    {
        
    }
    private void Update()
    {
        moster_HP.text = ("���� ü��" + current_HP);
        if (isPlayer())
        {
            transform.Translate(transform.right * -speed * Time.deltaTime);
        }
    }
    private bool isPlayer()
    {
        return Physics2D.Raycast(transform.position, transform.right * -1 * layLineSize, isLayer);
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
