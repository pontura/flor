using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Emoticon : MonoBehaviour {

    public int id;
    public bool isOn;
    private Image image;
    private float lastTimeOnScene;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        image = GetComponentInChildren<Image>();
    }
    public void HideIcon()
    {
        SetAudio(true);
        image.color = new Color(1, 1, 1, 0.3f);
    }
    public void ShowIcon()
    {
        SetAudio(false);
        image.enabled = true;
        image.color = new Color(1, 1, 1, 1);
    }
	public void UpdatePosition (Vector2 pos) {

        if (id == 2 && !isOn)
            Events.OnChangeBg(true);

        isOn = true;

        transform.localPosition = pos;
        lastTimeOnScene = Time.time;
        
	}
    void Update()
    {
        if (transform.localPosition.y > 999) return;
        if (Time.time > lastTimeOnScene + 1)
        {
            SetAudio(false);
            isOn = false;
            transform.localPosition = new Vector3(transform.localPosition.x, 1000, transform.localPosition.z);
            Events.OnChangeBg(false);
        }
    }
    void SetAudio(bool isOn)
    {
        if (audioSource != null)
        {
            if (isOn) audioSource.Play();
            else audioSource.Stop();
        }
    }
}
