using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private SkinButton[] skinButtons;

    [Header("Skins")]
    [SerializeField] private Sprite[] skins;
    private void Start()
    {
        ConfigureButtons();
    }
    private void ConfigureButtons()
    {
        for (int i = 0; i < skinButtons.Length; i++)
        {
            skinButtons[i].Configure(skins[i], true);

            int skinIndex = i;

            skinButtons[i].GetButton().onClick.AddListener(() => SelectSkin(skinIndex));
        }
    }

    private void SelectSkin(int skinIndex)
    {
        Debug.Log("Skin " + skinIndex + " has been selected");

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
    }
}
