using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Movement;
using Game.Collisions;
using Game.Combat;

namespace Game.Control
{
    [RequireComponent(typeof(Mover))]
    [RequireComponent(typeof(CharacterCollisions))]
    public class CharacterControl : MonoBehaviour
    {
        #region Inspector Fields
        [SerializeField] Character characterConfig;

        #endregion

        #region Class/Cached Fields

        Mover mover;
        PlayerHealth health;
        PlayerCombat combat;
        CharacterCollisions collisionHandler;
        Vector3 facingDir = Vector3.zero;

        #endregion

        #region Unity Events
        void Awake()
        {
            mover = GetComponent<Mover>();
            collisionHandler = GetComponent<CharacterCollisions>();
            health = GetComponent<PlayerHealth>();
            combat = GetComponent<PlayerCombat>();
            combat.SetWeapon(characterConfig.Weapon);
        }

        void Start()
        {
            SetRandomDir();
            health.SetInitialHealth(characterConfig.StartingHealth);
        }

        void OnEnable() => collisionHandler.collisionAction += SetReflectedDir;

        void OnDisable() => collisionHandler.collisionAction -= SetReflectedDir;

        void Update() => mover.Move(facingDir, characterConfig.MovementSpeed);

        #endregion

        #region Class Functions

        void SetRandomDir()
        {
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            facingDir = new Vector3(x, y, 0f);
        }

        void SetReflectedDir(Collision2D collision)
        {
            Vector3 newDirection = Vector3.Reflect(facingDir, collision.contacts[0].normal);
            facingDir = new Vector3(newDirection.x, newDirection.y, 0f);
        }

        #endregion
    }
}  