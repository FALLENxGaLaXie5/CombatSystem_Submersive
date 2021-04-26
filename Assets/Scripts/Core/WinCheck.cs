using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Core
{
    public class WinCheck : MonoBehaviour
    {
        [SerializeField] Text text;
        public static WinCheck Instance { get; private set; }

        void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this.gameObject);
            else
                Instance = this;
        }

        public void CheckForWinner()
        {
            if (!text) Debug.LogError("Need to set up text object");

            int countAfterDeath = transform.childCount - 1;
            if(countAfterDeath == 1)
                text.text = transform.GetChild(0).name + " is the winner!";
            else if (countAfterDeath == 0)
                text.text = "All lifeforms killed off!";
        }
    }

}
