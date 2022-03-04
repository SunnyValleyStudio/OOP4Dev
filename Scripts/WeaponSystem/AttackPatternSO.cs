using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SVS.WeaponSystem
{
    public abstract class AttackPatternSO : ScriptableObject
    {
        [SerializeField]
        protected float attackDelay = 0.2f;

        public float AttackDelay => attackDelay;

        [SerializeField]
        protected GameObject projectile;

        [SerializeField]
        protected AudioClip weaponSFX;

        public AudioClip AudioSFX => weaponSFX;

        public abstract void Perform(Transform shootingStartPoint);
    }
}