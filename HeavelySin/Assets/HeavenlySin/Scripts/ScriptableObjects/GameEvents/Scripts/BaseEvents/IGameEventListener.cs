namespace HeavenlySin.GameEvents
{
    /// <summary>
    /// This interface is a contract with event listeners
    /// that will always have an OnEventRaised method
    /// when the event is called, and the listener needs to perform an action.
    /// </summary>
    public interface IGameEventListener<in T>
    {
        void OnEventRaised(T item);
    }
}
