using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBreak : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) //ボールが当たったとき、ブロックを破壊
    {
        if (collision.gameObject.tag == "ball")
        {
            Destroy(gameObject);
        } 
    }
}
