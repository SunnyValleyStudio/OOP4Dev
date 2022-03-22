using SVS.HealthSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody2D rb2d;
    public float deathDelay = 5;

    [SerializeField]
    private int initialHealth = 1;
    [SerializeField]
    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        health.InitializeHealth(initialHealth);

        rb2d.velocity = transform.up * speed;
        StartCoroutine(DeathAfterDelay(deathDelay));
    }

    private IEnumerator DeathAfterDelay(float deathDelay)
    {
        yield return new WaitForSeconds(deathDelay);
        health.GetHit(1, gameObject);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHittable hittable = collision.GetComponent<IHittable>();
        if (hittable != null)
        {
            hittable.GetHit(1, gameObject);
            health.GetHit(1, gameObject);
            Destroy(gameObject);
        }
    }

}
