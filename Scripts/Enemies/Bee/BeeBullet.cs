using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBullet : MonoBehaviour
{
    public float speed = 2f;
    public float lifeTime = 2f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
