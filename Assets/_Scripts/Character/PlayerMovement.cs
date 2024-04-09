using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private Vector2 move;

    private void OnMove(InputValue value)
    {
       move = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(move.x, move.y) * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
