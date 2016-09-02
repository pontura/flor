﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Character : MonoBehaviour {

    public int id;
    public Animator anim;
    public Animator iconAnimator;
    public states state;

    public Sprite happy;
    public Sprite enojado;
    public Sprite amor;
    public Sprite llora;

    public enum states
    {
        IDLE,
        HAPPY,
        ENOJADO,
        AMOR,
        LLORA,
        WALKING,
        JUMPING
    }
    public float speed = 0;
    void Update()
    {
        if (state != states.WALKING) return;
        print(transform.localPosition.x);
        if (!CanMove())
        {
            Idle();
            return;
        }
        Vector2 pos = transform.localPosition;
        pos.x += Time.deltaTime * speed;
        transform.localPosition = pos;
    }
    public void Idle()
    {
        if (state == states.IDLE) return;
        state = states.IDLE;
        speed = 0;
        iconAnimator.gameObject.SetActive(false);
        anim.Play("idle");
    }
    public void Walk(bool right)
    {
        if (!CanMove()) return;
        if (state == states.WALKING) return;
        state = states.WALKING;

        if (right) speed = 20; else speed = -20;

        anim.Play("walk",0,0);
        Invoke("Reset", 4);
    }
    public void jump()
    {
        if (state == states.JUMPING) return;
        state = states.JUMPING;

        anim.Play("jump", 0, 0);
        Invoke("Reset", 2);
    }
    public void Happy()
    {
        if (state == states.HAPPY) return;
        state = states.HAPPY;

        iconAnimator.GetComponentInChildren<Image>().sprite = happy;
        iconAnimator.gameObject.SetActive(true);
        anim.Play("happy");
        iconAnimator.Play("icon_happy");
        Invoke("Reset", 1);
    }
    public void Enojado()
    {
        if (state == states.ENOJADO) return;
        state = states.ENOJADO;

        iconAnimator.GetComponentInChildren<Image>().sprite = enojado;
        iconAnimator.gameObject.SetActive(true);
        anim.Play("happy");
        iconAnimator.Play("icon_happy");
        Invoke("Reset", 1);
    }
    public void Amor()
    {
        if (state == states.AMOR) return;
        state = states.AMOR;

        iconAnimator.GetComponentInChildren<Image>().sprite = amor;
        iconAnimator.gameObject.SetActive(true);
        anim.Play("happy");
        iconAnimator.Play("icon_happy");
        Invoke("Reset", 1);
    }
    public void Llora()
    {
        if (state == states.LLORA) return;
        state = states.LLORA;

        iconAnimator.GetComponentInChildren<Image>().sprite = llora;
        iconAnimator.gameObject.SetActive(true);
        anim.Play("happy");
        iconAnimator.Play("icon_happy");
        Invoke("Reset", 1);
    }
    void Reset()
    {
        Idle();
    }
    private bool CanMove()
    {
        if (transform.localPosition.x > 310 || transform.localPosition.x < -310)
            return false;
        return true;
    }
}
