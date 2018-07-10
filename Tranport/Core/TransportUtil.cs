using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
namespace Transporting
{
    public static class TransportUtil {
        private static List<UnityAction<TransportData>> eventList = new List<UnityAction<TransportData>>();
        public static void Regist(UnityAction<TransportData> action)
        {
            if (action == null) return;

            if (eventList != null)
            {
                eventList.Add(action);
            }
            else
            {
                eventList = new List<UnityAction<TransportData>>() { action };
            }
        }
        public static void Remove(UnityAction<TransportData> action)
        {
            if (action == null) return;
            if (eventList.Contains(action))
            {
                eventList.Remove(action);
            }
        }
        public static void Trigger( TransportData data)
        {
            var actions = eventList.ToArray();
            foreach (var item in actions)
            {
                if (item != null)
                {
                    item.Invoke(data);
                }
            }
        }
    }
}