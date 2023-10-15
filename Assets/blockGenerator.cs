using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockGenerator : MonoBehaviour
{
    public GameObject block1Prefab;
    public GameObject block2Prefab;
    public GameObject block3Prefab;
    public GameObject block4Prefab;
    public GameObject block5Prefab;
    public GameObject block6Prefab;
    public GameObject block7Prefab;
    public GameObject preblock;
    float span = 3.0f;
    float delta = 0;
    public static int delta_all = 0;
    public static bool swL;
    public static bool swR;
    public static int state = 0;

    void Start()
    {
        state = 0;
        GameObject item;
        float start;
        int dice0 = Random.Range(-14, 15);
        //start = dice0 * 0.51f;
        start = dice0 * 0.50f;
        int dice = Random.Range(1, 8);
        if (dice == 1)
        {
            item = Instantiate(block1Prefab);
            item.transform.position = new Vector3(start, 4.0f, 0);
        }
        else if (dice == 2)
        {
            item = Instantiate(block2Prefab);
            item.transform.position = new Vector3(start, 4.0f, 0);
        }
        else if (dice == 3)
        {
            item = Instantiate(block3Prefab);
            item.transform.position = new Vector3(start, 4.0f, 0);
        }
        else if (dice == 4)
        {
            item = Instantiate(block4Prefab);
            item.transform.position = new Vector3(start, 4.0f, 0);
        }
        else if (dice == 5)
        {
            item = Instantiate(block5Prefab);
            item.transform.position = new Vector3(start, 4.0f, 0);
        }
        else if (dice == 6)
        {
            item = Instantiate(block6Prefab);
            item.transform.position = new Vector3(start, 4.0f, 0);
        }
        else
        {
            item = Instantiate(block7Prefab);
            item.transform.position = new Vector3(start, 4.0f, 0);
        }
        preblock = item;

    }
    public void TET_LButtonDown()
    {
        swL = true;
    }
    public void TET_RButtonDown()
    {
        swR = true;
    }
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span &&
            this.preblock.GetComponent<Rigidbody2D>().isKinematic == true)
        {
            this.delta = 0;
            GameObject item;
            float start;
            int dice0 = Random.Range(-14, 15);
            //start = dice0 * 0.51f;
            start = dice0 * 0.50f;
            int dice = Random.Range(1, 8);
            if (dice == 1)
            {
                item = Instantiate(block1Prefab);
                item.transform.position = new Vector3(start, 4.0f, 0);
            }
            else if (dice == 2)
            {
                item = Instantiate(block2Prefab);
                item.transform.position = new Vector3(start, 4.0f, 0);
            }
            else if (dice == 3)
            {
                item = Instantiate(block3Prefab);
                item.transform.position = new Vector3(start, 4.0f, 0);
            }
            else if (dice == 4)
            {
                item = Instantiate(block4Prefab);
                item.transform.position = new Vector3(start, 4.0f, 0);
            }
            else if (dice == 5)
            {
                item = Instantiate(block5Prefab);
                item.transform.position = new Vector3(start, 4.0f, 0);
            }
            else if (dice == 6)
            {
                item = Instantiate(block6Prefab);
                item.transform.position = new Vector3(start, 4.0f, 0);
            }
            else
            {
                item = Instantiate(block7Prefab);
                item.transform.position = new Vector3(start, 4.0f, 0);
            }
            delta_all += 1;
            preblock = item;
        }
    }
}