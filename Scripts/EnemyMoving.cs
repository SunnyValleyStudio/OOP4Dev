using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    public int health = 3;

    public float speed = 2;
    private Rigidbody2D rb2d;

    private ScreenBounds screenBounds;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb2d.velocity = Vector3.down * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>())
        {
            Destroy(collision.gameObject);
        }

        if (collision.GetComponent<Player>())
        {
            Destroy(gameObject);
            return;
        }

        Debug.Log(collision.name);
        health--;
        if (health <= 0)
            Destroy(gameObject);
    }
}
