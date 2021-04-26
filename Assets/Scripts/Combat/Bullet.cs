using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Combat
{
    [CreateAssetMenu(fileName = "Bullet", menuName = "Bullets/Create New Bullet Type", order = 2)]
    public class Bullet : ScriptableObject
    {
        #region Data Variables

        [SerializeField] int damage = 1;
        [SerializeField] float speed = 30f;

        [SerializeField] GameObject bulletPrefab;
        [SerializeField] BulletType bulletType;

        #endregion

        #region Data Accessors

        public int Damage
        {
            get { return damage; }
        }

        public float Speed
        {
            get { return speed; }
        }

        public BulletType Type
        {
            get { return bulletType; }
        }

        #endregion

        [System.Serializable]
        public enum BulletType
        {
            BigBullet,
            SmallBullet,
            Laser,
            VoidBreath
        }

        #region Class Functions

        public void Spawn(Vector3 spawnLocation, Transform targetTransform)
        {
            if (!bulletPrefab) return;

            GameObject bullet = Instantiate(bulletPrefab, spawnLocation, Quaternion.identity);
            BulletControl control = bullet.GetComponent<BulletControl>();
            control.ConfigureTarget(targetTransform, this);
            bullet.name = bulletType.ToString();
        }

        #endregion
    }
}
