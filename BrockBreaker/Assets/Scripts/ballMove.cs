using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMove : MonoBehaviour
{
    public float speed = 7f;
    public int breakCount_; //破壊したブロック数

    Rigidbody b_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        breakCount_ = 0; //初期化
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void ballStart(float x, float y, float z, GameObject gameObject) //指定位置からのボール発射（ステージ開始時）
    {
        gameObject.transform.position = new Vector3(x, y, z);
        b_rigidbody = gameObject.GetComponent<Rigidbody>();
        gameObject.SetActive(true);
        b_rigidbody.velocity = new Vector3(speed, speed, 0);
    }

    private void OnCollisionEnter(Collision collision) //破壊したブロック数をカウント
    {
        if (collision.gameObject.tag == "block")
        {
            breakCount_++;
        }
    }

    public int blockBreakCount() //破壊したブロック数を返す
    {
        return breakCount_;
    }
}
