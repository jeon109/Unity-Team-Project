﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcFSM : MonoBehaviour
{
    private Npc npc;
    Vector3 originPos;
    [SerializeField] int talk_id;
    [SerializeField] int next_talk_id;

    private bool trigger =false;

    void Start()
    {
        npc = GetComponent<Npc>();
       // NpcSetting();
        GameEventToUI.Instance.player_Trigger += isTrigger;
       

    }
    /*
        private void NpcSetting()
        {
            npc.npcState = State.NpcState.N_Idle;
            npc.animator = GetComponent<Animator>();
        }

        private void Update()
        {
            switch (npc.npcState)
            {
                case State.NpcState.N_Idle:
                    Idle();
                    break;
            }
        }

        private void Idle()
        {

        }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Vector3 pos = other.gameObject.transform.position - gameObject.transform.position;
            pos.y = 0;

            gameObject.transform.LookAt(gameObject.transform.position + pos);
            GameEventToUI.Instance.OnEventTalkBtn(true);
            GameEventToUI.Instance.talk_box += return_Talk_id;
            trigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            GameEventToUI.Instance.OnEventTalkBtn(false);
            GameEventToUI.Instance.talk_box -= return_Talk_id;
            trigger = false;
        }
    }

    public bool isTrigger()
    {
        return trigger;
    }

    public int return_Talk_id()
    {
        return talk_id;
    }
}
