using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Morale : MonoBehaviour
{
    public int HitPoints;
    int MaxHP;

    public UnityEvent OnDeath;
    public float HealthPercent
    {
        get
        {
            return (float)HitPoints / (float)MaxHP;
        }
    }
    public bool IsDead
    {
        get
        {
            return HitPoints <= 0;
        }
    }
    public UnityEvent<int> OnHealthUpdated;

    // Start is called before the first frame update
    void Start()
    {
        MaxHP = HitPoints;
    }

    /// <summary>
    /// Applies a provided damage amount to the health of the creature and invokes death events if this unit dies
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
    {
        if (IsDead)
        {
            return;
        }
        if (HitPoints - damage <= 0)
        {
            HitPoints = 0;
            OnHealthUpdated.Invoke(HitPoints);
            ProcessDeath();
            return;
        }

        HitPoints -= damage;
        OnHealthUpdated.Invoke(HitPoints);

    }

    public void ProcessDeath()
    {
        gameObject.SendMessage("Die");
        OnDeath.Invoke();
    }
}
