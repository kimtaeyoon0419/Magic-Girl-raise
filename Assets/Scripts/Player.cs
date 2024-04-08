using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    [SerializeField] string playerName; // 플레이어 이름 정의
    [SerializeField] TextMeshProUGUI player_Name; // 화면상에 나오는 플레이어 이름
    [SerializeField] GameObject attackPos;

    [Header("레이케스트")]
    [SerializeField] float layLineSize;
    [SerializeField] LayerMask isLayer;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        player_Name.text = playerName;
    }
    private void Update()
    {
        
        Debug.DrawRay(transform.position, transform.right * layLineSize, Color.yellow);
        attackMonster();
    }
    private bool IsMonster()
    {
        return Physics2D.Raycast(transform.position, transform.right * layLineSize, isLayer);
    }
    private void attackMonster()
    {
        if (IsMonster() && PlayerStatManager.instance.cur_attackSpeed <= 0)
        {
            ObjectPool.instance.Get(0, attackPos.transform.position);
            PlayerStatManager.instance.AttackCoolSet();
            animator.SetTrigger("attack");
        }
    }
}
