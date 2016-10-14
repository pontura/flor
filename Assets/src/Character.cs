using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Character : MonoBehaviour {

    public Image image;
    public int id;
    public Animator anim;
    public Animator iconAnimator;
    public states state;

    public Sprite happy;
    public Sprite enojado;
    public Sprite amor;
    public Sprite llora;

    private bool isHidden;

    public enum states
    {
        IDLE,
        HAPPY,
        ENOJADO,
        AMOR,
        LLORA,
        WALKING,
        JUMPING,
        HIDDEN
    }

    private float speed = 0;
    private float speedWalk = 50;

    void Update()
    {

        //////////Hiden:
        float alpha = image.color.a;
        if (isHidden)
        {
            alpha -= Time.deltaTime;
            if (alpha < 0) alpha = 0;
            image.color = new Color(1, 1, 1, alpha);
        }
        else if (alpha < 1)
        {
            alpha += Time.deltaTime;
            if (alpha > 1) alpha = 1;
            image.color = new Color(1, 1, 1, alpha);
        }
        /////////////

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

        if (right) speed = speedWalk; else speed = -speedWalk;

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
    public void hide()
    {
        if (state == states.HIDDEN) return;
        state = states.HIDDEN;
        isHidden = true;
        Invoke("Reset", 2);
    }
    public void Happy()
    {
        if (id == 4) return;
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
        if (id == 4) return;
        if (state == states.ENOJADO) return;
        state = states.ENOJADO;

        iconAnimator.GetComponentInChildren<Image>().sprite = enojado;
        iconAnimator.gameObject.SetActive(true);
        anim.Play("enojado");
        iconAnimator.Play("icon_happy");
        Invoke("Reset", 1);
    }
    public void Amor()
    {
        if (id == 4) return;
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
        if (id == 4) return;
        if (state == states.LLORA) return;
        state = states.LLORA;

        iconAnimator.GetComponentInChildren<Image>().sprite = llora;
        iconAnimator.gameObject.SetActive(true);
        anim.Play("llora");
        iconAnimator.Play("icon_happy");
        Invoke("Reset", 1);
    }
    void Reset()
    {
        isHidden = false;
        Idle();
    }
    private bool CanMove()
    {
        Vector2 pos = transform.localPosition;
        
        if (transform.localPosition.x > 340)
        {
            pos.x -= 1f;
            transform.localPosition = pos;
            return false;
        }
        else if (transform.localPosition.x < -340)
        {
            pos.x += 1f;
            transform.localPosition = pos;
            return false;
        }
        return true;
    }
}
