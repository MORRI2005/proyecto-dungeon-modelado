using Gameplay.Systems;
using UnityEngine;

public class TrapLogic : ActivatorBase
{
    private Animator _animator;
    private bool canDamage = false;
    public float _amountDamage = 10f;

    private int i = 0;

    // Durante animacion Idle que este descativado collider, quitar bool canDamage
    // Mirar Damageable para la logica de iframes
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ActivateTrap()
    {
        _animator.SetTrigger("Activate");
        canDamage = true;
    }


    void OnTriggerEnter(Collider other)
    {
        if (canDamage)
        {
            Debug.Log("Te mató!" + i);
            Damageable damageable = other.GetComponent<Damageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(_amountDamage);
            }
            canDamage = false;
            i = i + 1;
        }

    }
}
