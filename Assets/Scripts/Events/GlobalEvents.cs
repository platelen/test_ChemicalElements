using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class GlobalEvents : MonoBehaviour
    {
        public static readonly UnityEvent OnStartDraggingFalse = new UnityEvent();
        public static readonly UnityEvent OnStartFinishGame = new UnityEvent();

        public static void SendStartDraggingFalse()
        {
            OnStartDraggingFalse.Invoke();
        }

        public static void SendStartFinishGame()
        {
            OnStartFinishGame.Invoke();
        }
    }
}