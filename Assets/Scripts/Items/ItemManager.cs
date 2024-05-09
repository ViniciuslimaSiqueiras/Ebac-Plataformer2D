using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    public SOInt coins;

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
        coins.value = 0;

    }

    public void AddCoins(int amount = 1)
    {
        this.coins.value += amount;
    }

    private void updateUI()
    {
        //uiTextCoins.text = coins.ToString();
        UIInGameManager.UpdateTextCoins(coins.value.ToString());
    }
}
