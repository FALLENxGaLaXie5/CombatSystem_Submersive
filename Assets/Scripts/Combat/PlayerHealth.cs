using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;

namespace Game.Combat
{
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        #region Class Variables

        public int currentHealth = 0;

        #endregion

        #region Class Functions

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            WinCheck.Instance.CheckForWinner();
            Destroy(gameObject);
        }

        public void SetInitialHealth(int health) => currentHealth = health;

        #endregion
    }
}