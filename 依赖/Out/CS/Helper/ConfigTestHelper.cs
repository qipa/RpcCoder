﻿#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using GenPB;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;





public class ConfigTestHelper : MonoBehaviour
{




}

[CustomEditor(typeof(ConfigTestHelper))]
public class ConfigTester : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        


    }

}
#endif