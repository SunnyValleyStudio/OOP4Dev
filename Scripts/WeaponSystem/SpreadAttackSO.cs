using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SVS.WeaponSystem
{
    [CreateAssetMenu(menuName = "Attacks/SpreadAttack")]
    public class SpreadAttackSO : AttackPatternSO
    {

        [SerializeField]
        private float angleDegrees = 5;
        public override void Perform(Transform shootingStartPoint)
        {
            Instantiate(projectile, shootingStartPoint.position, shootingStartPoint.rotation);
            Instantiate(projectile, shootingStartPoint.position, shootingStartPoint.rotation 
                * Quaternion.Euler(Vector3.forward * angleDegrees));
            Instantiate(projectile, shootingStartPoint.position, shootingStartPoint.rotation 
                * Quaternion.Euler(Vector3.forward * -angleDegrees));
        }
    }
}