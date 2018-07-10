using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace Transporting
{
    public abstract class TransprotRegister : MonoBehaviour
    {
        protected abstract string key { get; }
        protected virtual void OnEnable()
        {
          TransportUtil.Regist(TransoprtTo);
        }
        protected virtual void OnDisable()
        {
            TransportUtil.Remove( TransoprtTo);
        }
        protected abstract void TransoprtTo(TransportData data);
    }
}