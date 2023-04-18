using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    public Vector3 initialScale;
    public Vector3 finalScale;
    public float transitionDuration = 10f;
    public float timeElapsed = 0f;
    public float time;
    public Transform positionBegin;
    public Transform positionEnd;
    public float speed = 1f;

    public AnimationCurve myAnimationCurve;


    private void Start()
    {
        transform.localScale = initialScale;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E)) LerpHelper();

        /*
        if (time < 1)
        {
            Lerping();

        }
        if (time >= 1)
        {
            LerpingBack();
        }
        */
    }

    public void Lerping()
    {
        timeElapsed += Time.deltaTime;
        time = timeElapsed / transitionDuration;

        transform.localScale = Vector3.Lerp(initialScale, finalScale, time);
        transform.position = Vector3.Lerp(positionBegin.transform.position, positionEnd.transform.position, time);

    }

    public void LerpingBack()
    {
        //resetando as variaveis
        timeElapsed = 0;
        timeElapsed += Time.deltaTime;
        time = timeElapsed / transitionDuration;

        transform.position = Vector3.Lerp(positionBegin.transform.position, positionEnd.transform.position, time);


    }

    public void LerpHelper()
    {
        time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(positionBegin.transform.position, positionEnd.transform.position, time);
    }
}

