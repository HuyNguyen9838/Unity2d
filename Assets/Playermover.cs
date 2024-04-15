using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermover : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;
    public float damage;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
   
        

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);


        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);

        anim.SetBool("moving", horizontalInput != 0);

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("meleAttack");
        }
    }

    public void attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);
        foreach(Collider2D enemyGameobject in enemy)
        {
            Debug.Log("Hit enemy");
            enemyGameobject.GetComponent<EnemyHealth>().health -= damage;
        }
    }
    public void endAttack()
    {
        //anim.SetTrigger("meleAttack");
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }


}
