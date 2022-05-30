using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    public float duration;
    public float scaleSize;

    private void Start()
    {
        Blip();
    }
    public void Blip()
    {
        transform.DOScale(Vector3.one * scaleSize, duration).SetLoops(-1, LoopType.Yoyo);
    }
}
