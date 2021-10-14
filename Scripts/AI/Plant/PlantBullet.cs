using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBullet : MonoBehaviour
{
    public float speed = 2f;
    public float lifetime = 0.5f;

    public SpriteRenderer sr;
    public GameObject bulletPieces;

    private void Start()
    {
        Invoke("AnimDestroy", lifetime);
        StartCoroutine(DestroyBullet());
    }

    private void Update()
    {
        if (PlantManager.left)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime); // new Vector2 (-1,0)
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime); // new Vector2 (1,0)
        }
    }

    public void AnimDestroy()
    {
        bulletPieces.SetActive(true);
        sr.enabled = false;
    }
    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }
}
