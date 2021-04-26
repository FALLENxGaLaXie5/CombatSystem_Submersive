using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Collisions
{
    public interface ICollisionHandler
    {
        void Collide(Collision2D collision);
    }
}
