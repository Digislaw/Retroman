﻿using System.Collections;
using UnityEngine;

public class FinishFlag : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private Layer playerLayer;

    [SerializeField]
    private AudioClip victorySound;

    [SerializeField]
    private string[] levelsToUnlock;    // nazwy poziomow do odblokowania

    [SerializeField]
    private LevelData levelData;

    [Header("User Interface")]
    [SerializeField]
    private RectTransform victoryUI;

    [SerializeField]
    private FadeEffect fade;

    private float finalTime;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (playerLayer.Compare(col.gameObject.layer))
        {
            finalTime = Time.timeSinceLevelLoad;
            PlayerMovement.Instance.Freeze();

            UnlockLevels();
            UpdateRecords();
            PlayerPrefs.Save();
            CompleteLevel();            
        }
    }

    private void UnlockLevels()
    {
        for(int i = 0; i<levelsToUnlock.Length; i++)
            PlayerPrefs.SetInt(levelsToUnlock[i] + "_Unlocked", 1);
    }

    private void UpdateRecords()
    {
        // Ukonczono poziom
        PlayerPrefs.SetInt(levelData.Name + "_Completed", 1);

        // Monety
        string coinsKey = levelData.Name + "_Coins";
        int bestCoins = PlayerPrefs.GetInt(coinsKey, 0);
        if(levelData.Coins > bestCoins)
            PlayerPrefs.SetInt(coinsKey, levelData.Coins);

        // Diamenty
        string diamondsKey = levelData.Name + "_Diamonds";
        int bestDiamonds = PlayerPrefs.GetInt(diamondsKey, 0);
        if (levelData.Diamonds > bestDiamonds)
            PlayerPrefs.SetInt(diamondsKey, levelData.Diamonds);

        // Czas
        string timeKey = levelData.Name + "_Time";
        if (PlayerPrefs.HasKey(timeKey))
        {
            float bestTime = PlayerPrefs.GetFloat(timeKey);
            if (finalTime < bestTime)
                PlayerPrefs.SetFloat(timeKey, finalTime);
        }
        else
        {
            PlayerPrefs.SetFloat(timeKey, finalTime);
        }
    }

    private void CompleteLevel()
    {
        AudioController.Instance.PlayMusicWithDelay(AudioController.Instance.currentMusic, victorySound.length);
        AudioController.Instance.PlayMusic(victorySound);
        StartCoroutine(VictoryScreen(victorySound.length));
    }

    private IEnumerator VictoryScreen(float time)
    {
        float wait = time - fade.Duration;  // czas po jakim ekran bedzie sie zaciemnial
        victoryUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(wait);
        fade.FadeIn();
        yield return new WaitForSeconds(time - wait);
        SceneController.Instance.ChangeLevel("Level Selection");
    }
}
