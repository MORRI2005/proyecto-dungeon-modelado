using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ActivatorBase : MonoBehaviour
{
    public class ActivatorInfo
    {
        public ActivatorBase Activator;

    }


    //The bool will be true when the activator gets activated, and false when it gets deactivated.
    [HideInInspector] public UnityEvent<ActivatorInfo> ToActivate;

    public List<GameObject> ObjectsToActivate = new List<GameObject>();
    public bool IsActivated => _isActivated;
    protected bool _isActivated = false;

    void OnDrawGizmosSelected()
    {
        // Vemos con que esta activado la placa
        Gizmos.color = Color.yellow;
        foreach (var obj in ObjectsToActivate)
        {
            if (obj != null)
                Gizmos.DrawLine(transform.position, obj.transform.position);
        }
    }

    protected void ActivateObjects(bool activate)
    {
        _isActivated = activate;
        ActivatorInfo info = new ActivatorInfo { Activator = this };
        ToActivate?.Invoke(info);
        foreach (var obj in ObjectsToActivate)
        {
            // Activamos cada objeto dentro de la lista y de paso comprobamos si se puede activar
            IActivable activable = obj.GetComponent<IActivable>();
            if (activable != null)
            {
                activable.Activate(activate);
            }
        }
    }

}