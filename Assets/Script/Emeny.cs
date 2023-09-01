using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emeny : MonoBehaviour
{
    [SerializeField] private List<Transform> patrolPosition;
    [SerializeField] private LayerMask playerLayerMask;

    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] private int index =0 ;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        
        RaycastHit2D raycastHit = Physics2D.CircleCast(transform.position, 4f , Vector2.zero,0f, playerLayerMask);
        if(raycastHit.collider != null )
        {
             GoToPosition(raycastHit.collider.transform.position);
           
            animator.SetBool("attack",false);
               
        }
        else{
            GoToPosition(patrolPosition[index].position);
            if(Vector3.Distance(transform.position, patrolPosition[index].position) <0.2f)
                {
                 
                    
                    
                    if(index < patrolPosition.Capacity-1)
                    {
                        index ++;
                    }
                    else
                    {
                        index =0;

                    }
                    GoToPosition(patrolPosition[index].position);
                }
                
            }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name == "Player")
        {
            animator.SetTrigger("windup");
            
            other.gameObject.GetComponent<HealthSystem>().Damage(10);
           
            
            
        }
    }
    private void GoToPosition(Vector3 location)
    {
        float moveSpeed = 5f;
        Vector3 moveDir = (location - transform.position).normalized;
        rb.velocity = moveDir*moveSpeed;
        animator.SetFloat("horizontalMovement", rb.velocity.x);
        animator.SetFloat("verticalMovement", rb.velocity.y);
        animator.SetBool("isMoving",true);
        
        
       
       

        
    }
   
}
