using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomCollider : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null && player!= null)
        {
            player.ReduceLives();
            enemy.EnemyKilledOutsideBounds();
        }
    }
}
