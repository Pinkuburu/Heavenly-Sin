namespace HeavenlySin.Interactable
{
    /// <summary>
    /// 
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