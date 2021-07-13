using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject hpGage;
    public bool gameStopFlag;
    Text gameOverText;
    Text timeText;
    Text gameClearText;
    GameObject restButton;
    float gameTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        this.hpGage = GameObject.Find("hpGage");
        timeText = GameObject.Find("time").GetComponent<Text>();
        gameOverText = GameObject.Find("gameOver").GetComponent<Text>(); //componentをコントロール
        gameClearText = GameObject.Find("gameClear").GetComponent<Text>();
        restButton = GameObject.Find("Reset"); //オブジェクトをコントロール
        gameOverText.enabled = false;
        gameClearText.enabled = false;
        restButton.SetActive(false);
    }

    public void DecreaseHP()
    {
        this.hpGage.GetComponent<Image>().fillAmount -= 0.4f;
        //HP0でゲームリセット
        if (this.hpGage.GetComponent<Image>().fillAmount <= 0)
        {
            gameStopFlag = true;
            gameOverText.enabled = true;
            restButton.SetActive(true);
        }
    }

    private void Update()
    {
        if (gameStopFlag) return; //これ以降の処理をskip

        gameTime -= Time.deltaTime;
        timeText.text = gameTime.ToString("F2");
        if(gameTime <= 0)
        {
            gameStopFlag = true;
            gameClearText.enabled = true;
            restButton.SetActive(true);
        }
    }

    public void OnPressReset()  //OnPressクリックしたら
    {
        SceneManager.LoadScene("GameScene"); //今のシーンを再度読み込むでリセットできます
    }
}
