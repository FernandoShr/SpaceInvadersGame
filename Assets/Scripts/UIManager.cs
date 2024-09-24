using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText, hpText;
    public int score, hp;

    private int aux = 0;

    public void Awake()
    {
        UpdateScoreText();
        UpdateHPText();
    }

    public void UpdateHPText()
    {
        
        if (aux == 0)
        {
            hpText.text = hp.ToString("3");
            aux++;
        }
        else
        {
            hpText.text = hp.ToString("0");
        }
    }

    public void UpdateHP(int value)
    {
        hp = value;
        UpdateHPText();
    }

    public void UpdateScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = score.ToString("000"); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
