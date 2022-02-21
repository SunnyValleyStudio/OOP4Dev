using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SVS.WeaponSystem
{
    public class Weapon : MonoBehaviour
    {
        public float shootingDelay = 0.2f;
        public bool shootingDelayed;

        public GameObject projectile;
        public AudioSource gunAudio;

        public void PerformAttack()
        {
            if (shootingDelayed == false)
            {
                shootingDelayed = true;
                gunAudio.Play();
                GameObject p = Instantiate(projectile, transform.position, Quaternion.identity);
                StartCoroutine(DelayShooting());
            }
        }

        private IEnumerator DelayShooting()
        {
            yield return new WaitForSeconds(shootingDelay);
            shootingDelayed = false;
        }
    }
}