using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    [Header("Elements")]
    [SerializeField] private Text[] coinsText;
    private int coins;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        coins = PlayerPrefs.GetInt("coins", 0);
    }

    private void Start()
    {
        AddCoins(5);
        UpdateCoinsText();
    }

    private void UpdateCoinsText()
    {
        foreach (Text coinText in coinsText)
        {
            coinText.text = coins.ToString();
        }
    }

    public void AddCoins(int amount)
    {
        coins += amount;

        UpdateCoinsText();

        PlayerPrefs.SetInt("coins", coins);
    }
    internal void UseCoins(int amount)
    {
        coins -= amount;

        UpdateCoinsText();

        PlayerPrefs.SetInt("coins", coins);
    }
    public int GetCoins()
    {
        return coins;
    }
}
