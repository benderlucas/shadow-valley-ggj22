using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    public int actualMoney;
    public GameObject MoneyText;

    void Start()
    {
        actualMoney = 0;
    }

    void Update()
    {
        MoneyText.GetComponent<TMPro.TextMeshProUGUI>().text = actualMoney.ToString();
    }
}
