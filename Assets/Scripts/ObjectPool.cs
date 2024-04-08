using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance; // 싱글톤
    public GameObject[] prefabs; // 오브젝트 풀링할 프리팹들

    List<GameObject>[] pools; // 프리팹을 담아야할 리스트

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
        } // 프리팹들을 pools 리스트에 담음
    }

    public GameObject Get(int index, Vector3 posithon)
    {
        GameObject select = null;


        foreach (GameObject Object in pools[index]) // 내가 원하는 pools[index]를 찾음
        {
            if (!Object.activeSelf) // 현재 오브젝트가 활성화 되어있지 않다면
            {
                select = Object; // select 를 objcet로 초기화
                select.transform.position = posithon; // select의 포지션을 내가 정한 포지션으로 초기화
                select.SetActive(true); // select를 활성화 해줌
                break;
            }
        }
        if (!select) //select가 없다면
        {
            select = Instantiate(prefabs[index], posithon, Quaternion.identity, transform); // select를 생성함
            //if (index == 0) select.GetComponent<Bullet>().DirVec(GameManager.instance.player.bulletDirVec);

            pools[index].Add(select); 
        }


        return select;
    }
}
