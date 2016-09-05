﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Vuforia;

public class UI : MonoBehaviour {

    private Vector2 totalScreenSize; // = new Vector2(1024, 768);
    private Vector2 canvasSize = new Vector2(800, 600);
    public Text debbugText;
    private EmoticonsManager emoticonsManager;

    public RectTransform canvas;
    public Camera camera;

    void Start()
    {
        totalScreenSize = new Vector2(Screen.width, Screen.height);
        emoticonsManager = GetComponent<EmoticonsManager>();
    }
    void Update()
    {
        StateManager sm = TrackerManager.Instance.GetStateManager();
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();

        string content = "";
        foreach (TrackableBehaviour tb in activeTrackables)
        {
            Vector2 vec = GetPosition(tb);
            string _name = tb.TrackableName;
         //   content +=  _name + " x: " + vec.x + " y: " + vec.y + "    ";
            int num = int.Parse(_name);
           // int num = 1;
            emoticonsManager.OnUpdatePositions(num, vec);
        }
        if (content == "")
        {
            //  debbugText.text = ": " + Time.time;
        }
        else
        {
            //  debbugText.text = content;
        }
    }
    Vector2 GetPosition(TrackableBehaviour targetImage)
    {
        Vector3 pointOnTarget = targetImage.transform.position;

        return WorldToCanvasPosition(pointOnTarget);


        //Vector3 targetPointInWorldRef = transform.TransformPoint(pointOnTarget);
        //Vector3 screenPoint = Camera.main.WorldToScreenPoint(targetPointInWorldRef);

        //float _x = ((screenPoint.x * canvasSize.x) / totalScreenSize.x) / 2;
        //float _y = ((screenPoint.y * canvasSize.y) / totalScreenSize.y)/2;

        //return new Vector2(_x, _y - (canvasSize.y/2));
    }

    private Vector2 WorldToCanvasPosition(Vector3 position)
    {
        //Vector position (percentage from 0 to 1) considering camera size.
        //For example (0,0) is lower left, middle is (0.5,0.5)
        Vector2 temp = camera.WorldToViewportPoint(position);

        //Calculate position considering our percentage, using our canvas size
        //So if canvas size is (1100,500), and percentage is (0.5,0.5), current value will be (550,250)
        temp.x *= canvas.sizeDelta.x;
        temp.y *= canvas.sizeDelta.y;

        //The result is ready, but, this result is correct if canvas recttransform pivot is 0,0 - left lower corner.
        //But in reality its middle (0.5,0.5) by default, so we remove the amount considering cavnas rectransform pivot.
        //We could multiply with constant 0.5, but we will actually read the value, so if custom rect transform is passed(with custom pivot) , 
        //returned value will still be correct.

        temp.x -= canvas.sizeDelta.x * canvas.pivot.x;
        temp.y -= canvas.sizeDelta.y * canvas.pivot.y;

        return temp;
    }
}
