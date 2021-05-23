using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AllyPanel : MonoBehaviour
{
    RectTransform rectTransform;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void MovePanel(int direction)
    {
        rectTransform.DOAnchorPosX(direction * 140, 2).SetEase(Ease.InCubic);    
    }
}
