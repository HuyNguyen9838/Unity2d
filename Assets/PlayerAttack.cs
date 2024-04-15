using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private float attackCooldownd;
    [SerializeField] private GameObject[] fireballs;
    private Animator anim;
    private Playermover playermover;
    private float cooldownTimer = Mathf.Infinity;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playermover = GetComponent<Playermover>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
            Attack();

        cooldownTimer += Time.deltaTime;
    }
    private void Attack()
    {
       
       //
    }
    private int FindFireball()
    {
        for (int i =0; i< fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;

        }
        return 0;
    }
}
