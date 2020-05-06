using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject gm;
    private ParticleSystem bulleteffect;
    public float colorFadeRatio = 1f;
    public float fireRate = 1.0f;
    private float _nextFire;
    private bool flag = false;


    private void Start()
    {
        bulleteffect = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (flag && Time.time > _nextFire)
        {
            Destroy(gm);
            
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Die();
            _nextFire = Time.time + fireRate;

        }         

    }

    //private void BoomEffect() 
    //{
    //    flag = true;
    //    bulleteffect.startSpeed = 1f;
    //    var trails = bulleteffect.trails;
    //    trails.enabled = false;
    //    var main = bulleteffect.main;
    //    main.
    //}


}
