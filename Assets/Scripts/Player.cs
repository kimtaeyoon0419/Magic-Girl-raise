using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] string playerName; // �÷��̾� �̸� ����

    [SerializeField] int current_HP; // �÷��̾� ���� ü��
    [SerializeField] int max_HP; // �÷��̾� �� ü��

    [SerializeField] int attackPower; // ���ݷ�
    [SerializeField] float cur_attackSpeed; // ���ݼӵ�
    [SerializeField] float max_attackSpeed; // �� ���ݼӵ�
    [SerializeField] GameObject attackPos;

    [SerializeField] TextMeshProUGUI player_Name; // ȭ��� ������ �÷��̾� �̸�

    [Header("�����ɽ�Ʈ")]
    [SerializeField] float layLineSize;
    [SerializeField] LayerMask isLayer;

    private void Start()
    {
        player_Name.text = playerName;
        cur_attackSpeed = max_attackSpeed;
    }
    private void Update()
    {
        if(cur_attackSpeed >= 0)
        {
            cur_attackSpeed -= Time.deltaTime;
        }
        Debug.DrawRay(transform.position, transform.right * layLineSize, Color.yellow);
        attackMonster();
    }
    private bool IsMonster()
    {
        return Physics2D.Raycast(transform.position, transform.right * layLineSize, isLayer);
    }
    private void attackMonster()
    {
        if (IsMonster() && cur_attackSpeed <= 0)
        {
            ObjectPool.instance.Get(0, attackPos.transform.position);
            cur_attackSpeed = max_attackSpeed;
        }
    }
}
