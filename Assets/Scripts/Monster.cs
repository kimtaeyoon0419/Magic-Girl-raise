using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] int current_HP; // 몬스터 현재 체력
    [SerializeField] int max_HP; // 몬스터 총 체력
    [SerializeField] float speed; // 몬스터의 움직임 속도

    [SerializeField] int attackPower; // 공격력

    [SerializeField] TextMeshProUGUI moster_HP; // 화면상에 나오는 몬스터의 체력

    bool isray = false;

    [Header("레이케스트")]
    [SerializeField] float layLineSize;
    [SerializeField] LayerMask isLayer;

    private void Start()
    {
        
    }
    private void Update()
    {
        Move();
   
        Debug.DrawRay(transform.position, Vector3.left, Color.red);
        moster_HP.text = ("남은 체력" + current_HP);
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
