using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] string playerName; // 플레이어 이름 정의

    [SerializeField] int current_HP; // 플레이어 현재 체력
    [SerializeField] int max_HP; // 플레이어 총 체력

    [SerializeField] int attackPower; // 공격력
    [SerializeField] float cur_attackSpeed; // 공격속도
    [SerializeField] float max_attackSpeed; // 총 공격속도
    [SerializeField] GameObject attackPos;

    [SerializeField] TextMeshProUGUI player_Name; // 화면상에 나오는 플레이어 이름

    [Header("레이케스트")]
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
