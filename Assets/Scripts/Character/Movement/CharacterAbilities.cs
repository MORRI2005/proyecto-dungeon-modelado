using System;
using System.Runtime.Serialization;
using Gameplay.Systems;
using NUnit.Framework.Internal.Execution;
using UnityEngine;
using UnityEngine.Events;

public class CharacterAbilities : MonoBehaviour
{

    public UnityAction OnAttackTriggered;
    private Damageable _damageable;

    public float swordDamage = 1f;

    [SerializeField] private Collider _basicAttackCollider;

    public void Awake()
    {
        _damageable = GetComponent<Damageable>();
    }
    public void TriggerAttack()
    {
        Debug.Log("Character is attacking. dead?" + _damageable.IsDead);
        if (_damageable.IsDead)
            return;

        OnAttackTriggered?.Invoke();
        Debug.Log("Attack triggered");
    }


    // Esto lo llama el animator desde un evento de animación, para que el personaje pueda dañar a los enemigos en el momento adecuado de la animación.
    public void HurtDamageables()
    {
        // miro que hay dmgs hay dentro del trigger
        // hago daño al que toque
        var damageablesFound = Physics.OverlapBox(_basicAttackCollider.bounds.center, _basicAttackCollider.bounds.extents, _basicAttackCollider.transform.rotation);
        Debug.Log("HurtDamageables");

        foreach (var dmg in damageablesFound)
        {
            var damageable = dmg.GetComponent<Damageable>();

            if (damageable != null)
            {
                damageable.TakeDamage(swordDamage);
            }
        }
    }
}
