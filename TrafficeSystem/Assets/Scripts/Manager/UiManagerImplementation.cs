﻿using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// Scene Manager Implementations
public partial class UiManager : MonoBehaviour {
    private void Awake () {
        var currentSceneName = SceneManager.GetActiveScene().name.ToLower();
        if (currentSceneName == gamePlaySceneName.ToString().ToLower()) {
         ManageGamePlaySceneUI ();
         return;   
        }
    }

    private void Start () {
        var currentSceneName = SceneManager.GetActiveScene().name.ToLower();
        if (currentSceneName == gamePlaySceneName.ToString().ToLower()) {
         ListenToGamePlaySceneEvents ();
         return;   
        }
    }

    private void ManageGamePlaySceneUI () {
      coinCountUI = GameObject.Find (coinCountUIName).GetComponent <TextMeshProUGUI>();
    }

    private void ListenToGamePlaySceneEvents () {
      coinCountUI.text = $"Coins : {GameManager.Instance.gameState.coins}";  
      PlayerController.Instance.OnHitCoin += (System.Object sender , float coinsValue) => 
        coinCountUI.text = $"Coins : {GameManager.Instance.gameState.coins}";  
    }

    
}