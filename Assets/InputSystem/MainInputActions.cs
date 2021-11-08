// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/MainInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainInputActions"",
    ""maps"": [
        {
            ""name"": ""BasicInput"",
            ""id"": ""8cc80c58-f780-45f1-90fc-42c97f34b2dc"",
            ""actions"": [
                {
                    ""name"": ""MouseClick"",
                    ""type"": ""Value"",
                    ""id"": ""2dcab357-0c95-4383-a1cd-cc0e6675615a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d8916725-b0d8-4067-8e66-dcabec9e4b0b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // BasicInput
        m_BasicInput = asset.FindActionMap("BasicInput", throwIfNotFound: true);
        m_BasicInput_MouseClick = m_BasicInput.FindAction("MouseClick", throwIfNotFound: true);
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

    // BasicInput
    private readonly InputActionMap m_BasicInput;
    private IBasicInputActions m_BasicInputActionsCallbackInterface;
    private readonly InputAction m_BasicInput_MouseClick;
    public struct BasicInputActions
    {
        private @MainInputActions m_Wrapper;
        public BasicInputActions(@MainInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseClick => m_Wrapper.m_BasicInput_MouseClick;
        public InputActionMap Get() { return m_Wrapper.m_BasicInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BasicInputActions set) { return set.Get(); }
        public void SetCallbacks(IBasicInputActions instance)
        {
            if (m_Wrapper.m_BasicInputActionsCallbackInterface != null)
            {
                @MouseClick.started -= m_Wrapper.m_BasicInputActionsCallbackInterface.OnMouseClick;
                @MouseClick.performed -= m_Wrapper.m_BasicInputActionsCallbackInterface.OnMouseClick;
                @MouseClick.canceled -= m_Wrapper.m_BasicInputActionsCallbackInterface.OnMouseClick;
            }
            m_Wrapper.m_BasicInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseClick.started += instance.OnMouseClick;
                @MouseClick.performed += instance.OnMouseClick;
                @MouseClick.canceled += instance.OnMouseClick;
            }
        }
    }
    public BasicInputActions @BasicInput => new BasicInputActions(this);
    public interface IBasicInputActions
    {
        void OnMouseClick(InputAction.CallbackContext context);
    }
}
