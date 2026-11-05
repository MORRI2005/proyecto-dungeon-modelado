using System;
using System.Collections.Generic;
using UnityEngine;

public class PlatePuzzle : ActivatorBase
{

    public Material ogMaterial;

    public Material newMaterial;
    public List<PressurePlateController> _goodPlates;
    public List<PressurePlateController> _badPlates;

    public List<TrapLogic> _trapObjects;

    public PressurePlateController _activatorPlate;

    private AudioSource _audioSource;

    public AudioSource _plateSound;

    public AudioSource _spikeSound;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        foreach (var goodState in _goodPlates)
        {
            // goodState.activator.ToActivate.AddListener(ActivatorUpdated);
            goodState.ToActivate.AddListener(GoodPlateUpdate);
        }
        foreach (var badState in _badPlates)
        {
            badState.ToActivate.AddListener(BadPlateUpdate);
        }

        _activatorPlate.ToActivate.AddListener(ActivatorPlateUpdate);
    }

    private void GoodPlateUpdate(ActivatorBase.ActivatorInfo info)
    {
        _plateSound.Play();
        if (CheckIfPuzzleHasBeenSolved())
        {
            Debug.Log("Puzzle Solved!");
            _audioSource.Play();
            ActivateObjects(true);
        }
        else
        {
            Debug.Log("Puzzle not solved");
            ActivateObjects(false);
        }

    }

    private void ActivatorPlateUpdate(ActivatorBase.ActivatorInfo info)
    {
        foreach (var plate in _goodPlates)
        {
            Renderer plateRenderer = plate.GetComponentInChildren<Renderer>();
            if (info.Activator.IsActivated)
            {
                plateRenderer.material = newMaterial;
            }
            else
            {
                plateRenderer.material = ogMaterial;
            }
        }

    }

    private void BadPlateUpdate(ActivatorBase.ActivatorInfo info)
    {
        if (info.Activator.IsActivated)
        {
            _spikeSound.Play();
            Debug.Log("Placa Equivocada Activada");
            ActivateObjects(false);

            foreach (var plate in _goodPlates)
            {
                plate.UnpressPlates();
            }


            for (int i = 0; i < _badPlates.Count; i++)
            {
                if (info.Activator.name == _badPlates[i].name)
                {
                    _trapObjects[i].ActivateTrap();
                }

            }

        }

    }

    private bool CheckIfPuzzleHasBeenSolved()
    {
        foreach (var goodState in _goodPlates)
        {
            if (!goodState.IsActivated)
            {
                return false;
            }
        }
        return true;
    }

}
