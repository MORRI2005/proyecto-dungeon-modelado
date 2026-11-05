using Gameplay.Systems;
using Unity.VisualScripting;
using UnityEngine;

public class SimpleDamageEffect : MonoBehaviour
{
    private Animator _animator;

    private Damageable damageable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        if (_animator == null)
        {
            Debug.Log("animator esta mal");
        }

        damageable = GetComponent<Damageable>();
        if (damageable == null)
        {
            Debug.Log("el damageable esta vacio");
        }
        damageable.OnDamageTaken += ActivateAnimation;
        damageable.OnDeath += DeathAnimation;
    }

    public void ActivateAnimation(float damage)
    {
        _animator.SetTrigger("attack");
        Debug.Log("[" + damage + "]");
    }

    public void DeathAnimation()
    {
        damageable.gameObject.SetActive(false);
    }
}
