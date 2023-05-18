using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    private float cooldownTimer = Mathf.Infinity;
    private Health playerHealth;
    private Animator anim;
    private EnemyPatrol enemyPatrol;

    
    

    private void Awake()
    {
        anim = GetComponent <Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("attack");
            }
            
        }
        if (enemyPatrol!= null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
        if (Vector2.Distance(new Vector2(Mathf.Abs(transform.position.x), Mathf.Abs(transform.position.y)), new Vector2(Mathf.Abs(player.position.x), Mathf.Abs(player.position.y)))< 500f)
        {
            if(enemyPatrol!= null)
            {
                enemyPatrol.enabled = false;
               
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                if (PlayerInSight())
                {
                    anim.SetBool("moving", false);
                    speed = 0;
                    if (cooldownTimer >= attackCooldown)
                    {
                        cooldownTimer = 0;
                        anim.SetTrigger("attack");
                    }
                }
                else
                {
                    speed = 2;
                    anim.SetBool("moving", true);
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position , speed * Time.deltaTime);
                }
            }
        }
        else
        {
            if (enemyPatrol != null)
            {
                
                enemyPatrol.enabled = false;
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position*-1, speed * Time.deltaTime);
                if (PlayerInSight())
                {
                    anim.SetBool("moving", false);
                    speed = 0;
                    if (cooldownTimer >= attackCooldown)
                    {
                        cooldownTimer = 0;
                        anim.SetTrigger("attack");
                    }
                }
                else
                {
                    speed = 2;
                    anim.SetBool("moving", true);
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position * -1, speed * Time.deltaTime);
                }
            }
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(boxCollider.bounds.size.x*range,boxCollider.bounds.size.y,boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if(hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
