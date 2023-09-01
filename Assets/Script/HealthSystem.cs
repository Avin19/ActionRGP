using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    private int health;
    [SerializeField]private int maxHealth;

    public event EventHandler OnDead;
    public event EventHandler OnHeal;
    public event EventHandler OnHurt;
   private void Start() {
    health = maxHealth;
   }
    private void Update()
    {
        if(health<= 0)
        {

            OnDead?.Invoke(this,EventArgs.Empty);
            gameObject.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            Damage(3);
        }
    }
    public void Damage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health,0,maxHealth);
        OnHurt?.Invoke(this,EventArgs.Empty);
    }
    public void Heal(int heal)
    {
        health+=heal;
        health = Mathf.Clamp(health,0,maxHealth);
        OnHeal?.Invoke(this,EventArgs.Empty);
    }
    public int GetHealth()
    {
        return health;  
    }
    public int GetMaxHealth()
    {
        return maxHealth;
    }

}
