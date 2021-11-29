// GENERATED AUTOMATICALLY FROM 'Assets/TestScene/MyInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MyInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MyInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MyInput"",
    ""maps"": [
        {
            ""name"": ""basicInputs"",
            ""id"": ""e709378b-567c-4ab7-80de-7004b375adf3"",
            ""actions"": [
                {
                    ""name"": ""SimpleClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1b9fe422-0fdc-4099-b02f-2fa054d12121"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""4e8cafcf-761c-4d64-9565-7b594c3d2234"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6f7f9265-6b0a-40c6-a57a-3ffaf4c3b33a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SimpleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d962e3f8-0ef0-4948-a292-fa917eb0684d"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SimpleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""670ed831-000a-4265-a262-53462042f9d9"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af1904e9-558a-4b9d-86aa-aeecbf2a86ac"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // basicInputs
        m_basicInputs = asset.FindActionMap("basicInputs", throwIfNotFound: true);
        m_basicInputs_SimpleClick = m_basicInputs.FindAction("SimpleClick", throwIfNotFound: true);
        m_basicInputs_MousePosition = m_basicInputs.FindAction("MousePosition", throwIfNotFound: true);
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

    // basicInputs
    private readonly InputActionMap m_basicInputs;
    private IBasicInputsActions m_BasicInputsActionsCallbackInterface;
    private readonly InputAction m_basicInputs_SimpleClick;
    private readonly InputAction m_basicInputs_MousePosition;
    public struct BasicInputsActions
    {
        private @MyInput m_Wrapper;
        public BasicInputsActions(@MyInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @SimpleClick => m_Wrapper.m_basicInputs_SimpleClick;
        public InputAction @MousePosition => m_Wrapper.m_basicInputs_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_basicInputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BasicInputsActions set) { return set.Get(); }
        public void SetCallbacks(IBasicInputsActions instance)
        {
            if (m_Wrapper.m_BasicInputsActionsCallbackInterface != null)
            {
                @SimpleClick.started -= m_Wrapper.m_BasicInputsActionsCallbackInterface.OnSimpleClick;
                @SimpleClick.performed -= m_Wrapper.m_BasicInputsActionsCallbackInterface.OnSimpleClick;
                @SimpleClick.canceled -= m_Wrapper.m_BasicInputsActionsCallbackInterface.OnSimpleClick;
                @MousePosition.started -= m_Wrapper.m_BasicInputsActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_BasicInputsActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_BasicInputsActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_BasicInputsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SimpleClick.started += instance.OnSimpleClick;
                @SimpleClick.performed += instance.OnSimpleClick;
                @SimpleClick.canceled += instance.OnSimpleClick;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public BasicInputsActions @basicInputs => new BasicInputsActions(this);
    public interface IBasicInputsActions
    {
        void OnSimpleClick(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
}
