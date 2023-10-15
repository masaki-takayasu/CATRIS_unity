using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TET_RButtonController : MonoBehaviour
{
    RectTransform rect;
    int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    public void changeButtonDown()
    {
        if (state == 0)
        {
            rect.localPosition += new Vector3(420, 0, 0);
            state = 1;
        }
        else
        {
            rect.localPosition += new Vector3(-420, 0, 0);
            state = 0;
        }
    }
}
