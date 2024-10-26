using UnityEngine;

[CreateAssetMenu(fileName = "CurrencyData", menuName = "ScriptableObjects/CurrencyData")]
public class CurrencyData : ScriptableObject
{
    [SerializeField] private float baseCurrencyPerTap = 1;
    [SerializeField] private float tapModifier = 1;               // модификатор тапа   
    [SerializeField] private float divisor = 1;                   // делитель для расчета
    [SerializeField] private float currencyPerAutoCollect = 5;    // количество валюты за автосбор
    [SerializeField] private float autoCollectInterval = 1f;      // интервал автосбора в секундах
    [SerializeField] private float energy = 100;                  // Начальное количество энергии
    [SerializeField] private float energyCostPerTap = 1;          // Сколько энергии списывать за один тап

    public float GetBaseCurrencyPerTap => baseCurrencyPerTap;
    public float GetTapModifier => tapModifier;   
    public float GetOtherModifier => currencyPerAutoCollect * divisor;
    public float GetCurrencyPerAutoCollect => currencyPerAutoCollect;
    public float GetAutoCollectInterval => autoCollectInterval;
    public float GetEnergy => energy;
    public float GetEnergyCostPerTap => energyCostPerTap;
}
