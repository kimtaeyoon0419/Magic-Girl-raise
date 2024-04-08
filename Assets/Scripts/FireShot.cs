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
}
