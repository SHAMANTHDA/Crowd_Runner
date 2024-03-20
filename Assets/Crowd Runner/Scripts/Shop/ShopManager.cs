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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnlockSkin(Random.Range(0, skinButtons.Length));
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

    private void UnlockSkin(int skinIndex)
    {
        PlayerPrefs.SetInt("skinButton" + skinIndex, 1);
        skinButtons[skinIndex].Unlock();
    }
    private void SelectSkin(int skinIndex)
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
    }
}
