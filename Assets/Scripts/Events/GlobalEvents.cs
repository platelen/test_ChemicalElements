using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class GlobalEvents : MonoBehaviour
    {
        public static readonly UnityEvent OnStartDraggingFalse = new UnityEvent();

        public static void SendStartDraggingFalse()
        {
            OnStartDraggingFalse.Invoke();
        }
    }
}