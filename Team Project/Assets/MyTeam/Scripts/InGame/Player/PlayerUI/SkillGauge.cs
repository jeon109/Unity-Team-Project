﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ColorZone
{
    float startPos;
    float endPos;

    public ColorZone(RectTransform tr)
    {
        startPos = tr.localPosition.x;
        endPos = startPos + tr.sizeDelta.x;
    }
    
    public bool CheckInZone(float pos)
    {
        if (pos < endPos && pos > startPos)
            return true;
        return false;
    }
}

public enum COLORZONE
{
    NONE,GREEN,YELLOW,RED
}

public class SkillGauge : MonoBehaviour
{
    public RectTransform Green;
    public RectTransform Yellow;
    public RectTransform Red;

    private ColorZone greenZone;
    private ColorZone yellowZone;
    private ColorZone redZone;

    public RectTransform Ticktok;
    [SerializeField]
    float ticktokSpeed = 10f;
    float endPos;

    public COLORZONE zone;

    [SerializeField]
    float followDistX = 42f;
    [SerializeField]
    float followDistY = 27f;

    private void Start()
    {
        greenZone = new ColorZone(Green);
        yellowZone = new ColorZone(Yellow);
        redZone = new ColorZone(Red);

        endPos = GetComponent<RectTransform>().sizeDelta.x;
    }

    

    private void FollowPlayer(Vector2 pos)
    {
        pos.x -= followDistX;
        pos.y += followDistY;
        transform.position = pos;
    }

    private void OnEnable()
    {
        Ticktok.localPosition = Vector3.zero;
        zone = COLORZONE.NONE;
    }

    private void Update()
    {
        TicktokMove();
        CheckZone();
    }

    void TicktokMove()
    {
        Vector2 pos = Ticktok.localPosition;
        pos.x += ticktokSpeed * Time.deltaTime;
        Ticktok.localPosition = pos;
        if (pos.x > endPos)
        {
            gameObject.SetActive(false);
            UIEventToGame.Instance.OnPlayerDelay();
        }
    }

    void CheckZone()
    {
        float x = Ticktok.localPosition.x;
        if (redZone.CheckInZone(x))
            zone = COLORZONE.RED;
        else if (yellowZone.CheckInZone(x))
            zone = COLORZONE.YELLOW;
        else if (greenZone.CheckInZone(x))
            zone = COLORZONE.GREEN;
        else
            zone = COLORZONE.NONE;
    }
    
}
