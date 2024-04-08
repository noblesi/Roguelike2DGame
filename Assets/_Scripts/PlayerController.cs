using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private Vector2 move;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();    
    }

    private void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    private void onAttack(InputValue value)
    {
        bool isAttack = value.isPressed;
        if (isAttack)
        {
            Debug.Log("aaaa");
            anim.SetTrigger("Attack");
        }
    }

    private void Update()
    {
        if(move.x == 0 && move.y == 0)
        {
            anim.SetBool("isIdle", true);
        }
        else
        {
            anim.SetBool("isIdle", false);
            if (move.x == 1)
            {
                anim.SetFloat("MoveX", 1);
                anim.SetFloat("MoveY", 0);
            }
            else if (move.x == -1)
            {
                anim.SetFloat("MoveX", -1);
                anim.SetFloat("MoveY", 0);
            }
            else if (move.y == 1)
            {
                anim.SetFloat("MoveX", 0);
                anim.SetFloat("MoveY", 1);
            }
            else if (move.y == -1)
            {
                anim.SetFloat("MoveX", 0);
                anim.SetFloat("MoveY", -1);
            }
        }
        
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(move.x, move.y) * speed * Time.deltaTime;
        transform.Translate(movement);  
    }
}
