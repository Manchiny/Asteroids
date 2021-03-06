//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/Assets.Scripts/Input/SpaceshipController.inputactions
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

namespace Assets.Scripts
{
    public partial class @SpaceshipInput : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @SpaceshipInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""SpaceshipController"",
    ""maps"": [
        {
            ""name"": ""Spaceship"",
            ""id"": ""6e17e28a-d227-4914-b436-a09f3d075cda"",
            ""actions"": [
                {
                    ""name"": ""Rotation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""795437a1-4f64-4ecf-b5fd-7a3c752866a0"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""5ceb811c-f1a0-40fc-bfb4-9fb042137973"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""246ca6cc-c073-4e18-933d-7e3855d118f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""f9aab831-53ed-4705-82a4-974df057b610"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""a3c8cc3a-a7db-498d-81fd-cfaa4219136c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6de510ed-0159-4eb1-b27d-fcba73363da0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""013c8839-2277-46c5-b4ce-86ab0985eb13"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""5b00d83e-d038-4c7f-b346-069a139d4d04"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7dce0434-5607-48ae-b718-0863b3be3411"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bdf61524-5d51-45bd-83e2-700fcfa339bb"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a34f2470-aba1-4789-ac5e-a33a6339b865"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""559e5bce-1753-4feb-b494-ac942aaea38b"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b6f1989-ba8b-4bf5-b0fa-4256be430643"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55b89ebf-b6d1-43b7-ab17-de94c9def87b"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""SwitchWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c400c1f-cb0f-4e9d-945c-e1095b10527e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""999f3e4b-286c-4a73-90c5-0bd752bc9d35"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse and Keyboard"",
            ""bindingGroup"": ""Mouse and Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Spaceship
            m_Spaceship = asset.FindActionMap("Spaceship", throwIfNotFound: true);
            m_Spaceship_Rotation = m_Spaceship.FindAction("Rotation", throwIfNotFound: true);
            m_Spaceship_Accelerate = m_Spaceship.FindAction("Accelerate", throwIfNotFound: true);
            m_Spaceship_SwitchWeapon = m_Spaceship.FindAction("SwitchWeapon", throwIfNotFound: true);
            m_Spaceship_Shoot = m_Spaceship.FindAction("Shoot", throwIfNotFound: true);
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

        // Spaceship
        private readonly InputActionMap m_Spaceship;
        private ISpaceshipActions m_SpaceshipActionsCallbackInterface;
        private readonly InputAction m_Spaceship_Rotation;
        private readonly InputAction m_Spaceship_Accelerate;
        private readonly InputAction m_Spaceship_SwitchWeapon;
        private readonly InputAction m_Spaceship_Shoot;
        public struct SpaceshipActions
        {
            private @SpaceshipInput m_Wrapper;
            public SpaceshipActions(@SpaceshipInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Rotation => m_Wrapper.m_Spaceship_Rotation;
            public InputAction @Accelerate => m_Wrapper.m_Spaceship_Accelerate;
            public InputAction @SwitchWeapon => m_Wrapper.m_Spaceship_SwitchWeapon;
            public InputAction @Shoot => m_Wrapper.m_Spaceship_Shoot;
            public InputActionMap Get() { return m_Wrapper.m_Spaceship; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(SpaceshipActions set) { return set.Get(); }
            public void SetCallbacks(ISpaceshipActions instance)
            {
                if (m_Wrapper.m_SpaceshipActionsCallbackInterface != null)
                {
                    @Rotation.started -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnRotation;
                    @Rotation.performed -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnRotation;
                    @Rotation.canceled -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnRotation;
                    @Accelerate.started -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnAccelerate;
                    @Accelerate.performed -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnAccelerate;
                    @Accelerate.canceled -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnAccelerate;
                    @SwitchWeapon.started -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnSwitchWeapon;
                    @SwitchWeapon.performed -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnSwitchWeapon;
                    @SwitchWeapon.canceled -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnSwitchWeapon;
                    @Shoot.started -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnShoot;
                    @Shoot.performed -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnShoot;
                    @Shoot.canceled -= m_Wrapper.m_SpaceshipActionsCallbackInterface.OnShoot;
                }
                m_Wrapper.m_SpaceshipActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Rotation.started += instance.OnRotation;
                    @Rotation.performed += instance.OnRotation;
                    @Rotation.canceled += instance.OnRotation;
                    @Accelerate.started += instance.OnAccelerate;
                    @Accelerate.performed += instance.OnAccelerate;
                    @Accelerate.canceled += instance.OnAccelerate;
                    @SwitchWeapon.started += instance.OnSwitchWeapon;
                    @SwitchWeapon.performed += instance.OnSwitchWeapon;
                    @SwitchWeapon.canceled += instance.OnSwitchWeapon;
                    @Shoot.started += instance.OnShoot;
                    @Shoot.performed += instance.OnShoot;
                    @Shoot.canceled += instance.OnShoot;
                }
            }
        }
        public SpaceshipActions @Spaceship => new SpaceshipActions(this);
        private int m_MouseandKeyboardSchemeIndex = -1;
        public InputControlScheme MouseandKeyboardScheme
        {
            get
            {
                if (m_MouseandKeyboardSchemeIndex == -1) m_MouseandKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse and Keyboard");
                return asset.controlSchemes[m_MouseandKeyboardSchemeIndex];
            }
        }
        public interface ISpaceshipActions
        {
            void OnRotation(InputAction.CallbackContext context);
            void OnAccelerate(InputAction.CallbackContext context);
            void OnSwitchWeapon(InputAction.CallbackContext context);
            void OnShoot(InputAction.CallbackContext context);
        }
    }
}
