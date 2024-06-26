using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private SoundsManager soundsManager;
    [SerializeField] private VibrationManager vibrationManager;
    [SerializeField] private Sprite optionOnSprite;
    [SerializeField] private Sprite optionOffSprite;
    [SerializeField] private Image soundsButtonImage;
    [SerializeField] private Image hapticButtonImage;

    [Header("Settings")]
    private bool soundsState = true;
    private bool hapticState = true;

    private void Awake()
    {
        soundsState = PlayerPrefs.GetInt("sounds", 1) == 1;
        hapticState = PlayerPrefs.GetInt("haptics", 1) == 1;
    }

    private void Start()
    {
        SetUp();
    }

    #region SetUp
    private void SetUp()
    {
        if (soundsState)
        {
            EnableSounds();
        }
        else
        {
            DisableSounds();
        }
        
        if (hapticState)
        {
            EnableHaptic();
        }
        else
        {
            DisableHaptic();
        }
    }

    #endregion

    #region Sounds
    public void ChangeSoundState()
    {
        if (soundsState)
        {
            DisableSounds();
        }
        else
        {
            EnableSounds();
        }

        soundsState = !soundsState;

        PlayerPrefs.SetInt("sounds", soundsState ? 1 : 0);
    }

    private void EnableSounds()
    {
        soundsManager.EnableSounds();

        soundsButtonImage.sprite = optionOnSprite;
    }

    private void DisableSounds()
    {
        soundsManager.DisableSounds();

        soundsButtonImage.sprite = optionOffSprite;
    }
    #endregion

    #region Haptics
    public void ChangeHapticState()
    {
        if (hapticState)
        {
            DisableHaptic();
        }
        else
        {
            EnableHaptic();
        }

        hapticState = !hapticState;

        PlayerPrefs.SetInt("haptics", hapticState ? 1 : 0);
    }

    private void DisableHaptic()
    {
        vibrationManager.DisableHaptic();

        hapticButtonImage.sprite = optionOffSprite;
    }

    private void EnableHaptic()
    {
        vibrationManager.EnableHaptic();

        hapticButtonImage.sprite = optionOnSprite;
    }
    #endregion
}
