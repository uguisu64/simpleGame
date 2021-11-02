using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject mainSceneManager;
    private MainSceneManager msm;

    private new Rigidbody rigidbody;

    private float speed = 5.0f;
    private bool jmpFlg;

    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        msm = mainSceneManager.GetComponent<MainSceneManager>();

        jmpFlg = false;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rigidbody.AddForce(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rigidbody.AddForce(Vector3.back * speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(Vector3.right * speed);
        }
        if (Input.GetKey(KeyCode.Space) && jmpFlg)
        {
            jmpFlg = false;
            rigidbody.AddForce(Vector3.up * 200.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            Destroy(other.gameObject);
            msm.addScore();
        }
        else if (other.tag == "Enemy")
        {
            msm.GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jmpFlg = true;
        }
    }
}
