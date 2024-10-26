using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCollection : MonoBehaviour
{
    [SerializeField] private CurrencyData currencyData;
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.AddTotalBonus(GetAutoCollectBonus());
        StartCoroutine(AutoCollectCoroutine());
    }
    public float GetAutoCollectBonus()
    {
        return (currencyData.GetCurrencyPerAutoCollect * 0.1f); // 10% מע אגעמסבמנא
    }

    private IEnumerator AutoCollectCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(currencyData.GetAutoCollectInterval);           
            gameManager.AddCurrentCurrency(currencyData.GetCurrencyPerAutoCollect);
            gameManager.OnUpdateCurrencyDisplay?.Invoke();
        }
    }
}
