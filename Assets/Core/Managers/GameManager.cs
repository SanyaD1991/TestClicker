using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.Events;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CurrencyData currencyData;
    [SerializeField] private TextMeshProUGUI currencyDisplay;   // текст для отображения валюты
    [SerializeField] private TextMeshProUGUI energyDisplay;     // текст для отображения энергии
    [SerializeField] private TextMeshProUGUI energyMaxDisplay;     // текст для отображения максимальной энергии
    [SerializeField] private Button clickButton;                // Кнопка для кликера
    [SerializeField] private Amount eventClick;

    private Action OnCurrencyDisplay;
    private AutoCollection autoCollection;
    private float energy;
    private float currentCurrency = 0;
    float totalBonus = 0;

    public Action OnUpdateCurrencyDisplay => OnCurrencyDisplay;   

    private void Awake()
    {
        OnCurrencyDisplay += UpdateCurrencyDisplay;
        InitEnergy();
        clickButton.onClick.AddListener(OnClick);               // Назначаем метод клика на кнопку       
    }

    public void AddCurrentCurrency(float volue)
    {
        currentCurrency += volue;
    }
    public void AddTotalBonus(float volue)
    {
        totalBonus = volue;
    }

    private void OnClick()
    {      
        if (energy >= currencyData.GetEnergyCostPerTap)
        {
            energy -= currencyData.GetEnergyCostPerTap;
          
            float tapAmount = (currencyData.GetBaseCurrencyPerTap + currencyData.GetTapModifier + currencyData.GetOtherModifier) + totalBonus;
            currentCurrency += tapAmount;

            UpdateCurrencyDisplay();           
            UpdateEnergyDisplay();
            eventClick?.Invoke(tapAmount);         
        }
        else
        {
            eventClick?.Invoke(0);
            Debug.Log("Не хватает энергии для клика!");           
        }
    }

    private void UpdateCurrencyDisplay()
    {
        currencyDisplay.text = currentCurrency.ToString("F2");
    }

    private void UpdateEnergyDisplay()
    {
        energyDisplay.text = energy.ToString();
    }

    private void InitEnergy()
    {
        energyMaxDisplay.text = currencyData.GetEnergy.ToString();
        energy = currencyData.GetEnergy;
        UpdateEnergyDisplay();                                 
    }



    [Serializable]
    public class Amount : UnityEvent<float>
    {

    }
}

