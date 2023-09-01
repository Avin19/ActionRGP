using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject deadUi , winUI;

    private void Awake() {
        deadUi.SetActive(false);
        winUI.SetActive(false);
    }
}
