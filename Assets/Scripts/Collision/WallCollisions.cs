using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Collisions
{
    public class WallCollisions : MonoBehaviour, ICollisionHandler
    {
        public void Collide(Collision2D collision)
        {
            //No plans currently to make collisions affect wall; however, this gives the means to add that functionality in the future easily.
            //Currently, can use this in place of tags for collisions as well, so hard coding isn't a thing.
            print("Could always put a dent in the wall...");
        }
    }

}
