using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
namespace Transporting
{
    public class SwitchTrigger : MonoBehaviour
    {
        [SerializeField]
        private string playerTag = "Player";
        [SerializeField]
        private GameObject[] switchItems;
        [SerializeField]
        private bool startState;

        protected virtual void Start()
        {
            foreach (var item in switchItems)
            {
                item.SetActive(startState);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == playerTag)
            {
                SetStates(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == playerTag)
            {
                SetStates(false);
            }
        }

        private void SetStates(bool enter)
        {
            for (int i = 0; i < switchItems.Length; i++)
            {
                var state = enter ? !startState : startState;
                switchItems[i].SetActive(state);
            }
        }
    }
}