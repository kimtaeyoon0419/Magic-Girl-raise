using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PlayerStatManager : MonoBehaviour
    {
        public static PlayerStatManager instance;

        public int current_HP; // �÷��̾� ���� ü��
        public int max_HP; // �÷��̾� �� ü��

        public int attackPower; // ���ݷ�
        public float cur_attackSpeed; // ���ݼӵ�
        public float max_attackSpeed; // �� ���ݼӵ�


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