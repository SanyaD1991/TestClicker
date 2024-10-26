using UnityEngine;

[CreateAssetMenu(fileName = "CurrencyData", menuName = "ScriptableObjects/CurrencyData")]
public class CurrencyData : ScriptableObject
{
    [SerializeField] private float baseCurrencyPerTap = 1;
    [SerializeField] private float tapModifier = 1;               // ����������� ����   
    [SerializeField] private float divisor = 1;                   // �������� ��� �������
    [SerializeField] private float currencyPerAutoCollect = 5;    // ���������� ������ �� ��������
    [SerializeField] private float autoCollectInterval = 1f;      // �������� ��������� � ��������
    [SerializeField] private float energy = 100;                  // ��������� ���������� �������
    [SerializeField] private float energyCostPerTap = 1;          // ������� ������� ��������� �� ���� ���

    public float GetBaseCurrencyPerTap => baseCurrencyPerTap;
    public float GetTapModifier => tapModifier;   
    public float GetOtherModifier => currencyPerAutoCollect * divisor;
    public float GetCurrencyPerAutoCollect => currencyPerAutoCollect;
    public float GetAutoCollectInterval => autoCollectInterval;
    public float GetEnergy => energy;
    public float GetEnergyCostPerTap => energyCostPerTap;
}
