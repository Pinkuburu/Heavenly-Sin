using HeavenlySin.GameEvents;
using HeavenlySin.Interactable;
using UnityEngine;

/// <summary>
/// This is a test class to demonstrate the outline of an interactable
/// object.
/// </summary>

//TODO: The way different types of items interact could be stored in scriptable objects
public class NPCInteractTest : MonoBehaviour, IInteractable
{
    #region Public Fields

    [Tooltip("The index number of the image displayed when hovering over an interactable object.")]
    public int imageIndex;
    [SerializeField] private IntEvent endHover;
    [SerializeField] private IntEvent startHover;
    
    #endregion
    
    #region Private Fields
    private const float MAX_RANGE = 100f;
    #endregion

    #region Properties
    public float MaxRange => MAX_RANGE;
    #endregion
    
    #region Public Methods
    public void Interact()
    {
        Debug.Log("Hello, World!");
    }

    public void OnEndHover()
    {
        endHover.Raise(imageIndex);
    }

    public void OnStartHover()
    {
        startHover.Raise(imageIndex);
    }
    #endregion
}
