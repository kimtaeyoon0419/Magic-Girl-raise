using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShot : MonoBehaviour
{
    [SerializeField] float speed;

    private void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Monster monster = collision.GetComponent<Monster>();
            if(monster != null)
            {
                monster.takeDMG(PlayerStatManager.instance.attackPower);
            }
            gameObject.SetActive(false);
        }
    }
}
