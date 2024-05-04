using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    public int coins;

    public TextMeshProUGUI uiTextCoins;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Reset();
        
    }
    private void Update()
    {
        updateUI();
    }
    private void Reset()
    {
        coins = 0;

    }

    public void AddCoins(int amount = 1)
    {
        this.coins += amount;
    }

    private void updateUI()
    {
        //uiTextCoins.text = coins.ToString();
        UIInGameManager.UpdateTextCoins(coins.ToString());
    }
}
