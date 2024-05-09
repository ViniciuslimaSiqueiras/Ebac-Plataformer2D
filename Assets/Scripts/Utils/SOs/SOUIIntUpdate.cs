using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Net;

public class SOUIIntUpdate : MonoBehaviour
{
    public SOInt soInt;
    public TextMeshProUGUI uiTextVaue;

    private void Start()
    {
        uiTextVaue.text = soInt.value.ToString();
    }

    private void Update()
    {
        uiTextVaue.text = soInt.value.ToString();
    }
}