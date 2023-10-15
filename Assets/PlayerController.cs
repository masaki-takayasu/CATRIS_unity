using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 400.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;
    bool swL;
    bool swR;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "needle")
        { 
            SceneManager.LoadScene("FailedScene");
        }
        if (collision.gameObject.tag == "goal")
        {
            SceneManager.LoadScene("ClearScene");
        }
    }


    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    public void CAT_LButtonDown()
    {
        swL = true;
    }
    public void CAT_LButtonUp()
    {
        swL = false;
    }
    public void CAT_RButtonDown()
    {
        swR = true;
    }
    public void CAT_RButtonUp()
    {
        swR = false;
    }
    void Update()
    {

        // ジャンプする
        if (Input.GetMouseButtonDown(0) && this.rigid2D.velocity.y==0&& blockGenerator.state == 1)
        {
            Vector3 mousePos = Input.mousePosition;
            if((mousePos.x>=260f && mousePos.x <= 1130f ) ||
                (mousePos.y >=230f && mousePos.y <=870f ))
            {
                GetComponent<AudioSource>().Play();
                this.animator.SetTrigger("JumpTrigger");
                this.rigid2D.AddForce(transform.up * this.jumpForce);
            }
        }

        // 左右移動
        int key = 0;
        if (swL) key = -1;
        if (swR) key = 1;

        // プレイヤの速度
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // スピード制限
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        // 動く方向に応じて反転
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        if (this.rigid2D.velocity.y==0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        // プレイヤの速度に応じてアニメーション速度を変える
        this.animator.speed = speedx / 2.0f;
    }
}
