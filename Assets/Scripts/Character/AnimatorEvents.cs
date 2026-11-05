using UnityEngine;

public class AnimatorEvents : MonoBehaviour
{
    private CharacterAbilities _characterAbilities;

    private void Awake()
    {
        _characterAbilities = GetComponentInParent<CharacterAbilities>();
        if (_characterAbilities == null)
        {
            Debug.LogError("[AnimatorEvents] CharacterAbilities is null! Add a CharacterAbilities component to the GameObject.");
        }
    }
    public void AttackEvent()
    {
        _characterAbilities.HurtDamageables();
    }
}
