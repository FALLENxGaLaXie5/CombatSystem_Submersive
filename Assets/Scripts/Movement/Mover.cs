using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Movement
{
    public class Mover : MonoBehaviour
    {
        #region Class Functions

        //To be called in a Player Control based Update Event
        public void Move(Vector3 dir, float speed) => transform.position += (dir.normalized * speed * Time.deltaTime);

        #endregion
    }
}
