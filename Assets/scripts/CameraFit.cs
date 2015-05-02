// Attach this script on your main camera

/* The MIT License (MIT)

Copyright (c) 2014, Marcel Căşvan

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE. */

using System;
using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CameraFit : MonoBehaviour
{
    public float spriteSize = 32f;
    public static CameraFit Instance;

    #region METHODS
    private void Awake()
    {
        try
        {
            if ((bool)GetComponent<Camera>())
            {
                if (GetComponent<Camera>().orthographic)
                {
                    ComputeResolution();
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }
    }

    private void ComputeResolution()
    {
        var camera = GetComponent<Camera>();

        if (camera == null)
        {
            return;
        }

        float deviceWidth = 0f;
        float deviceHeight = 0f;


#if UNITY_EDITOR
        deviceWidth = GetGameView().x;
        deviceHeight = GetGameView().y;
#else
        deviceWidth = Screen.width;
        deviceHeight = Screen.height;
#endif


        camera.aspect = deviceWidth/deviceHeight;
        camera.orthographicSize = deviceWidth / (((deviceWidth / deviceHeight) * 2f) * spriteSize);
        Instance = this;
    }

    private void Update()
    {
#if UNITY_EDITOR
        ComputeResolution();
#endif
    }

    private Vector2 GetGameView()
    {
        System.Type T = System.Type.GetType("UnityEditor.GameView,UnityEditor");
        System.Reflection.MethodInfo getSizeOfMainGameView =
        T.GetMethod("GetSizeOfMainGameView", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
        System.Object resolution = getSizeOfMainGameView.Invoke(null, null);
        return (Vector2)resolution;
    }
    #endregion
}
