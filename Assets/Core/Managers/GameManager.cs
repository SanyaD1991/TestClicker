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
    [SerializeField] private TextMeshProUGUI currencyDisplay;   // ����� ��� ����������� ������
    [SerializeField] private TextMeshProUGUI energyDisplay;     // ����� ��� ����������� �������
    [SerializeField] private TextMeshProUGUI energyMaxDisplay;     // ����� ��� ����������� ������������ �������
    [SerializeField] private Button clickButton;                // ������ ��� �������
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
        clickButton.onClick.AddListener(OnClick);               // ��������� ����� ����� �� ������       
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
            Debug.Log("�� ������� ������� ��� �����!");           
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

