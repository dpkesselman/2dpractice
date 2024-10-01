using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] private float HPAmount;
    [SerializeField] private float MaxHP;
    [SerializeField] private HPBar hpbar;

    private void Start()
    {
        HPAmount = MaxHP;
        HPBar.Instance.InitializeHPBar(HPAmount);
    }

    public void TakeDamage(int damage)
    {
        HPAmount -= damage;
        HPBar.Instance.ChangeCurrentHP(HPAmount);
    }
}
