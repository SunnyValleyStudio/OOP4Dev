using SVS.WeaponSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 2;

    public Transform playerShip;

    public ScreenBounds screenBounds;

    public int health = 3;

    [SerializeField]
    private Transform liveImagesUIParent;
    List<Image> lives = new List<Image>();

    Rigidbody2D rb2d;
    Vector2 movementVector = Vector2.zero;

    public AudioClip hitClip, deathClip;
    public AudioSource hitSource;

    public GameObject explosionFX;

    public bool isAlive = true;

    public InGameMenu loseScreen;
    public Button menuButton;

    [SerializeField]
    private Weapon weapon;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

        foreach (Transform item in liveImagesUIParent)
        {
            lives.Add(item.GetComponent<Image>());
        }
    }
    // Update is called once per frame
    void Update()
    {
        //get input and move
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input.Normalize();
        movementVector = speed * input;  

        //shooting
        if (Input.GetKey(KeyCode.Space))
        {
            //if(shootingDelayed == false)
            //{
            //    shootingDelayed = true;
            //    gunAudio.Play();
            //    GameObject p = Instantiate(projectile, transform.position, Quaternion.identity);
            //    StartCoroutine(DelayShooting());
            //}
            weapon.PerformAttack();
        }
    }

    private void FixedUpdate()
    {
        Vector2 newPosition = rb2d.position + movementVector * Time.fixedDeltaTime;
        if (screenBounds.AmIOutOfBounds(newPosition) == false)
        {
            rb2d.MovePosition(newPosition);
            //transform.Translate(tempPosition - transform.position);
        }
    }

    public void ReduceLives()
    {
        health--;
        for (int i = 0; i < lives.Count; i++)
        {
            if (i >= health)
            {
                lives[i].color = Color.black;
            }
            else
            {
                lives[i].color = Color.white;
            }

        }
        if (health <= 0)
        {
            isAlive = false;
            hitSource.PlayOneShot(deathClip);
            GetComponent<Collider2D>().enabled = false;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            StartCoroutine(DestroyCoroutine());
        }
        else
        {
            hitSource.PlayOneShot(hitClip);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ScreenBounds>() || collision.GetComponent<BottomCollider>())
            return;

        //Debug.Log(collision.name);
        
        health--;
        for (int i = 0; i < lives.Count; i++)
        {
            if (i >= health)
            {
                lives[i].color = Color.black;
            }
            else
            {
                lives[i].color = Color.white;
            }
            
        }
        if (health <= 0)
        {
            isAlive = false;
            hitSource.PlayOneShot(deathClip);
            GetComponent<Collider2D>().enabled = false;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            StartCoroutine(DestroyCoroutine());
        } 
        else
        {
            hitSource.PlayOneShot(hitClip);
        }
    }

    private IEnumerator DestroyCoroutine()
    {
        Instantiate(explosionFX, transform.position, Quaternion.identity); ;
        yield return new WaitForSeconds(deathClip.length);
        Destroy(gameObject);
        loseScreen.Toggle();
        menuButton.interactable = false;
    }

}
