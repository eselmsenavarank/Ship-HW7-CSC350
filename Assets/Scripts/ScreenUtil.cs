using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenUtils {

    static float screenLeft, screenRight, screenTop, screenBottom;
    static int screenWidth, screenHight;

    public static void Initialize()
    {
        float screenz = -Camera.main.transform.position.z;
        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenz);
        Vector3 lowerLeftCornerWorld = Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 topRightCornerScreen = new Vector3(Screen.width, Screen.height, screenz);
        Vector3 topRightCornerWorld = Camera.main.ScreenToWorldPoint(topRightCornerScreen);
        screenLeft = lowerLeftCornerWorld.x;
        screenRight = topRightCornerWorld.x;
        screenTop = topRightCornerWorld.y;
        screenBottom = lowerLeftCornerWorld.y;
        Debug.Log(screenLeft + " " + screenRight + " " + screenTop + "" + screenBottom);
    }

    public static float ScreenLeft {
        get{ return screenLeft; }
    }
    public static float ScreenRight
    {
        get { return screenRight; }
    }
    public static float ScreenTop
    {
        get { return screenTop; }
    }
    public static float ScreenBottom
    {
        get { return screenBottom; }
    }
}
