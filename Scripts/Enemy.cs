using SVS.HealthSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public Player player;
    [SerializeField]
    public int initialHealthValue = 3;

    //public GameObject projectile;
    //public float shootingDelay;

    //public bool isShooting = false;

    //public float speed = 2;
    //public float speedVariation = 0.3f;
    //private Rigidbody2D rb2d;
    //bool firstShoot = true;

    public EnemySpawner enemySpawner;

    [SerializeField]
    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
        //player = FindObjectOfType<Player>();
        //rb2d = GetComponent<Rigidbody2D>();
        //speed += UnityEngine.Random.Range(0, speedVariation);
    }

    private void Start()
    {
        health.InitializeHealth(initialHealthValue);
    }

    //private void Update()
    //{
    //    //Vector3 movementDirection = Vector3.down * speed * Time.deltaTime;
    //    //transform.Translate(movementDirection, Space.World);
    //    if (player.isAlive)
    //    {
    //        Vector3 desiredDirection = player.transform.position - transform.position;
    //        float desiredAngle = Mathf.Atan2(desiredDirection.y, desiredDirection.x) * Mathf.Rad2Deg - 90;
    //        transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward);

    //        if (isShooting == false)
    //        {
    //            isShooting = true;
    //            StartCoroutine(ShootWithDelay(shootingDelay));
    //        }
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    rb2d.MovePosition(rb2d.position + Vector2.down * speed * Time.deltaTime);
    //}
    //private IEnumerator ShootWithDelay(float shootingDelay)
    //{
    //    if (firstShoot)
    //    {
    //        firstShoot = false;
    //        yield return new WaitForSeconds(UnityEngine.Random.Range(0, 0.5f));
    //    }
    //    yield return new WaitForSeconds(shootingDelay);
    //    GameObject p = Instantiate(projectile, transform.position, transform.rotation);

    //    isShooting = false;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHittable hittable = collision.GetComponent<IHittable>();
        if (hittable != null && collision.GetComponent<Player>())
        {
            hittable.GetHit(1, gameObject);
            Death();
        }
    }

    public void EnemyKilledOutsideBounds()
    {
        enemySpawner.EnemyKilled(this, false);
        Destroy(gameObject);
    }

    public void Death()
    {
        enemySpawner.EnemyKilled(this, true);
        StopAllCoroutines();
        Destroy(gameObject);
    }
}
