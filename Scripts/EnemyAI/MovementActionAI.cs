using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyAI
{
    public class MovementActionAI : MonoBehaviour
    {
        public float speed = 2;
        public float speedVariation = 0.3f;
        private Rigidbody2D rb2d;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
            speed += UnityEngine.Random.Range(0, speedVariation);
        }
        private void FixedUpdate()
        {
            rb2d.MovePosition(rb2d.position + Vector2.down * speed * Time.deltaTime);
        }
    }
}