using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    [SerializeField] GameObject[] stage; //それぞれのステージのブロックを、空オブジェクト配列に格納し、その表示切替でステージ遷移を行っている。
    [SerializeField] ballMove ballMove;
    public GameObject ball;

    public bool clear_;
    public int speed = 5;
    private int stageCount;


    // Start is called before the first frame update
    void Start()
    {
        stage[0].SetActive(true); //最初のステージを表示
        ballMove.ballStart(0, -1.77f, 0, ball); //ボールの発射
    }

    // Update is called once per frame
    void Update()
    {
        if (stage[stageCount].transform.childCount == 0)//ブロックを全て壊したら（空オブジェクト（親）の中の子オブジェクト（そのステージのブロック）が一つも残っていない時）
        {
            clear();
            ballMove.ballStart(0, -1.77f, 0, ball); //clear()でのステージ遷移後、ボールを発射
        }
    }   

    void clear() //ステージをクリアしたときに実行する関数（3ステージしかない）
    {
        stageCount++;

        if (stageCount < 3) //まだステージがあれば、次のステージに遷移
        {
            ball.SetActive(false);
            stage[stageCount - 1].SetActive(false);
            
            stage[stageCount].SetActive(true);
        }
        else //全てのステージをクリアしたら、ゲームを終了
        {
            EndGame();
        }
    }

    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
}
