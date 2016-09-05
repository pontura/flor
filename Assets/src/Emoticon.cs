using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Emoticon : MonoBehaviour {

    public int id;
    private Image image;

    void Start()
    {
        image = GetComponentInChildren<Image>();
    }
    public void HideIcon()
    {
        image.color = new Color(1, 1, 1, 0.3f);
    }
    public void ShowIcon()
    {
        image.enabled = true;
        image.color = new Color(1, 1, 1, 1);
    }
	public void UpdatePosition (Vector2 pos) {
        transform.localPosition = pos;
	}
}
