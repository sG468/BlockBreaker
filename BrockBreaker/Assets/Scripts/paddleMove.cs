using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleMove : MonoBehaviour
{
    [SerializeField] GameObject wallLeft;
    [SerializeField] GameObject wallRight;

    public float speed = 5f;

    Rigidbody p_rigidbody; 

    // Start is called before the first frame update
    void Start()
    {
        p_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        p_rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0, 0);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if ((other.gameObject == wallLeft) || (other.gameObject == wallRight))
    //    {
    //        beTouched = true;
    //    }
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    if ((other.gameObject == wallLeft) || (other.gameObject == wallRight))
    //    {
    //        beTouched = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    beTouched = false;
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if ((collision.gameObject == wallLeft) || (collision.gameObject == wallRight)) 
    //    {
    //        beTouched = true;
    //    }
    //}

    //private void OnCollisionStay(Collision collision)
    //{
    //    if ((collision.gameObject == wallLeft) || (collision.gameObject == wallRight))
    //    {
    //        beTouched = true;
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    beTouched = false;
    //}
}
