using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButtonsManager : MonoBehaviour
{

    public List<GameObject> buttons;

    [Header("Animation")]
    public float duration = .2f;
    public float delay = 0.5f;
    public Ease ease = Ease.OutBack;

    private void Awake()
    {
        hideButtons();
        ShowButtons();
    }
    private void ShowButtons()
    { 
        for(int i = 0; i < buttons.Count; i++)
        {
            var b = buttons[i];
            b.SetActive(true);
            b.transform.DOScale(1, duration).SetDelay(i * delay).SetEase(ease);

        }
    }
    public void hideButtons()
    {
        foreach(var b in buttons)
        {
            b.SetActive(false);
            b.transform.localScale = Vector3.zero;
        }
    }


    
}
