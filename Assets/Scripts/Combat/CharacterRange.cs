using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Collisions;

namespace Game.Combat
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class CharacterRange : MonoBehaviour
    {
        #region Inspector/Private Fields

        [SerializeField] LayerMask rangeCheckMask;
        public event Action setWeaponRangeSize;
        public List<Transform> rangedUnits { get; private set; } = new List<Transform>();

        #endregion

        #region Class/Cached Fields
        CircleCollider2D rangeTrigger;

        #endregion

        #region Unity Events

        void Awake() => rangeTrigger = GetComponent<CircleCollider2D>();

        void Start()
        {
            setWeaponRangeSize?.Invoke();
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, rangeTrigger.radius);
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<CharacterCollisions>(out CharacterCollisions collisions))
            {
                rangedUnits.Add(collision.transform);
            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent<CharacterCollisions>(out CharacterCollisions collisions))
            {
                rangedUnits.Remove(collision.transform);
            }
        }

        #endregion
    }
}