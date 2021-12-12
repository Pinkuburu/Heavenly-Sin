using System;
using HeavenlySin.Gameplay;
using HeavenlySin.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HeavenlySin
{
    [CreateAssetMenu(fileName = "New InputManager", menuName = "ScriptableObjects/InputManager")]
    public class InputManager : ScriptableObject
    {
        public PlayerControls InputActions;
        public event Action<InputActionMap> ActionMapChange;
        private void OnEnable()
        {
            InputActions = new PlayerControls();
        }

        public void ToggleActionMap(InputActionMap actionMap)
        {
            if (actionMap.enabled)
                return;
            InputActions.Disable();
            ActionMapChange?.Invoke(actionMap);
            actionMap.Enable();
        }
    }
}