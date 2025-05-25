using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinUI : MonoBehaviour
{
    public TextMeshProUGUI coinText; // referencia al Text de la UI

    public void UpdateCoinText(int amount)
    {
        coinText.text = amount.ToString();
    }
}
