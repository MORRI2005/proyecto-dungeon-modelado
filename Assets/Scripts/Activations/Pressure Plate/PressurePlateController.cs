using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class PressurePlateController : ActivatorBase
{
    // Numero de objetos que hay encima de la placa
    private int _objectsOnPlate = 0;
    public bool staysPresssed = false;

    //Cuando entra se activa y comprobamos si tiene el pressure plate activator, ahora mismo solo lo tiene el personaje
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PressurePlateActivator activator))
        {
            if (_objectsOnPlate == 0)
            {
                _isActivated = true;
                ActivateObjects(_isActivated);
            }
            _objectsOnPlate++;
        }
    }

    // Caundo sale se activa
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PressurePlateActivator activator))
        {
            _objectsOnPlate--;
            if (_objectsOnPlate == 0)
            {
                if (!staysPresssed)
                {
                    _isActivated = false;
                    ActivateObjects(_isActivated);
                }
            }
        }
    }

    // Funcion para hacer que se mantengan presionados
    public void UnpressPlates()
    {
        if (_objectsOnPlate == 0 && _isActivated)
        {
            _isActivated = false;
            ActivateObjects(_isActivated);
        }
    }
}
