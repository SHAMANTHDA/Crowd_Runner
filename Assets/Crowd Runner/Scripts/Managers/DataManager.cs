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
        UpdateCoinsText();
    }

    private void UpdateCoinsText()
    {
        foreach (Text coinText in coinsText)
        {
            coinText.text = coins.ToString();
        }
    }

    public void AddCoins(int Amount)
    {
        coins += Amount;

        UpdateCoinsText();

        PlayerPrefs.SetInt("coins", coins);
    }

}
