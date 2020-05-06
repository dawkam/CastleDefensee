using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public int enemyNumber;
    public int enemyNumberOnScene;
    public int maxEnemyNumber;
    public int maxEnememyNumberOnScane;
    public GameObject enemyPrefab;
    public ParticleSystem groundEffect;

    public float colorFadeRatio=1;
    public float respawnRateMin = 5.0f;
    public float respawnRateMax = 15.0f;
    private float _nextRespawn;
    private float _respawnRate;

    private Color baseColor;


    void Start() 
    {
        enemyNumber = maxEnemyNumber;
        baseColor = groundEffect.startColor;
    }

    void Update()
    {
        _respawnRate = Random.Range(respawnRateMin, respawnRateMax);
        enemyNumberOnScene = GetComponentsInChildren<Enemy>().Length;

        if (enemyNumber > 0 && enemyNumberOnScene < maxEnememyNumberOnScane &&
            Time.time > _nextRespawn)
        {
            _nextRespawn = Time.time + _respawnRate;
            enemyNumber--;
            Instantiate(enemyPrefab, this.transform);

        }
        else if(enemyNumber==0)
        {
           
            groundEffect.startColor -= groundEffect.startColor * colorFadeRatio * Time.deltaTime;


        }


    }

    public void ResetLvl()
    {
        maxEnemyNumber = 3;
        enemyNumber = maxEnemyNumber;
        foreach (Enemy e in GetComponentsInChildren<Enemy>()) 
        {
            e.InsatnDie();
        }
        groundEffect.startColor = baseColor;
    }


    public void NextLvl() 
    {
        maxEnemyNumber += 2;
        enemyNumber = maxEnemyNumber;
        groundEffect.startColor = baseColor;
    }


}
