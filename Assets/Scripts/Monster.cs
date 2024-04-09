using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] int current_HP; // ���� ���� ü��
    [SerializeField] int max_HP; // ���� �� ü��
    [SerializeField] float speed; // ������ ������ �ӵ�

    [SerializeField] int attackPower; // ���ݷ�

    [SerializeField] TextMeshProUGUI moster_HP; // ȭ��� ������ ������ ü��

    bool isray = false;

    [Header("�����ɽ�Ʈ")]
    [SerializeField] float layLineSize;
    [SerializeField] LayerMask isLayer;

    private void Start()
    {
        
    }
    private void Update()
    {
        Move();
   
        Debug.DrawRay(transform.position, Vector3.left, Color.red);
        moster_HP.text = ("���� ü��" + current_HP);
    }

    void Move()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.left, 3, LayerMask.GetMask("Player"));

        if (hit.collider != null)
        {
            isray = true;

        }
        if (!isray)
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
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
