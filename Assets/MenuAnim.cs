using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class MenuAnim : MonoBehaviour
{
    public float duration;
    public float textDuration;

    [SerializeField] private Text coin;
    [SerializeField] private Text gem;
    [SerializeField] private Slider coinSlider;
    [SerializeField] private Slider gemSlider;
    [SerializeField] private Button noticeButton;
    [SerializeField] private Image notification;

    private int coinTarget;
    private int gemTarget;
    private void Start()
    {
        coinTarget = Random.Range(1000, 6000);
        gemTarget = Random.Range(20, 100);

        transform.localScale = Vector3.zero;
    }

    public void Open()
    {
        coinSlider.value = 0;
        gemSlider.value = 0;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(Vector3.one, duration)).AppendCallback(QuantityDisplay);

        noticeButton.GetComponent<Button>().enabled = false;

    }

    public void Close()
    {
        transform.DOScale(Vector3.zero, duration);
        noticeButton.GetComponent<Button>().enabled = true;
        
    }

    private void QuantityDisplay()
    {
        int currentCoin = 0;
        int currentGem = 0;

        Tween c = DOTween.To(() => currentCoin, x => currentCoin = x, coinTarget, textDuration).OnUpdate(() => coin.text = currentCoin.ToString());
        coinSlider.DOValue(coinTarget, textDuration);

        Tween g = DOTween.To(() => currentGem, x => currentGem = x, gemTarget, textDuration).OnUpdate(() => gem.text = currentGem.ToString());
        gemSlider.DOValue(gemTarget, textDuration);
    }

}
