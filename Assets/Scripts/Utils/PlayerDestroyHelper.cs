using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class PlayerDestroyHelper : MonoBehaviour
{
    public Player player;

    public void KillPlayer()
    {
        player.DestroyMe();
    }
    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }

}
