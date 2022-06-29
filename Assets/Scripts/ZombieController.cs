using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public int zombieHealth = 3;
    public float destroyTime = 2f;

    private Animator shootAnim;
    private Animator deathAnim;
    private bool isShooten;
    private bool isDeath;
    public bool isAttack = false;

    public float shootTime = 0.2f;
    public float attackTime = 1f;

    private float lastAttackTime = 0;
    private float lastShootenTime = 0;

    public bool IsShooten
    {
        get { return isShooten; }
        set
        {
            isShooten = value;
            ShootenAnim(isShooten);
            UpdateLastShootenTime();
        }
    }

    public bool IsDeath { get => isDeath; set => isDeath = value; }

    // Start is called before the first frame update
    void Start()
    {
        shootAnim = gameObject.GetComponent<Animator>();
        deathAnim = gameObject.GetComponent<Animator>();
        IsShooten = false;
        IsDeath = false;
        isAttack = false;
    }

    void DeathAnim(bool isDeath)
    {
        deathAnim.SetBool("isDeath", isDeath);
    }


    void UpdateLastShootenTime()
    {
        lastShootenTime = Time.time;
    }

    void UpdateAttackTime()
    {
        lastAttackTime = Time.time;
    }

    void ShootenAnim(bool isShooten)
    {
        shootAnim.SetBool("isShooten", isShooten);
    }

    void AttackAnim(bool isAttack)
    {
        shootAnim.SetBool("isAttack", isAttack);
    }

    public void GetHit(int damge)
    {
        IsShooten = true;
        
        zombieHealth -= damge;
        
        if (zombieHealth <= 0)
        {
            
            Dead();
        }
    }

    void CheckIsShooten()
    {
        if(IsShooten && Time.time >= lastShootenTime + shootTime)
        {
            IsShooten = false;
            
        }
    }

    void Dead()
    {
        isDeath = true;
        DeathAnim(isDeath);
        gameObject.GetComponent<Movement>().enabled = false;
        Destroy(gameObject, destroyTime);
    }

    void Attack()
    {
        if(Time.time >= lastAttackTime + attackTime)
        {
            AttackAnim(true);
            UpdateAttackTime();
        }
        else
        {
            AttackAnim(false);
        }
        
    }

    void CheckIsAttack()
    {
        if (isAttack)
        {
            Attack();
        }
    }

    

    // Update is called once per frame
    void Update()
    {

        CheckIsShooten();
        CheckIsAttack();
    }
}
