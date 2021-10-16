using System.Collections.Generic;
using UnityEngine;

namespace HeavenlySin.GameEvents
{
    /// <summary>
    /// This class outlines the functionality for making scriptable object-based game events
    /// and gives the expandability of making events that pass in different variable types
    /// as well as keep track of which events have been raised and what listeners need to act on them.
    /// </summary>
    public abstract class BaseGameEvent<T> : ScriptableObject
    {
        private readonly List<IGameEventListener<T>> _eventListeners = new List<IGameEventListener<T>>();

        public void Raise(T item)
        {
            for (var i = _eventListeners.Count - 1; i >= 0; i--)
            {
                _eventListeners[i].OnEventRaised(item);
            }
        }

        public void RegisterListener(IGameEventListener<T> listener)
        {
            if (!_eventListeners.Contains(listener))
            {
                _eventListeners.Add(listener);
            }
        }
        public void UnRegisterListener(IGameEventListener<T> listener)
        {
            if (_eventListeners.Contains(listener))
            {
                _eventListeners.Remove(listener);
            }
        }
    }
}
