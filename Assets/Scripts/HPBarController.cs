using System;
using Gameplay.Systems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour
{

    public Damageable _damageable;

    [SerializeField] private TMP_Text healthText;

    [SerializeField] private Image healthBar;

    private String currentHitpoints;

    void Start()
    {
        healthText.text = _damageable.MaxHitpoints.ToString();
        healthBar.fillAmount = _damageable.MaxHitpoints / _damageable.MaxHitpoints;
    }

    void Awake()
    {
        _damageable.OnDamageTaken += UpdateBar;
    }

    private void UpdateBar(float damage)
    {
        healthBar.fillAmount = _damageable.CurrentHitpoints / _damageable.MaxHitpoints;
        healthText.text = _damageable.CurrentHitpoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

}
