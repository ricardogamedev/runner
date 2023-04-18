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

    public float initialScale;

    private int _firstFrameCounter = 0;
    private int _frameTarget = 5;

    private void Awake()
    {
        initialScale = transform.localScale.x;
    }

    private void Update()
    {
        BSSolution();
    }

    public void Bounce()
    {
        transform.DOScale(scaleBounce, scaleDuration).SetEase(ease).SetLoops(2, LoopType.Yoyo);
    }


    public void BSSolution()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Bounce();
        }

        if (_firstFrameCounter < _frameTarget)
        {
            _firstFrameCounter ++;
        }
        else if (_firstFrameCounter == _frameTarget)
        {
            transform.localScale = Vector3.one * initialScale;
            _firstFrameCounter ++;
        }
        else
        {
            _firstFrameCounter = _frameTarget + 1;
        }

    }
}
