using Gameplay.Character;
using UnityEngine;
using UnityEngine.AI;

public class AIBrain : MonoBehaviour
{

    //Idle, Wonder y Attack, son los estados que tiene el enemigo, y se van a ir cambiando dependiendo de la distancia del player y de si el player esta dentro del rango de ataque o no.
    private CharacterMovement _characterMovement;
    private CharacterAbilities _characterAbilities;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _characterMovement = GetComponent<CharacterMovement>();
        if (_characterMovement == null)
        {
            Debug.LogError("[AIBrain] CharacterMovement is null! Add a CharacterMovement component to the GameObject.");
        }
        _characterAbilities = GetComponent<CharacterAbilities>();
        if (_characterAbilities == null)
        {
            Debug.LogError("[AIBrain] CharacterAbilities is null! Add a CharacterAbilities component to the GameObject.");
        }
        path = new NavMeshPath();
    }

    enum AIState
    {
        Idle,
        Patrol,
        Chase
    }

    private AIState _currentState = AIState.Patrol;
    private NavMeshPath path;
    public Transform target;

    void Update()
    {
        switch (_currentState)
        {
            case AIState.Idle:
                // Lógica para el estado Idle
                // Ni siquiero se mueve
                _characterMovement.Move(Vector3.zero);
                break;
            case AIState.Patrol:
                // Lógica para el estado Patrol
                // Busca un punto aleatorio y se mueve hacia él
                NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);

                Vector3 directiontoNextCorner = (path.corners[1] - path.corners[0]);
                Vector2 simulatedInput = new Vector2(directiontoNextCorner.x, directiontoNextCorner.z).normalized;

                Vector3 lookVector = new Vector3(simulatedInput.x, 0, simulatedInput.y);

                if (directiontoNextCorner.magnitude > 1f)
                {
                    _characterMovement.Move(simulatedInput);
                    _characterMovement.LookAt(lookVector + transform.position);
                }
                else
                {
                    _characterMovement.Move(Vector2.zero);
                }

                break;
            case AIState.Chase:
                // Lógica para el estado Chase
                // Se mueve hacia el player
                break;
        }
    }
}
