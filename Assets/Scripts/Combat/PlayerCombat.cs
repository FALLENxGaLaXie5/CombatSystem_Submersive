using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Combat
{
    public class PlayerCombat : MonoBehaviour
    {

        #region Class Variables

        Weapon weapon;
        CharacterRange rangeHandler;

        #endregion

        #region Unity Events

        void Awake() => rangeHandler = GetComponentInChildren<CharacterRange>();

        void Start() => StartCoroutine(FireOnInterval()); 

        void OnEnable()
        {
            //Adding in check for this because we don't have a way to couple this component as with "Require Component"
            if (rangeHandler)
                rangeHandler.setWeaponRangeSize += SetWeaponRangeTrigger;
            else
                Debug.LogError("Where is the Range Handler?");
        }

        void OnDisable()
        {
            if (rangeHandler)
                rangeHandler.setWeaponRangeSize -= SetWeaponRangeTrigger;
            else
                Debug.LogError("Where is the Range Handler?");
        }

        #endregion

        #region Class Functions

        IEnumerator FireOnInterval()
        {
            while (true)
            {
                if (rangeHandler.rangedUnits.Count > 0)
                {
                    int rand = Random.Range(0, rangeHandler.rangedUnits.Count);
                    Transform target = rangeHandler.rangedUnits[rand];
                    Vector3 dir = (target.position - transform.position).normalized;
                    weapon.Fire(transform.position + dir, rangeHandler.rangedUnits[rand]);
                }
                
                yield return new WaitForSeconds(weapon.AttackSpeed);
            }
        }

        public void SetWeapon(Weapon weapon) => this.weapon = weapon;

        void SetWeaponRangeTrigger()
        {
            if (weapon)
                rangeHandler.transform.GetComponent<CircleCollider2D>().radius = weapon.Range;
            else
                Debug.LogError("Why has weapon not been set yet?");            
        }

        #endregion
    }
}