using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private bool isWalking;
    private void Update()
    {
        Vector2 inputVector = new Vector2();
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = 1;
        }
        inputVector.Normalize();
        Vector3 moveDirection = new(inputVector.x, 0, inputVector.y);
        transform.position += moveDirection * (Time.deltaTime * moveSpeed);
        isWalking = moveDirection != Vector3.zero;
        float rotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward,moveDirection, Time.deltaTime * rotationSpeed);
        Debug.Log(inputVector);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
