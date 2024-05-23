using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text pointText;
    public Text bestscoreText;

    void OnEnable()
    {
        GameManager.OnPointChanged += UpdatePointText;
        GameManager.OnBestScoreChanged += UpdateBestScoreText;
    }

    void OnDisable()
    {
        GameManager.OnPointChanged -= UpdatePointText;
        GameManager.OnBestScoreChanged -= UpdateBestScoreText;
    }

    void UpdatePointText(int newPoint)
    {
        pointText.text = "Points : " + newPoint;
    }

    void UpdateBestScoreText(int newBestScore)
    {
        bestscoreText.text = "BestScore : " + newBestScore;
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
