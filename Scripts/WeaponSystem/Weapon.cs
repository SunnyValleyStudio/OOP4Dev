using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SVS.WeaponSystem
{
    public class Weapon : MonoBehaviour
    {
        public bool shootingDelayed;

        [SerializeField]
        private AttackPatternSO attackPattern;
        [SerializeField]
        private Transform shootingStartPoint;

        public GameObject projectile;
        public AudioSource gunAudio;

        public void PerformAttack()
        {
            if (shootingDelayed == false)
            {
                shootingDelayed = true;
                gunAudio.PlayOneShot(attackPattern.AudioSFX);

                attackPattern.Perform(shootingStartPoint);

                StartCoroutine(DelayShooting());
            }
        }

        private IEnumerator DelayShooting()
        {
            yield return new WaitForSeconds(attackPattern.AttackDelay);
            shootingDelayed = false;
        }
    }
}