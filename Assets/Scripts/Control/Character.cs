using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Combat;

namespace Game.Control
{
    [CreateAssetMenu(fileName = "Character", menuName = "Characters/Create New Character Type", order = 0)]
    public class Character : ScriptableObject
    {
        #region Inspector Variables

        [SerializeField] int startingHealth = 10;
        [SerializeField] Weapon weapon;
        [SerializeField] CharacterType characterType;
        [SerializeField] float movementSpeed = 5f;

        #endregion

        #region DataAccessors
        public int StartingHealth
        {
            get { return startingHealth; }
        }

        public Weapon Weapon
        {
            get { return weapon; }
        }

        public CharacterType Type
        {
            get { return characterType; }
        }

        public float MovementSpeed
        {
            get { return movementSpeed; }
        }
        #endregion

        [System.Serializable]
        public enum CharacterType
        {
            Thug,
            Militia,
            Voidbringer
        }
    }
}