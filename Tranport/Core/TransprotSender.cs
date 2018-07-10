using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace Transporting
{
    public class TransprotSender : MonoBehaviour
    {
        [SerializeField]
        private TransportData data = new TransportData();
        [SerializeField]
        private TransportHook startHook;
        [SerializeField]
        private TransportHook endHook;

        private void Awake()
        {
            startHook = Instantiate(startHook);
            endHook = Instantiate(endHook);
            if (startHook) startHook.onEndExecute.AddListener(TransportInternal);
        }
        public void Transport()
        {
            if (startHook) startHook.StartExecute();
            else
            {
                TransportInternal();
            }
        }

        public void Transport(Transform target)
        {
            if (target != null)
            {
                data.pos = target.position;
                data.rot = target.rotation;
            }
            Transport();
        }

        private void TransportInternal()
        {
            TransportUtil.Trigger(data);
            if (endHook != null)
                endHook.StartExecute();
        }
    }
}