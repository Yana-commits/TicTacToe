using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Mark : MonoBehaviour , IPointerDownHandler
{
    private Image image;
    private int index;
    private TicTacMark mark = TicTacMark.None;
    private int score =100;


    public Action<Mark> OnClic;

    public TicTacMark CurMark { get => mark; set => mark = value; }
    public Image Image { get => image; set => image = value; }
    public int Index { get => index; set => index = value; }
    public int Score { get => score; set => score = value; }

    public void Init(int _index)
    {
        Image = GetComponent<Image>();
        Index = _index;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OnClic?.Invoke(this);
    }

}

