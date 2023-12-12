//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Script/Input Action/New Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @NewControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @NewControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""New Controls"",
    ""maps"": [
        {
            ""name"": ""Anywhere"",
            ""id"": ""ec2cda9d-8502-47a7-a1d6-14f61f81f158"",
            ""actions"": [
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""df185673-ab4f-45b7-aa6b-78353998d7bb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e7e9ce14-a355-455d-b4aa-8424552b4992"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87e463a1-7360-42dd-a91a-c55cf7f67c82"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Anywhere
        m_Anywhere = asset.FindActionMap("Anywhere", throwIfNotFound: true);
        m_Anywhere_Aim = m_Anywhere.FindAction("Aim", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Anywhere
    private readonly InputActionMap m_Anywhere;
    private List<IAnywhereActions> m_AnywhereActionsCallbackInterfaces = new List<IAnywhereActions>();
    private readonly InputAction m_Anywhere_Aim;
    public struct AnywhereActions
    {
        private @NewControls m_Wrapper;
        public AnywhereActions(@NewControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Aim => m_Wrapper.m_Anywhere_Aim;
        public InputActionMap Get() { return m_Wrapper.m_Anywhere; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AnywhereActions set) { return set.Get(); }
        public void AddCallbacks(IAnywhereActions instance)
        {
            if (instance == null || m_Wrapper.m_AnywhereActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_AnywhereActionsCallbackInterfaces.Add(instance);
            @Aim.started += instance.OnAim;
            @Aim.performed += instance.OnAim;
            @Aim.canceled += instance.OnAim;
        }

        private void UnregisterCallbacks(IAnywhereActions instance)
        {
            @Aim.started -= instance.OnAim;
            @Aim.performed -= instance.OnAim;
            @Aim.canceled -= instance.OnAim;
        }

        public void RemoveCallbacks(IAnywhereActions instance)
        {
            if (m_Wrapper.m_AnywhereActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAnywhereActions instance)
        {
            foreach (var item in m_Wrapper.m_AnywhereActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_AnywhereActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public AnywhereActions @Anywhere => new AnywhereActions(this);
    public interface IAnywhereActions
    {
        void OnAim(InputAction.CallbackContext context);
    }
}
