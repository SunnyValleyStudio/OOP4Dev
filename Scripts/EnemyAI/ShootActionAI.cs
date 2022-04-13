using SVS.WeaponSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyAI
{
    public class ShootActionAI : MonoBehaviour
    {
        private Player player;
        [SerializeField]
        private Weapon weapon;

        private void Awake()
        {
            player = FindObjectOfType<Player>();
            weapon = GetComponentInChildren<Weapon>(); ;
        }

        // Update is called once per frame
        void Update()
        {
            if (player.isAlive)
            {
                weapon.PerformAttack();
            }
        }
    }
}