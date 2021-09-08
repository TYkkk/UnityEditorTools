using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CreatePngTexture
{
    [MenuItem("Tools/Texture/CreatePngTexture")]
    public static void CreatePng()
    {
        var objs = Selection.objects;

        if (objs.Length == 0)
        {
            return;
        }

        for (int i = 0; i < objs.Length; i++)
        {
            string path = AssetDatabase.GetAssetPath(objs[i]);
            Texture2D tex = AssetDatabase.LoadAssetAtPath<Texture2D>(path);

            Color[] pixels = tex.GetPixels();

            for (int j = 0; j < pixels.Length; j++)
            {
                if (pixels[j] == Color.green || pixels[j].r < 0.5f || pixels[j] == Color.black)
                {
                    pixels[j] = new Color(0, 0, 0, 0);
                }
            }

            Texture2D ntex = new Texture2D(tex.width, tex.height, TextureFormat.ARGB32, false);
            ntex.SetPixels(pixels);
            ntex.Apply();

            File.WriteAllBytes($"{Application.dataPath}/result{i}.png", ntex.EncodeToPNG());

            AssetDatabase.Refresh();
        }
    }
}
