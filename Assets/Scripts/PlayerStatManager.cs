using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PlayerStatManager : MonoBehaviour
    {
        public static PlayerStatManager instance;

        public int current_HP; // 플레이어 현재 체력
        public int max_HP; // 플레이어 총 체력

        public int attackPower; // 공격력
        public float cur_attackSpeed; // 공격속도
        public float max_attackSpeed; // 총 공격속도


        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        private void Start()
        {
            cur_attackSpeed = max_attackSpeed;
        }
        private void Update()
        {
            if (cur_attackSpeed >= 0)
            {
                cur_attackSpeed -= Time.deltaTime;
            }
        }

        public void AttackCoolSet()
        {
            cur_attackSpeed = max_attackSpeed;
        }
    }