// GENERATED AUTOMATICALLY FROM 'Assets/Scripts_Grid/TurnBasedIA.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TurnBasedIA : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TurnBasedIA()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TurnBasedIA"",
    ""maps"": [
        {
            ""name"": ""TurnBPlayer"",
            ""id"": ""7d910bbb-5f04-421b-b253-d7b68f23f8c1"",
            ""actions"": [
                {
                    ""name"": ""One"",
                    ""type"": ""Button"",
                    ""id"": ""b4a11874-5f26-4bab-9edc-7c7545ad68a3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Two"",
                    ""type"": ""Button"",
                    ""id"": ""e1789954-6a88-4ab2-bc16-b724b34b35fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Three"",
                    ""type"": ""Button"",
                    ""id"": ""e283f024-95e7-44d9-8fdd-7efb1f348817"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Four"",
                    ""type"": ""Button"",
                    ""id"": ""0bb163ac-0c44-480f-9db0-b7867881117f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Five"",
                    ""type"": ""Button"",
                    ""id"": ""743075e9-217f-4c16-b01c-d828f51d2c09"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zero"",
                    ""type"": ""Button"",
                    ""id"": ""13483cdb-63bf-4035-8e80-d456cb87aa51"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""5ff915b4-8687-4e12-b026-3a8a21594d85"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D"",
                    ""type"": ""Button"",
                    ""id"": ""37f2700d-dfc6-445d-b7ef-10406f3d5087"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f553cbf5-1aa2-48d0-8c2a-9a00377e8d30"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""my control scheme"",
                    ""action"": ""One"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ae6f4c3-979b-4181-b29b-7d0b377364df"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""my control scheme"",
                    ""action"": ""Two"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15de7b99-90c6-42c0-9e52-ed40749248c1"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""my control scheme"",
                    ""action"": ""Three"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3dfe38b0-85ce-4809-a00c-c263e441402b"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""my control scheme"",
                    ""action"": ""Four"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d94c941e-68da-40b6-a48b-8ecf3434b3c9"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""my control scheme"",
                    ""action"": ""Five"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39b5d000-0567-47dc-9960-af1761101801"",
                    ""path"": ""<Keyboard>/0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""my control scheme"",
                    ""action"": ""Zero"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92aea3f3-8f4f-4ee8-9f13-86593e3f8a21"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""my control scheme"",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd3127fd-1c6e-4817-8453-16ec763263b8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""my control scheme"",
                    ""action"": ""D"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""my control scheme"",
            ""bindingGroup"": ""my control scheme"",
            ""devices"": []
        }
    ]
}");
        // TurnBPlayer
        m_TurnBPlayer = asset.FindActionMap("TurnBPlayer", throwIfNotFound: true);
        m_TurnBPlayer_One = m_TurnBPlayer.FindAction("One", throwIfNotFound: true);
        m_TurnBPlayer_Two = m_TurnBPlayer.FindAction("Two", throwIfNotFound: true);
        m_TurnBPlayer_Three = m_TurnBPlayer.FindAction("Three", throwIfNotFound: true);
        m_TurnBPlayer_Four = m_TurnBPlayer.FindAction("Four", throwIfNotFound: true);
        m_TurnBPlayer_Five = m_TurnBPlayer.FindAction("Five", throwIfNotFound: true);
        m_TurnBPlayer_Zero = m_TurnBPlayer.FindAction("Zero", throwIfNotFound: true);
        m_TurnBPlayer_A = m_TurnBPlayer.FindAction("A", throwIfNotFound: true);
        m_TurnBPlayer_D = m_TurnBPlayer.FindAction("D", throwIfNotFound: true);
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

    // TurnBPlayer
    private readonly InputActionMap m_TurnBPlayer;
    private ITurnBPlayerActions m_TurnBPlayerActionsCallbackInterface;
    private readonly InputAction m_TurnBPlayer_One;
    private readonly InputAction m_TurnBPlayer_Two;
    private readonly InputAction m_TurnBPlayer_Three;
    private readonly InputAction m_TurnBPlayer_Four;
    private readonly InputAction m_TurnBPlayer_Five;
    private readonly InputAction m_TurnBPlayer_Zero;
    private readonly InputAction m_TurnBPlayer_A;
    private readonly InputAction m_TurnBPlayer_D;
    public struct TurnBPlayerActions
    {
        private @TurnBasedIA m_Wrapper;
        public TurnBPlayerActions(@TurnBasedIA wrapper) { m_Wrapper = wrapper; }
        public InputAction @One => m_Wrapper.m_TurnBPlayer_One;
        public InputAction @Two => m_Wrapper.m_TurnBPlayer_Two;
        public InputAction @Three => m_Wrapper.m_TurnBPlayer_Three;
        public InputAction @Four => m_Wrapper.m_TurnBPlayer_Four;
        public InputAction @Five => m_Wrapper.m_TurnBPlayer_Five;
        public InputAction @Zero => m_Wrapper.m_TurnBPlayer_Zero;
        public InputAction @A => m_Wrapper.m_TurnBPlayer_A;
        public InputAction @D => m_Wrapper.m_TurnBPlayer_D;
        public InputActionMap Get() { return m_Wrapper.m_TurnBPlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TurnBPlayerActions set) { return set.Get(); }
        public void SetCallbacks(ITurnBPlayerActions instance)
        {
            if (m_Wrapper.m_TurnBPlayerActionsCallbackInterface != null)
            {
                @One.started -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnOne;
                @One.performed -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnOne;
                @One.canceled -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnOne;
                @Two.started -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnTwo;
                @Two.performed -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnTwo;
                @Two.canceled -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnTwo;
                @Three.started -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnThree;
                @Three.performed -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnThree;
                @Three.canceled -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnThree;
                @Four.started -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnFour;
                @Four.performed -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnFour;
                @Four.canceled -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnFour;
                @Five.started -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnFive;
                @Five.performed -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnFive;
                @Five.canceled -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnFive;
                @Zero.started -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnZero;
                @Zero.performed -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnZero;
                @Zero.canceled -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnZero;
                @A.started -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnA;
                @A.performed -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnA;
                @A.canceled -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnA;
                @D.started -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnD;
                @D.performed -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnD;
                @D.canceled -= m_Wrapper.m_TurnBPlayerActionsCallbackInterface.OnD;
            }
            m_Wrapper.m_TurnBPlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @One.started += instance.OnOne;
                @One.performed += instance.OnOne;
                @One.canceled += instance.OnOne;
                @Two.started += instance.OnTwo;
                @Two.performed += instance.OnTwo;
                @Two.canceled += instance.OnTwo;
                @Three.started += instance.OnThree;
                @Three.performed += instance.OnThree;
                @Three.canceled += instance.OnThree;
                @Four.started += instance.OnFour;
                @Four.performed += instance.OnFour;
                @Four.canceled += instance.OnFour;
                @Five.started += instance.OnFive;
                @Five.performed += instance.OnFive;
                @Five.canceled += instance.OnFive;
                @Zero.started += instance.OnZero;
                @Zero.performed += instance.OnZero;
                @Zero.canceled += instance.OnZero;
                @A.started += instance.OnA;
                @A.performed += instance.OnA;
                @A.canceled += instance.OnA;
                @D.started += instance.OnD;
                @D.performed += instance.OnD;
                @D.canceled += instance.OnD;
            }
        }
    }
    public TurnBPlayerActions @TurnBPlayer => new TurnBPlayerActions(this);
    private int m_mycontrolschemeSchemeIndex = -1;
    public InputControlScheme mycontrolschemeScheme
    {
        get
        {
            if (m_mycontrolschemeSchemeIndex == -1) m_mycontrolschemeSchemeIndex = asset.FindControlSchemeIndex("my control scheme");
            return asset.controlSchemes[m_mycontrolschemeSchemeIndex];
        }
    }
    public interface ITurnBPlayerActions
    {
        void OnOne(InputAction.CallbackContext context);
        void OnTwo(InputAction.CallbackContext context);
        void OnThree(InputAction.CallbackContext context);
        void OnFour(InputAction.CallbackContext context);
        void OnFive(InputAction.CallbackContext context);
        void OnZero(InputAction.CallbackContext context);
        void OnA(InputAction.CallbackContext context);
        void OnD(InputAction.CallbackContext context);
    }
}
