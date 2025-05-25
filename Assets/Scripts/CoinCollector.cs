using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int coins = 0; // monedas que tiene el jugador

    public CoinUI coinUI; // referencia al script que maneja la UI

    private void Start()
    {
        UpdateUI();
    }

    // Llamar cuando el jugador recoja una moneda
    public void AddCoin(int amount = 1)
    {
        coins += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (coinUI != null)
        {
            coinUI.UpdateCoinText(coins);
        }
    }
}
