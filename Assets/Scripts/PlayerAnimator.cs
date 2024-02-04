using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerAnimator : NetworkBehaviour
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
        if (!IsOwner) return;
        _animator.SetBool(IsWalking, player.IsWalking());
    }
}
