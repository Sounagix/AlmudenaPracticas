using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMalote : Enemy
{
    protected override void NextPatrulla()
    {
        float t = 5.0f;
        eNEMY_STATE = ENEMY_STATE.PAUSE;
        GetComponent<Renderer>().material.color = Color.yellow;
        StartCoroutine(WaitTime(t));
    }

    protected override void InitPatrulla()
    {
        base.InitPatrulla();
        GetComponent<Renderer>().material.color = Color.blue;
    }
}
