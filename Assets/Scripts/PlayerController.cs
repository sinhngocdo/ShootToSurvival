using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int damge = 0;
    public float fireTime = 0.3f;
    private float lastFireTime = 0;

    private Animator gunShootAnim;

    // Start is called before the first frame update
    void Start()
    {
        UpdateFireTime();
        gunShootAnim = gameObject.GetComponent<Animator>();
    }

    void UpdateFireTime()
    {
        lastFireTime = Time.time;
    }


    void SetFireAnim(bool isFire)
    {
        gunShootAnim.SetBool("isFire", isFire);
    }

    void Fire()
    {

        if (Input.GetMouseButtonDown(0))
        {
            
            HandleFire();
        }
    }

    void HandleFire()
    {
        if (Time.time >= lastFireTime + fireTime)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //tia duong thang vuong goc voi man hinh
            RaycastHit hit;// vat the ma ray dung phai


            SetFireAnim(true);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag.Equals("Enemy"))
                {
                    hit.transform.gameObject.GetComponent<ZombieController>().GetHit(damge);
                }
            }
            UpdateFireTime();
        }
        else
        {
            SetFireAnim(false);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }
}
