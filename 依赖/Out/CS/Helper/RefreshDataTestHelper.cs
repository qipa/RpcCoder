﻿#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;





public class RefreshDataTestHelper : MonoBehaviour
{




}

[CustomEditor(typeof(RefreshDataTestHelper))]
public class RefreshDataTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        


    }

}
#endif