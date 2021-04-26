using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Collisions
{
    public class CharacterCollisions : MonoBehaviour, ICollisionHandler
    {
        public event Action<Collision2D> collisionAction;

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (TryGetComponent<ICollisionHandler>(out ICollisionHandler collisionHandler))
                collisionHandler.Collide(collision);
        }

        public void Collide(Collision2D collision) => collisionAction?.Invoke(collision);
        
    }
}