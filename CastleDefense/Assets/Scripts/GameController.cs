using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region Singleton
    public static GameController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of GameController !");
        }

        instance = this;
    }
    #endregion


    public int maxLifePoints = 3;
    private int _lifePoints;
    public Text lifePointsText;
    private int _lvl = 1;
    public Text lvlText;
    public List<Respawn> repawns;
    public GameObject NextScreen;
    public Text NextScreenText;

    // Start is called before the first frame update
    void Start()
    {
        _lifePoints = maxLifePoints;
        lifePointsText.text = _lifePoints.ToString();
        lvlText.text = _lvl.ToString();
    }

    private void Update()
    {
        foreach (Respawn r in repawns)
        {
            if (r.enemyNumberOnScene != 0 || r.enemyNumber != 0)
                return;
        }
        NextLvl();
    }

    public void TakeLP()
    {
        _lifePoints--;
        lifePointsText.text = _lifePoints.ToString();

        if (_lifePoints == 0)
        {
            ResetLvl();
        }
    }


    private void NextLvl()
    {
        _lvl++;
        lvlText.text = _lvl.ToString();
        foreach (Respawn r in repawns)
        {
            r.NextLvl();
        }

        NextScreenText.text = "Gotowy na następny poziom?";
        NextScreen.SetActive(true);

    }

    private void ResetLvl()
    {
        _lvl = 1;
        lvlText.text = _lvl.ToString();
        _lifePoints = maxLifePoints;
        lifePointsText.text = _lifePoints.ToString();

        foreach (Respawn r in repawns)
        {
            r.ResetLvl();
        }
        Time.timeScale = 0;

        NextScreenText.text = "Przegrałeś :(";
        NextScreen.SetActive(true);
    }
    public void UnPause()
    {
        NextScreen.SetActive(false);
        Time.timeScale = 1;

    }

}
