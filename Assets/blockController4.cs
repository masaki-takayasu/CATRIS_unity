using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class blockController4 : MonoBehaviour
{
    string precommand;
    float span = 0.5f;
    float delta = 0;
    public AudioClip rotateSE;
    public AudioClip fallSE;
    bool swL;
    bool swR;
    bool fall_on = false;
    bool judge;
    Vector3 startPos;
    AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.GetComponent<Rigidbody2D>().isKinematic == false)
        {
            if (collision.gameObject.tag == "cat")
            {
                SceneManager.LoadScene("FailedScene");
            }
        }
        if (collision.gameObject.tag != "ground")
        {
            if (gameObject.GetComponent<Rigidbody2D>().isKinematic == false)
            {
                gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                this.aud.PlayOneShot(this.fallSE);
            }
        }
        //gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        //gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        /*if (collision.gameObject.tag == "block"
            && precommand == "left")
        {
            transform.Translate(0.51f, 0, 0);
            precommand = "null";
        }
        if (collision.gameObject.tag == "block"
            && precommand == "right")
        {
            transform.Translate(-0.51f, 0, 0);
            precommand = "null";
        }
        if (collision.gameObject.tag == "cat")
        {
            Debug.Log("GameOver");
        }*/
    }



    void Update()
    {
        this.delta += Time.deltaTime;
        if (fall_on == false)
        {
            if (blockGenerator.delta_all <= 4)
            {
                this.span = 0.5f;
            }
            else if (blockGenerator.delta_all > 4 && blockGenerator.delta_all <= 8)
            {
                this.span = 0.44f;
            }
            else if (blockGenerator.delta_all > 8 && blockGenerator.delta_all <= 12)
            {
                this.span = 0.38f;
            }
            else if (blockGenerator.delta_all > 12 && blockGenerator.delta_all <= 16)
            {
                this.span = 0.32f;
            }
            else if (blockGenerator.delta_all > 16 && blockGenerator.delta_all <= 20)
            {
                this.span = 0.26f;
            }
            else if (blockGenerator.delta_all > 20 && blockGenerator.delta_all <= 24)
            {
                this.span = 0.20f;
            }
            else
            {
                this.span = 0.15f;
            }
        }
        if (gameObject.GetComponent<Rigidbody2D>().isKinematic == false)
        {
            if (this.delta > this.span)
            {
                this.delta = 0;
                transform.position += new Vector3(0, -0.250f, 0);
                transform.position += new Vector3(0, -0.250f, 0);
            }
            if (blockGenerator.swL)
            {
                transform.position += new Vector3(-0.50f, 0, 0);
                blockGenerator.swL = false;
            }
            else if (blockGenerator.swR)
            {
                transform.position += new Vector3(0.50f, 0, 0);
                blockGenerator.swR = false;
            }
            if (Input.GetMouseButtonDown(0) && blockGenerator.state == 0)
            {
                Vector3 mousePos = Input.mousePosition;
                this.startPos = mousePos;
            }
            else if (Input.GetMouseButtonUp(0) && blockGenerator.state == 0)
            {
                Vector3 endPos = Input.mousePosition;
                float swipeLength_y = endPos.y - this.startPos.y;
                if (swipeLength_y < -150f)
                {
                    this.span = 0.05f;
                    judge = false;
                    fall_on = true;
                }
                else if ((endPos.x >= 260f && endPos.x <= 1130f) ||
                        (endPos.y >= 230f && endPos.y <= 870f))
                {
                    judge = true;
                }
                else
                {
                    judge = false;
                }
            }
            if (judge)
            {
                this.aud.PlayOneShot(this.rotateSE);
                judge = false;
            }
        }
    }
}
