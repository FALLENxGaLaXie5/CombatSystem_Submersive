using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Combat
{
    public class BulletControl : MonoBehaviour
    {
        #region Class Variables

        Transform target;
        Bullet bulletConfig;
        Vector3 dir = Vector3.zero;

        #endregion

        #region Unity Events

        void Update()
        {
            if (!bulletConfig) return;

            if (target)
                dir = (target.position - transform.position).normalized;                
            transform.position += (dir * bulletConfig.Speed * Time.deltaTime);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent<IHealth>(out IHealth health))
            {
                if (!bulletConfig) return;
                health.TakeDamage(bulletConfig.Damage);
            }
            Destroy(gameObject);
        }

        #endregion

        #region Class Functions

        public void ConfigureTarget(Transform target, Bullet bullet)
        {
            this.target = target;
            bulletConfig = bullet;
        }

        #endregion
    }
}

