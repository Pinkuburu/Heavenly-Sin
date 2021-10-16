namespace HeavenlySin.Interactable
{
    /// <summary>
    /// This class is a contract that outlines how all
    /// interactable objects will function, and each object can
    /// expand off of this functionality.
    /// </summary>
    public interface IInteractable
    {
        #region Properties
        float MaxRange { get; }
        #endregion
        
        #region Public Methods
        void Interact();
        void OnEndHover();
        void OnStartHover();
        #endregion
    }
}