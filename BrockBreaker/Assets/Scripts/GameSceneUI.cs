using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameSceneUI : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI; //ゲームオーバー時のUI
    [SerializeField] GameObject gameSceneUI; //画面左上に常に表示されているUI（点数とライフ数）
    [SerializeField] GameObject ball; //ゲームオーバー時に、ボールを非表示にするために参照
    [SerializeField] ballMove ballMove;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI lifeText;

    private int playerLife_;
    private string title;

    // Start is called before the first frame update
    void Start()
    {
        playerLife_ = 3;
        title = "Title";
        gameOverUI.SetActive(false);
        gameSceneUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //インゲーム中に映っているUIの更新

        scoreText.SetText("Score:{0}", ballMove.blockBreakCount());
        lifeText.SetText("Life:{0}", playerLife_);
    }

    private void OnCollisionEnter(Collision collision) //ボールが下に落ちた時の処理
    {
        if (collision.gameObject.tag == "ball")
        {
            playerLife_--; //残機を減らす
            if (playerLife_ == 0) //プレイヤーの残機が0になったとき、ゲームオーバーUIを表示
            {
                gameSceneUI.SetActive(false);
                showGameOver();
            }
            else //再度ボールを発射（リトライ）
            {
                ballMove.ballStart(0, -1.77f, 0, ball);
            }     
        }
    }

    void showGameOver() //ゲームオーバーUI表示関数
    {
        gameOverUI.SetActive(true);
        ball.SetActive(false);
    }

    public void OnBackButtonClick() //ゲームオーバー画面のボタン関数(OnClick())
    {
        SceneManager.LoadScene(title);
    }
}
