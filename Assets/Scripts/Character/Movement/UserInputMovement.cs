using UnityEngine;
using UnityEngine.InputSystem;
using Gameplay.Interactions;

namespace Gameplay.Character
{
    public class UserInputMovement : MonoBehaviour
    {
        private CharacterMovement _characterMovement;

        private CharacterAbilities _characterAbilities;

        private CharacterInteractor _characterInteractor;
        void Awake()
        {
            _characterMovement = GetComponent<CharacterMovement>();
            _characterAbilities = GetComponent<CharacterAbilities>();
            _characterInteractor = GetComponent<CharacterInteractor>();

            if (_characterMovement == null)
            {
                Debug.LogError("[UserInputMovement] CharacterMovement is null! Add a CharacterMovement component to the GameObject.");
            }
            if (_characterAbilities == null)
            {
                Debug.LogError("[UserInputMovement] CharacterAbilities is null! Add a CharacterAbilities component to the GameObject.");
            }
        }
        void Update()
        {
            Vector2 inputMovementVector = InputSystem.actions["Move"].ReadValue<Vector2>();
            _characterMovement.Move(inputMovementVector);

            Vector3 lookVector = new Vector3(inputMovementVector.x, 0, inputMovementVector.y);

            if (lookVector.magnitude > 0.1f)
                _characterMovement.LookAt(lookVector + transform.position);

            if (InputSystem.actions["Jump"].WasPressedThisFrame())
            {
                _characterMovement.TriggerJump();
            }

            if (InputSystem.actions["Jump"].WasReleasedThisFrame())
            {
                _characterMovement.CancelJump();
            }
            if (InputSystem.actions["Attack"].WasReleasedThisFrame())
            {
                _characterAbilities.TriggerAttack();
            }
            if (InputSystem.actions["Interact"].WasPressedThisFrame())
            {
                _characterInteractor.TriggerInteraction();
            }
        }
    }
}