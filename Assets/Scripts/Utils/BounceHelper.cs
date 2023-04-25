using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour
{
    [Header("Animation")]
    public float scaleDuration = .2f;
    public float scaleBounce = 1.2f;
    public Ease ease = Ease.OutBack;

    [Header("Coroutine animation")]
    public AnimationCurve bounceUpCurve;
    public AnimationCurve bounceDownCurve;
    private Coroutine _scaleBounceAnimationCoroutine = null;

    public float initialScale;

    private int _firstFrameCounter = 0;
    private int _frameTarget = 5;

    private void Awake()
    {
        initialScale = transform.localScale.x;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Bounce();
            Debug.Log("E pressed");
        }
    }

    public void Bounce()
    {
        if (_scaleBounceAnimationCoroutine != null)
        {
            StopCoroutine(_scaleBounceAnimationCoroutine);
        }

        _scaleBounceAnimationCoroutine = StartCoroutine(ScaleBounceAnimationCoroutine(transform.localScale.x, scaleBounce, bounceUpCurve, BounceBack));

    }

    public void BounceBack()
    {
        _scaleBounceAnimationCoroutine = StartCoroutine(ScaleBounceAnimationCoroutine(transform.localScale.x, initialScale, bounceDownCurve));
    }


    private IEnumerator ScaleBounceAnimationCoroutine(float initialScale, float targetScale, AnimationCurve curve, System.Action callback = null)
    {
        float distance = targetScale - initialScale;
        int direction = distance > 0 ? 1 : -1;
        distance = Mathf.Abs(distance);

        float timeCounter = 0;
        float currentProportion;
        float currentValue;

        while (timeCounter < scaleDuration)
        {
            yield return null;
            timeCounter += Time.deltaTime;

            currentProportion = timeCounter / scaleDuration;
            currentValue = curve.Evaluate(currentProportion);

            transform.localScale = Vector3.one * initialScale + Vector3.one * distance * direction * currentValue;

        }
        yield return null;

        transform.localScale = Vector3.one * targetScale;

        callback?.Invoke();

    }

    public void BSSolution()
    {
        

        if (_firstFrameCounter < _frameTarget)
        {
            _firstFrameCounter++;
        }
        else if (_firstFrameCounter == _frameTarget)
        {
            transform.localScale = Vector3.one * initialScale;
            _firstFrameCounter++;
        }
        else
        {
            _firstFrameCounter = _frameTarget + 1;
        }

    }
}
