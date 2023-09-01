using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 20f;
    private Rigidbody2D rb;
    private Animator animator;
    public event EventHandler OnPlayerAttacking;
    public event EventHandler OnCoinCollection;
    Vector3 lastMoveDir = Vector3.zero;
    [SerializeField] private LayerMask enemiesLayerMask;
    private HealthSystem healthSystem;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        healthSystem = GetComponent<HealthSystem>();

    }
    private void Update()
    {
        MovementHandler();
        Attack();
    }

    private void MovementHandler()
    {

        float xDir = Input.GetAxisRaw("Horizontal");
        float yDir = Input.GetAxisRaw("Vertical");
        Vector3 movDir = new Vector3(xDir, yDir, 0).normalized;
        rb.velocity = movDir * moveSpeed;
        if (movDir != Vector3.zero)
        {
            lastMoveDir = movDir;
            animator.SetFloat("horizontalMovement", lastMoveDir.x);
            animator.SetFloat("verticalMovement", lastMoveDir.y);
            // Animator 
            animator.SetBool("IsMoving", true);

        }
        else
        {
            animator.SetBool("IsMoving", false);

        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 7)
        {
            //Coin collection Event trigger
            OnCoinCollection?.Invoke(this, EventArgs.Empty);
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.layer == 8)
        {
            healthSystem.Damage(2);
            Vector3 knockBackdir = (transform.position - other.transform.position).normalized*1f;
            transform.position += knockBackdir;

        }
    }
   
    private void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
            RaycastHit2D raycastHit = Physics2D.CircleCast(transform.position,0.8f,lastMoveDir,1.7f,enemiesLayerMask);
            if(raycastHit.collider != null)
            {
                OnPlayerAttacking?.Invoke(this,EventArgs.Empty);
                

            }
            
        }

    }
}
