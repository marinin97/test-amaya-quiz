// GENERATED AUTOMATICALLY FROM 'Assets/Game/Scripts/Inputs/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace TestAmayaQuiz.Inputs
{
    public class @Controls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""PlayerMap"",
            ""id"": ""f6e7492a-48a0-4271-a9be-06a7d00cb99c"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""c8b2101e-183e-4983-83e3-8b9bedff4164"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Position"",
                    ""type"": ""Value"",
                    ""id"": ""1aff1e89-8e84-482e-b594-d7a7f8da69d4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f90228d7-0b02-4d43-bf38-8c08b444539b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""416f5b19-46c1-4967-b935-ca5180993260"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b30f9eb-c216-429f-b679-80cbbfa64339"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""926cb86f-2f2a-4910-bc0e-418aae695006"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Position"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // PlayerMap
            m_PlayerMap = asset.FindActionMap("PlayerMap", throwIfNotFound: true);
            m_PlayerMap_Select = m_PlayerMap.FindAction("Select", throwIfNotFound: true);
            m_PlayerMap_Position = m_PlayerMap.FindAction("Position", throwIfNotFound: true);
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

        // PlayerMap
        private readonly InputActionMap m_PlayerMap;
        private IPlayerMapActions m_PlayerMapActionsCallbackInterface;
        private readonly InputAction m_PlayerMap_Select;
        private readonly InputAction m_PlayerMap_Position;
        public struct PlayerMapActions
        {
            private @Controls m_Wrapper;
            public PlayerMapActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Select => m_Wrapper.m_PlayerMap_Select;
            public InputAction @Position => m_Wrapper.m_PlayerMap_Position;
            public InputActionMap Get() { return m_Wrapper.m_PlayerMap; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerMapActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerMapActions instance)
            {
                if (m_Wrapper.m_PlayerMapActionsCallbackInterface != null)
                {
                    @Select.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnSelect;
                    @Select.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnSelect;
                    @Select.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnSelect;
                    @Position.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnPosition;
                    @Position.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnPosition;
                    @Position.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnPosition;
                }
                m_Wrapper.m_PlayerMapActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Select.started += instance.OnSelect;
                    @Select.performed += instance.OnSelect;
                    @Select.canceled += instance.OnSelect;
                    @Position.started += instance.OnPosition;
                    @Position.performed += instance.OnPosition;
                    @Position.canceled += instance.OnPosition;
                }
            }
        }
        public PlayerMapActions @PlayerMap => new PlayerMapActions(this);
        public interface IPlayerMapActions
        {
            void OnSelect(InputAction.CallbackContext context);
            void OnPosition(InputAction.CallbackContext context);
        }
    }
}
