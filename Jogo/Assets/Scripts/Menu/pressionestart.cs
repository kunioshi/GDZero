using UnityEngine;
using System.Collections;

public class pressionestart : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.fixedTime % .5 < .2)
        {

            renderer.enabled = false;

        }

        else
        {

            renderer.enabled = true;

        }
    }



}
