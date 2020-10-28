using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// 通过修改UVRect实现Image下的Tiled效果（Image的Tiled效果会产生过多三角面和顶点）
/// </summary>
[AddComponentMenu("UI/TiledImage")]
public class TiledImage : RawImage
{
    protected override void OnRectTransformDimensionsChange()
    {
        base.OnRectTransformDimensionsChange();
        Vector2 size = rectTransform.rect.size;
        this.uvRect = new Rect(0, 0, size.x / texture.width * canvas.scaleFactor, size.y / texture.height * canvas.scaleFactor);
    }
}