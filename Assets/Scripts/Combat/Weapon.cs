using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Create New Weapon Type", order = 1)]
    public class Weapon : ScriptableObject
    {
        #region Data Variables

        [SerializeField] float attackSpeed = 5f;
        [SerializeField] float range = 20f;
        [SerializeField] Bullet bulletType;

        [SerializeField] WeaponType weaponType;

        #endregion

        #region Data Accessors

        public float AttackSpeed
        {
            get { return attackSpeed; }
        }

        public float Range
        {
            get { return range; }
        }

        public Bullet Bullet
        {
            get { return bulletType; }
        }

        public WeaponType Type
        {
            get { return weaponType; }
        }


        #endregion

        [System.Serializable]
        public enum WeaponType
        {
            Rifle,
            Pistol,
            LaserGun,
        }

        #region Class Functions

        public void Fire(Vector3 spawnLocation, Transform target) => bulletType.Spawn(spawnLocation, target);

        #endregion
    }
}