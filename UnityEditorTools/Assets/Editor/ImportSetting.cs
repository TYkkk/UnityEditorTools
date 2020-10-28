using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 资源导入设置
/// </summary>
public class ImportSetting : AssetPostprocessor
{
    public void OnPreprocessTexture()
    {
        Debug.Log("Start Import Texture:" + this.assetPath);
        TextureImporter tex = this.assetImporter as TextureImporter;
        tex.mipmapEnabled = false;
    }

    public void OnPostprocessTexture(Texture2D tex)
    {
        Debug.Log("Import Texture End:" + this.assetPath);
    }

    public void OnPreprocessModel()
    {
        Debug.Log("Start Import Model:" + this.assetPath);
        ModelImporter model = this.assetImporter as ModelImporter;
    }

    public void OnPostprocessModel(GameObject model)
    {
        Debug.Log("Import Model End:" + this.assetPath);
    }

    public void OnPreprocessAudio()
    {

    }

    public void OnPostprocessAudio(AudioClip clip)
    {

    }
}
