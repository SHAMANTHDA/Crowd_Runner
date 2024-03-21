using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShopManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Button purchaseButton;
    [SerializeField] private SkinButton[] skinButtons;

    [Header("Skins")]
    [SerializeField] private Sprite[] skins;

    [Header("Pricing")]
    [SerializeField] private int skinPrice;
    [SerializeField] private Text priceText;

    [Header("Events")]
    public static Action<int> onSkinSelected;
    private void Awake()
    {
        UnlockSkin(0);
        priceText.text = skinPrice.ToString();
    }
    IEnumerator Start()
    {
        ConfigureButtons();
        UpdatePurchaseButton();

        yield return null;

        SelectSkin(GetLastSelectedSkin());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnlockSkin(UnityEngine.Random.Range(0, skinButtons.Length));
        }
    }
    private void ConfigureButtons()
    {
        for (int i = 0; i < skinButtons.Length; i++)
        {
            bool unLocked = PlayerPrefs.GetInt("skinButton" + i) == 1;

            skinButtons[i].Configure(skins[i], unLocked);

            int skinIndex = i;

            skinButtons[i].GetButton().onClick.AddListener(() => SelectSkin(skinIndex));
        }
    }

    public void UnlockSkin(int skinIndex)
    {
        PlayerPrefs.SetInt("skinButton" + skinIndex, 1);
        skinButtons[skinIndex].Unlock();
    }

    public void UnlockSkin(SkinButton skinButton)
    {
        int skinIndex = skinButton.transform.GetSiblingIndex();
        UnlockSkin(skinIndex);
    }
    public void SelectSkin(int skinIndex)
    {
        //Debug.Log("Skin " + skinIndex + " has been selected");

        for (int i = 0; i < skinButtons.Length; i++)
        {
            if (skinIndex == i)
            {
                skinButtons[i].Select();
            }
            else
            {
                skinButtons[i].DeSelect();
            }
        }

        onSkinSelected?.Invoke(skinIndex);

        SaveLastSelectedSkinIndex(skinIndex);
    }

    public void PurchaseSkin()
    {
        List<SkinButton> skinButtonsList = new List<SkinButton>();

        for (int i = 0; i < skinButtons.Length; i++)
        {
            if (!skinButtons[i].IsUnlocked())
            {
                skinButtonsList.Add(skinButtons[i]);
            }
        }
        if (skinButtonsList.Count <= 0)
        {
            return;
        }

        SkinButton randomSkinButton = skinButtonsList[UnityEngine.Random.Range(0, skinButtonsList.Count)];

        UnlockSkin(randomSkinButton);
        SelectSkin(randomSkinButton.transform.GetSiblingIndex());

        DataManager.instance.UseCoins(skinPrice);

        UpdatePurchaseButton();
    }

    public void UpdatePurchaseButton()
    {
        if (DataManager.instance.GetCoins() < skinPrice)
        {
            purchaseButton.interactable = false;
        }
        else
        {
            purchaseButton.interactable = true;
        }
    }

    private int GetLastSelectedSkin()
    {
        return PlayerPrefs.GetInt("lastSelctedSkin", 0);
    }

    private void SaveLastSelectedSkinIndex(int skinIndex)
    {
        PlayerPrefs.SetInt("lastSelctedSkin", skinIndex);
    }
}
