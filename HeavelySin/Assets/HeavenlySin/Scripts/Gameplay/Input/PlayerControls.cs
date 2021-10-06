// GENERATED AUTOMATICALLY FROM 'Assets/HeavenlySin/Scripts/Gameplay/Input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace HeavenlySin.Player
{
    public class @PlayerControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Overworld"",
            ""id"": ""52a161de-ba6d-4e1f-94d7-704397326413"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""e2b6eef7-77f4-4b0d-8ece-2dbd81e1b31c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""404e9981-6235-4cea-9d8b-fdf77367b5f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e7f7d88d-b308-4fca-bf0e-90b2705d5a27"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""f8c4c911-50e4-4d5e-a86d-6439801d4a8a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""5f917468-5328-4b1f-b81b-0ffb8fcd10e7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d47dd00d-8558-4f3b-8a20-2527ac9664b8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f056031a-bbee-43ec-a29a-de751deb3445"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""54cc552e-9955-4c9c-ae90-78609d69ba3f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9e0ee077-ce80-4c50-9ac2-b0533a5028fd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9199c543-ffe6-4d55-b2ef-f1b89ce83c77"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21bff309-59f8-4cdc-b997-4ac097f93a23"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5236773e-c06f-44f5-a080-bc104a5017cd"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Combat"",
            ""id"": ""6b21ec96-53f3-453e-a470-81ffa6590ded"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""5435a418-a80e-4521-927d-206fe1c4440e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""9ead4eb3-1268-4b5e-9d8b-09fb02fd2a03"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""220ba8f5-0ea1-4c06-ae58-d90814216f51"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""4ee2067b-60a5-40d5-b894-3b121f3bdb8d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8e9262ff-f9f7-4c68-9274-06fe69fb7e05"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d3bf5ee4-9e0c-491b-bb2e-719441f355c5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3714bab4-7e1f-4f44-bc7f-b9aeb6209bc4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ddabccba-24f7-4266-aa56-7a7ed24c12cc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2b6c5037-45b0-43ad-9324-35de4f72267e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dialogue"",
            ""id"": ""c36781d1-d9b2-4d56-9d13-a236c9d7758e"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""5bbd790f-0eb5-4f1e-92af-7c36b62c5c56"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3a243fad-e4ab-4b66-9651-32bd3c31d78c"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Start Menu"",
            ""id"": ""1db1333b-f668-4c63-9558-eda8a00b8d6b"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""6c82cb46-b496-4669-a1fa-c42ae24c80ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c9f5d113-5455-482b-93f9-87a6f88d5ad4"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Inventory"",
            ""id"": ""e631a44a-c4d6-470d-a57a-221762450803"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""8eb79457-8887-4c08-9847-0538ad3dca74"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""29ea1cda-6339-4222-b428-c593902025d7"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Overworld
            m_Overworld = asset.FindActionMap("Overworld", throwIfNotFound: true);
            m_Overworld_Movement = m_Overworld.FindAction("Movement", throwIfNotFound: true);
            m_Overworld_Jump = m_Overworld.FindAction("Jump", throwIfNotFound: true);
            m_Overworld_Look = m_Overworld.FindAction("Look", throwIfNotFound: true);
            m_Overworld_Interact = m_Overworld.FindAction("Interact", throwIfNotFound: true);
            // Combat
            m_Combat = asset.FindActionMap("Combat", throwIfNotFound: true);
            m_Combat_Movement = m_Combat.FindAction("Movement", throwIfNotFound: true);
            m_Combat_Jump = m_Combat.FindAction("Jump", throwIfNotFound: true);
            // Dialogue
            m_Dialogue = asset.FindActionMap("Dialogue", throwIfNotFound: true);
            m_Dialogue_Newaction = m_Dialogue.FindAction("New action", throwIfNotFound: true);
            // Start Menu
            m_StartMenu = asset.FindActionMap("Start Menu", throwIfNotFound: true);
            m_StartMenu_Newaction = m_StartMenu.FindAction("New action", throwIfNotFound: true);
            // Inventory
            m_Inventory = asset.FindActionMap("Inventory", throwIfNotFound: true);
            m_Inventory_Newaction = m_Inventory.FindAction("New action", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // Overworld
        private readonly InputActionMap m_Overworld;
        private IOverworldActions m_OverworldActionsCallbackInterface;
        private readonly InputAction m_Overworld_Movement;
        private readonly InputAction m_Overworld_Jump;
        private readonly InputAction m_Overworld_Look;
        private readonly InputAction m_Overworld_Interact;
        public struct OverworldActions
        {
            private @PlayerControls m_Wrapper;
            public OverworldActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Overworld_Movement;
            public InputAction @Jump => m_Wrapper.m_Overworld_Jump;
            public InputAction @Look => m_Wrapper.m_Overworld_Look;
            public InputAction @Interact => m_Wrapper.m_Overworld_Interact;
            public InputActionMap Get() { return m_Wrapper.m_Overworld; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(OverworldActions set) { return set.Get(); }
            public void SetCallbacks(IOverworldActions instance)
            {
                if (m_Wrapper.m_OverworldActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_OverworldActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_OverworldActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_OverworldActionsCallbackInterface.OnMovement;
                    @Jump.started -= m_Wrapper.m_OverworldActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_OverworldActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_OverworldActionsCallbackInterface.OnJump;
                    @Look.started -= m_Wrapper.m_OverworldActionsCallbackInterface.OnLook;
                    @Look.performed -= m_Wrapper.m_OverworldActionsCallbackInterface.OnLook;
                    @Look.canceled -= m_Wrapper.m_OverworldActionsCallbackInterface.OnLook;
                    @Interact.started -= m_Wrapper.m_OverworldActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_OverworldActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_OverworldActionsCallbackInterface.OnInteract;
                }
                m_Wrapper.m_OverworldActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Look.started += instance.OnLook;
                    @Look.performed += instance.OnLook;
                    @Look.canceled += instance.OnLook;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                }
            }
        }
        public OverworldActions @Overworld => new OverworldActions(this);

        // Combat
        private readonly InputActionMap m_Combat;
        private ICombatActions m_CombatActionsCallbackInterface;
        private readonly InputAction m_Combat_Movement;
        private readonly InputAction m_Combat_Jump;
        public struct CombatActions
        {
            private @PlayerControls m_Wrapper;
            public CombatActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Combat_Movement;
            public InputAction @Jump => m_Wrapper.m_Combat_Jump;
            public InputActionMap Get() { return m_Wrapper.m_Combat; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CombatActions set) { return set.Get(); }
            public void SetCallbacks(ICombatActions instance)
            {
                if (m_Wrapper.m_CombatActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnMovement;
                    @Jump.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnJump;
                }
                m_Wrapper.m_CombatActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                }
            }
        }
        public CombatActions @Combat => new CombatActions(this);

        // Dialogue
        private readonly InputActionMap m_Dialogue;
        private IDialogueActions m_DialogueActionsCallbackInterface;
        private readonly InputAction m_Dialogue_Newaction;
        public struct DialogueActions
        {
            private @PlayerControls m_Wrapper;
            public DialogueActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Newaction => m_Wrapper.m_Dialogue_Newaction;
            public InputActionMap Get() { return m_Wrapper.m_Dialogue; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(DialogueActions set) { return set.Get(); }
            public void SetCallbacks(IDialogueActions instance)
            {
                if (m_Wrapper.m_DialogueActionsCallbackInterface != null)
                {
                    @Newaction.started -= m_Wrapper.m_DialogueActionsCallbackInterface.OnNewaction;
                    @Newaction.performed -= m_Wrapper.m_DialogueActionsCallbackInterface.OnNewaction;
                    @Newaction.canceled -= m_Wrapper.m_DialogueActionsCallbackInterface.OnNewaction;
                }
                m_Wrapper.m_DialogueActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Newaction.started += instance.OnNewaction;
                    @Newaction.performed += instance.OnNewaction;
                    @Newaction.canceled += instance.OnNewaction;
                }
            }
        }
        public DialogueActions @Dialogue => new DialogueActions(this);

        // Start Menu
        private readonly InputActionMap m_StartMenu;
        private IStartMenuActions m_StartMenuActionsCallbackInterface;
        private readonly InputAction m_StartMenu_Newaction;
        public struct StartMenuActions
        {
            private @PlayerControls m_Wrapper;
            public StartMenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Newaction => m_Wrapper.m_StartMenu_Newaction;
            public InputActionMap Get() { return m_Wrapper.m_StartMenu; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(StartMenuActions set) { return set.Get(); }
            public void SetCallbacks(IStartMenuActions instance)
            {
                if (m_Wrapper.m_StartMenuActionsCallbackInterface != null)
                {
                    @Newaction.started -= m_Wrapper.m_StartMenuActionsCallbackInterface.OnNewaction;
                    @Newaction.performed -= m_Wrapper.m_StartMenuActionsCallbackInterface.OnNewaction;
                    @Newaction.canceled -= m_Wrapper.m_StartMenuActionsCallbackInterface.OnNewaction;
                }
                m_Wrapper.m_StartMenuActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Newaction.started += instance.OnNewaction;
                    @Newaction.performed += instance.OnNewaction;
                    @Newaction.canceled += instance.OnNewaction;
                }
            }
        }
        public StartMenuActions @StartMenu => new StartMenuActions(this);

        // Inventory
        private readonly InputActionMap m_Inventory;
        private IInventoryActions m_InventoryActionsCallbackInterface;
        private readonly InputAction m_Inventory_Newaction;
        public struct InventoryActions
        {
            private @PlayerControls m_Wrapper;
            public InventoryActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Newaction => m_Wrapper.m_Inventory_Newaction;
            public InputActionMap Get() { return m_Wrapper.m_Inventory; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InventoryActions set) { return set.Get(); }
            public void SetCallbacks(IInventoryActions instance)
            {
                if (m_Wrapper.m_InventoryActionsCallbackInterface != null)
                {
                    @Newaction.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnNewaction;
                    @Newaction.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnNewaction;
                    @Newaction.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnNewaction;
                }
                m_Wrapper.m_InventoryActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Newaction.started += instance.OnNewaction;
                    @Newaction.performed += instance.OnNewaction;
                    @Newaction.canceled += instance.OnNewaction;
                }
            }
        }
        public InventoryActions @Inventory => new InventoryActions(this);
        public interface IOverworldActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnLook(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
        }
        public interface ICombatActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
        }
        public interface IDialogueActions
        {
            void OnNewaction(InputAction.CallbackContext context);
        }
        public interface IStartMenuActions
        {
            void OnNewaction(InputAction.CallbackContext context);
        }
        public interface IInventoryActions
        {
            void OnNewaction(InputAction.CallbackContext context);
        }
    }
}
