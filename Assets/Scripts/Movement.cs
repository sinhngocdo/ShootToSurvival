using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed;
    public float minMoveSpeed = 0.03f;
    public float maxMoveSpeed = 0.5f;
    public float rangeAttack = 1f;

    GameObject player;
    GameObject lookatTarget;


    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        lookatTarget = GameObject.FindGameObjectWithTag("LookatTarget");

        UpdateMoveSpeed();
    }

    void UpdateMoveSpeed()
    {
        speed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
        LookatPlayer();
    }


    void MoveEnemy()
    {
        if(player == null || lookatTarget == null)
        {
            return;
        }
        if( Vector3.Distance(transform.position, player.transform.position) > rangeAttack)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("isIdle", true);
            gameObject.GetComponent<ZombieController>().isAttack = true;
            gameObject.GetComponent<Movement>().enabled = false;
        }
        
    }

    void LookatPlayer()
    {
        transform.LookAt(lookatTarget.transform.position);
    }
}
