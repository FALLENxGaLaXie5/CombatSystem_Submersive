using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Combat
{
    public interface IHealth
    {
        void TakeDamage(int damage);
        void Die();
        void SetInitialHealth(int health);
    }
}