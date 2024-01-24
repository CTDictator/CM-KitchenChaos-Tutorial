using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    [SerializeField] private Player player;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(IsWalking, player.IsWalking());
    }
}
