using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Ebac.Core.Singleton;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject playerPrefab;

    [Header("Player")]
    public List<GameObject> enemies;

    [Header("References")]
    public Transform startPoint;

    [Header("Animation")]
    public float duration = .2f;
    public float delay = 0.5f;
    public Ease ease = Ease.OutBack;

    private GameObject _currentPlayer;

    private void Start()
    {
        init();
    }

    public void init()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        _currentPlayer = Instantiate(playerPrefab);
        _currentPlayer.transform.position = startPoint.position;
        _currentPlayer.transform.DOScale(0, duration).SetEase(ease).From().SetDelay(delay);
    }

}
