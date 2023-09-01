using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
   [SerializeField] private Slider healthSilder;

   [SerializeField] private HealthSystem playerHealthSystem;


   private void Awake() {
    playerHealthSystem.OnDead += Player_OnDead;
   }
   private void Start() {
    healthSilder.maxValue = playerHealthSystem.GetMaxHealth();
   }
   private void Update() {
    healthSilder.value= playerHealthSystem.GetHealth();
   }

    private void Player_OnDead(object sender, EventArgs e)
    {
        healthSilder.value = 0;
    }
}
