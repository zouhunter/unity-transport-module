using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace Transporting
{
    [System.Serializable]
    public class TransportData
    {
        public string key;
        public Vector3 pos;
        public Quaternion rot;
    }
}