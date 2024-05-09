using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    public Animator player;

    [Header("Walk")]
    public float speed;
    public float speedRun;
    public Vector2 friction = new Vector2(.1f, 0);

    [Header("WalkAnimation")]
    public float jumpScaleY = 2.5f;
    public float jumpScaleX = 1.5f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;

    [Header("Player Animation")]
    public int boolRun = Animator.StringToHash("Run");
    public int deathHash = Animator.StringToHash("Death");

    [Header("Jump")]
    public float forceJump;
}
