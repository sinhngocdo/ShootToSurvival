using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int damge = 0;
    public float fireTime = 0.3f;
    private float lastFireTime = 0;
    public int playerHeath = 10;
    private int playerCurrentHeatlh;

    public GameObject smoke;
    public GameObject gunHead;
    public GameObject gameManager;

    private AudioSource playerSound;
    public AudioClip playerHurt;
    public AudioClip playerDeath;

    public Slider healthBar;

    private bool isTurnLight;

    private Animator gunShootAnim;

    // Start is called before the first frame update
    void Start()
    {
        UpdateFireTime();
        gunShootAnim = gameObject.GetComponent<Animator>();
        isTurnLight = false;
        playerCurrentHeatlh = playerHeath;

        playerSound = gameObject.GetComponent<AudioSource>();
        gameManager = GameObject.FindGameObjectWithTag("GameController");

        healthBar.maxValue = playerHeath;
        healthBar.value = playerCurrentHeatlh;
        healthBar.minValue = 0;
    }

    void UpdateFireTime()
    {
        lastFireTime = Time.time;
    }


    void SetFireAnim(bool isFire)
    {
        gunShootAnim.SetBool("isFire", isFire);
    }

    public void GetHit(int damge)
    {
        playerSound.clip = playerHurt;
        playerSound.Play();
        playerCurrentHeatlh -= damge;
        healthBar.value = playerCurrentHeatlh;

        if (playerCurrentHeatlh <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {

        playerSound.clip = playerDeath;
        playerSound.Play();
        gameManager.GetComponent<GameManager>().EndGame();
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
            InsSmoke();
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

    /// <summary>
    /// bat tat tia laze cua sung bang phim F
    /// </summary>
    void SettingLight()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isTurnLight = !isTurnLight;
            if (isTurnLight)
            {
                gunHead.gameObject.GetComponent<Light>().enabled = true;
            }
            else
            {
                gunHead.gameObject.GetComponent<Light>().enabled = false;
            }
        }
        
    }

    void InsSmoke()
    {
        GameObject sm = Instantiate(smoke, gunHead.transform.position, gunHead.transform.rotation) as GameObject;
        Destroy(sm, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
        SettingLight();
    }
}
