using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Transporting
{
    public abstract class TransportHook : ScriptableObject
    {
        public UnityEvent onEndExecute;
        public abstract void StartExecute();
    }
}