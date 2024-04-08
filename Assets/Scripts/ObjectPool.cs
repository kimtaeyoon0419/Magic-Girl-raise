using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance; // �̱���
    public GameObject[] prefabs; // ������Ʈ Ǯ���� �����յ�

    List<GameObject>[] pools; // �������� ��ƾ��� ����Ʈ

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        } // �����յ��� pools ����Ʈ�� ����
    }

    public GameObject Get(int index, Vector3 posithon)
    {
        GameObject select = null;


        foreach (GameObject Object in pools[index]) // ���� ���ϴ� pools[index]�� ã��
        {
            if (!Object.activeSelf) // ���� ������Ʈ�� Ȱ��ȭ �Ǿ����� �ʴٸ�
            {
                select = Object; // select �� objcet�� �ʱ�ȭ
                select.transform.position = posithon; // select�� �������� ���� ���� ���������� �ʱ�ȭ
                select.SetActive(true); // select�� Ȱ��ȭ ����
                break;
            }
        }
        if (!select) //select�� ���ٸ�
        {
            select = Instantiate(prefabs[index], posithon, Quaternion.identity, transform); // select�� ������
            //if (index == 0) select.GetComponent<Bullet>().DirVec(GameManager.instance.player.bulletDirVec);

            pools[index].Add(select); 
        }


        return select;
    }
}
