using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    public Animator anim;
    public KeyCode keyA = KeyCode.A;
    public int animHash = Animator.StringToHash("Fly");

    private void OnValidate()
    {
        if(anim == null)
        {
            anim = GetComponent<Animator>();
        }
    }
    void Update()
    {
        if (Input.GetKey(keyA))
        {
            anim.SetTrigger(animHash);
        }
    }
}
