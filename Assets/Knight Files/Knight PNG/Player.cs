using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float tocdo;
    private bool isfaccingRight = true;
    private Rigidbody2D rb;
    private Animator anim;
    private float trai_phai;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

  
    void Update()
    {
        trai_phai = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(trai_phai * tocdo, rb.velocity.y);

        quaydau();

        anim.SetFloat("run", Mathf.Abs(trai_phai));
    }

    void quaydau()
    {
        if(isfaccingRight && trai_phai <0 || !isfaccingRight && trai_phai > 0)
        {
            isfaccingRight = !isfaccingRight;
            Vector3 kich_thuoc = transform.localScale;
            kich_thuoc.x = kich_thuoc.x* -1;
            transform.localScale = kich_thuoc;
            
        }
    }
}
