using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSineActionAI : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speedY = 2;

    public float amplitude = 1, frequency = 2;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 pos = rb2d.position;
        float sinVal = Mathf.Sin(pos.y * frequency) * amplitude; // offset
        Vector2 direction = (Vector2.right * sinVal + Vector2.down);
        rb2d.MovePosition(rb2d.position + direction * speedY * Time.deltaTime);
    }
}
