using Gameplay.Character;
using UnityEngine;
using UnityEngine.AI;

public class AIBrain : MonoBehaviour
{

    //Idle, Wonder y Attack, son los estados que tiene el enemigo, y se van a ir cambiando dependiendo de la distancia del player y de si el player esta dentro del rango de ataque o no.
    private CharacterMovement _characterMovement;
    private CharacterAbilities _characterAbilities;

    private float timeInState = 0f;

    private Vector3 initialPosition;

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
        initialPosition = transform.position;
    }

    enum AIState
    {
        Idle,
        Patrol,
        Chase
    }

    private AIState _currentState = AIState.Idle;
    private NavMeshPath path;
    public Transform target;

    void Update()
    {
        timeInState += Time.deltaTime;

        float distanceToTarget = Vector3.Distance(target.position, initialPosition);
        Debug.Log($"Distance to target: {distanceToTarget}");

        switch (_currentState)
        {
            case AIState.Idle:
                _characterMovement.Move(initialPosition);
                if (distanceToTarget < 2f)
                {
                    ChangeState(AIState.Chase);
                }
                break;
            case AIState.Patrol:

                break;
            case AIState.Chase:
                MoveTo(target.position);
                if (distanceToTarget > 2f)
                {
                    ChangeState(AIState.Idle);
                }
                break;
        }
    }

    private void ChangeState(AIState newState)
    {
        switch (_currentState)
        {
            case AIState.Idle:
                // Lógica para entrar en el estado Idle
                break;
            case AIState.Patrol:
                // Lógica para entrar en el estado Patrol
                break;
            case AIState.Chase:
                // Lógica para entrar en el estado Chase
                break;
        }
        _currentState = newState;
        timeInState = 0f;


        switch (_currentState)
        {
            case AIState.Idle:
                // Lógica para salir del estado Idle
                break;
            case AIState.Patrol:
                // Lógica para salir del estado Patrol
                break;
            case AIState.Chase:
                // Lógica para salir del estado Chase
                break;
        }
    }

    private void MoveTo(Vector3 targetPosition)
    {
        CalculatePath(targetPosition);

        if (path.corners.Length < 2)
        {
            _characterMovement.Move(Vector2.zero);
            return;
        }

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
    }
    private void CalculatePath(Vector3 targetPosition)
    {
        NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);

        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
        }
    }
}
