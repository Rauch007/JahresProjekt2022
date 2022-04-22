// GENERATED AUTOMATICALLY FROM 'Assets/Controller.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controller : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controller()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controller"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""f429b923-6e41-49f1-96ef-82f19188fe16"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""cbb040fc-b1ea-400a-8428-2b97bd8383fd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""e834e097-b49f-41b1-a600-c2b99972b18a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""325dbd36-56cb-4024-92a4-f3bb36c90454"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Short Attack"",
                    ""type"": ""Button"",
                    ""id"": ""80086e4f-6423-4ee8-851a-e22609e838e5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Longrange Attack"",
                    ""type"": ""Button"",
                    ""id"": ""6b8e360d-4a30-4d07-b6e4-bf1bfd657483"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shield"",
                    ""type"": ""Button"",
                    ""id"": ""6cba8555-0918-4120-aff1-5628ef1e44fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6a0110c2-48d8-474e-91a0-457fddc5e88a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9c303a3-b909-4c9d-8c3e-b31cdfe02402"",
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
                    ""id"": ""8d2cc391-688c-4d7d-8142-c03ac9339fec"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d972c3e1-9f86-40a3-b52b-28bbe19acda3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6593f7ee-5997-4c57-bb70-ea533a48c806"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""02c2a444-bd96-4264-ba7a-4e833488024c"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""de413834-f7fc-4ae2-8e76-79e05f54e1ab"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""adb36964-3968-45ef-90f2-bd1dba79a600"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d79b93f0-983b-49f5-b1a6-1a0c6658ae92"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d97b0bd-4d83-4732-b644-ca792105c75e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Short Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""387dbd06-7f39-4eef-9b21-55e4acee2d21"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Short Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b472621-5b84-454d-bd1e-5d01e60663eb"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Longrange Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e369cba2-13db-4ccd-a4a6-5ed4e4222950"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControls
        m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
        m_PlayerControls_Jump = m_PlayerControls.FindAction("Jump", throwIfNotFound: true);
        m_PlayerControls_Move = m_PlayerControls.FindAction("Move", throwIfNotFound: true);
        m_PlayerControls_Menu = m_PlayerControls.FindAction("Menu", throwIfNotFound: true);
        m_PlayerControls_ShortAttack = m_PlayerControls.FindAction("Short Attack", throwIfNotFound: true);
        m_PlayerControls_LongrangeAttack = m_PlayerControls.FindAction("Longrange Attack", throwIfNotFound: true);
        m_PlayerControls_Shield = m_PlayerControls.FindAction("Shield", throwIfNotFound: true);
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

    // PlayerControls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_Jump;
    private readonly InputAction m_PlayerControls_Move;
    private readonly InputAction m_PlayerControls_Menu;
    private readonly InputAction m_PlayerControls_ShortAttack;
    private readonly InputAction m_PlayerControls_LongrangeAttack;
    private readonly InputAction m_PlayerControls_Shield;
    public struct PlayerControlsActions
    {
        private @Controller m_Wrapper;
        public PlayerControlsActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_PlayerControls_Jump;
        public InputAction @Move => m_Wrapper.m_PlayerControls_Move;
        public InputAction @Menu => m_Wrapper.m_PlayerControls_Menu;
        public InputAction @ShortAttack => m_Wrapper.m_PlayerControls_ShortAttack;
        public InputAction @LongrangeAttack => m_Wrapper.m_PlayerControls_LongrangeAttack;
        public InputAction @Shield => m_Wrapper.m_PlayerControls_Shield;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Menu.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMenu;
                @ShortAttack.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnShortAttack;
                @ShortAttack.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnShortAttack;
                @ShortAttack.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnShortAttack;
                @LongrangeAttack.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLongrangeAttack;
                @LongrangeAttack.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLongrangeAttack;
                @LongrangeAttack.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLongrangeAttack;
                @Shield.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnShield;
                @Shield.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnShield;
                @Shield.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnShield;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
                @ShortAttack.started += instance.OnShortAttack;
                @ShortAttack.performed += instance.OnShortAttack;
                @ShortAttack.canceled += instance.OnShortAttack;
                @LongrangeAttack.started += instance.OnLongrangeAttack;
                @LongrangeAttack.performed += instance.OnLongrangeAttack;
                @LongrangeAttack.canceled += instance.OnLongrangeAttack;
                @Shield.started += instance.OnShield;
                @Shield.performed += instance.OnShield;
                @Shield.canceled += instance.OnShield;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);
    public interface IPlayerControlsActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
        void OnShortAttack(InputAction.CallbackContext context);
        void OnLongrangeAttack(InputAction.CallbackContext context);
        void OnShield(InputAction.CallbackContext context);
    }
}
