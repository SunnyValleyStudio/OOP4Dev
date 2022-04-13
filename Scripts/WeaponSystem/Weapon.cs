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

        [SerializeField]
        List<AttackPatternSO> weapons;
        private int index = 0;
        [SerializeField]
        private AudioClip weaponSwap;


        private void Start()
        {
            if(shootingDelayed)
                StartCoroutine(DelayShooting());
        }
        public void SwapWeapon()
        {
            index++;
            index = index >= weapons.Count ? 0 : index;
            attackPattern = weapons[index];
            gunAudio.PlayOneShot(weaponSwap);

        }

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