using UnityEngine;
using UnityEngine.Events;

namespace HeavenlySin.GameEvents
{
    /// <summary>
    /// This class is used for making scriptable object based event listeners
    /// and will be extended from for different types of listeners.
    /// </summary>
    public abstract class BaseGameEventListener<T, TE, TUer> : MonoBehaviour,
        IGameEventListener<T> where TE : BaseGameEvent<T> where TUer : UnityEvent<T>
    {
        [SerializeField]
        private TE gameEvent;
        private TE GameEvent 
        { 
            get => gameEvent;
            set => gameEvent = value;
        }
    
        [SerializeField]
        private TUer unityEventResponse;

        private void OnEnable()
        {
            if (gameEvent == null)
            {
                return;
            }
            GameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            if (gameEvent == null)
            {
                return;
            }
            GameEvent.UnRegisterListener(this);
        }

        public void OnEventRaised(T item)
        {
            unityEventResponse?.Invoke(item);
        }
    }
}
