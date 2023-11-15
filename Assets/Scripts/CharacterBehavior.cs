using CodeMonkey.HealthSystemCM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterBehavior : MonoBehaviour, IGetHealthSystem
{
    [SerializeField]
    CharacterUnity character;

    public UnityEvent<GameObject> Dead;
    public UnityEvent<GameObject, int> HealthChanged;

    HealthSystem _healthSystem;
    void Awake()
    {
        _healthSystem = new HealthSystem(character.MaxZdravi);

        character.ZdraviZmeneno += Character_ZdraviZmeneno;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public HealthSystem GetHealthSystem()
    {
        return _healthSystem;
    }

    public void Attack(CharacterBehavior enemy)
    {
        if (enemy.character.JeZiva())
        {
            character.Utok(enemy.character);
            enemy._healthSystem.SetHealth(enemy.character.Zdravi);
        }
    }
    private void Character_ZdraviZmeneno(int oldHealth, int newHealth)
    {
        HealthChanged?.Invoke(this.gameObject, newHealth - oldHealth);

        if(character.JeZiva() == false)
        {
            Dead?.Invoke(this.gameObject);
        }
    }
}
