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
        //transform.localPosition = pos;
	}

    void Update()
    {
        //PointerEventData pointer = new PointerEventData(EventSystem.current);
        //pointer.position = transform.position;

        //List<RaycastResult> raycastResults = new List<RaycastResult>();
        //EventSystem.current.RaycastAll(pointer, raycastResults);

        //if (raycastResults.Count > 0)
        //{
        //    if (raycastResults[0].gameObject.tag == "Character")
        //    {
        //        Character character = raycastResults[0].gameObject.GetComponentInParent<Character>();
        //        print(character.id);
        //    }
        //}
    }
}
