using System.Collections.Generic;
using UnityEngine;

public class PuzzleLogic : ActivatorBase
{
    // Se tienen que pillar las palancas
    // public ActivatorBase lever1;
    // public ActivatorBase lever2;
    // public ActivatorBase lever3;

    [System.Serializable]
    public class ActivatorPuzzleState
    {
        public ActivatorBase activator;
        public bool correctState = false;
    }


    public List<ActivatorPuzzleState> activators;

    void Start()
    {
        foreach (var activatorState in activators)
        {
            activatorState.activator.ToActivate.AddListener(ActivatorUpdated);
        }
    }

    private void ActivatorUpdated(ActivatorBase.ActivatorInfo info)
    {
        if (CheckIfPuzzleHasBeenSolved())
        {
            Debug.Log("Puzzle Solved!");
            ActivateObjects(true);
        }
        else
        {
            Debug.Log("Puzzle not solved");
            ActivateObjects(false);
        }

    }

    private bool CheckIfPuzzleHasBeenSolved()
    {
        foreach (var activatorState in activators)
        {
            if (activatorState.activator.IsActivated != activatorState.correctState)
            {
                return false;
            }
        }
        return true;
    }

}
