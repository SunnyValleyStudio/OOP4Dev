using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SVS.WeaponSystem
{
    [CreateAssetMenu(menuName = "Attacks/DoubleBarrelAttack")]
    public class DoubleBarrelAttackSO : AttackPatternSO
    {
        
        [SerializeField]
        private float offsetFromShootingPoint = 0.3f;

        public override void Perform(Transform shootingStartPoint)
        {
            //rotate offset vector to fit the players ship rotation
            Vector3 offsetVector = shootingStartPoint.rotation * 
                new Vector3(offsetFromShootingPoint, 0, 0);

            //calculate new barrel positions
            Vector3 point1 = shootingStartPoint.position + offsetVector;
            Vector3 point2 = shootingStartPoint.position - offsetVector;

            Instantiate(projectile, point1, shootingStartPoint.rotation);
            Instantiate(projectile, point2, shootingStartPoint.rotation);
        }
    }
}