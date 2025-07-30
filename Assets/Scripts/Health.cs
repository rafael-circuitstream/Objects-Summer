using UnityEngine;
using System;

public class Health
{
    public Action OnHealthZero;
    public Action<int> OnHealthChange;

    private int value;

    public int GetHealth()
    {
        return value;
    }

    public bool IsHealthLow()
    {
        if(value < 10)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void DisplayHealth()
    {
        Debug.Log(value);
    }

    public void Damage(int toDamage)
    {
        value -= toDamage;

        OnHealthChange?.Invoke(value);

        if(value <= 0)
        {
            OnHealthZero?.Invoke();
        }

        DisplayHealth();
    }

    public void Heal(int toHeal)
    {
        value += toHeal;

        OnHealthChange?.Invoke(value);
    }

    public Health(int initialHealth)
    {
        value = initialHealth;
    }
}
