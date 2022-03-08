using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IHittable
{
    public float speed = 10;
    public Rigidbody2D rb2d;
    public float deathDelay = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb2d.velocity = transform.up * speed;
        StartCoroutine(DeathAfterDelay(deathDelay));
    }

    private IEnumerator DeathAfterDelay(float deathDelay)
    {
        yield return new WaitForSeconds(deathDelay);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHittable hittable = collision.GetComponent<IHittable>();
        if (hittable != null)
        {
            hittable.GetHit(1, gameObject);
        }
    }

    public void GetHit(int damageValue, GameObject sender)
    {
        Destroy(gameObject);
    }
}
