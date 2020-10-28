using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 检测导致Canvas重建的原因
/// </summary>
public class CheckUICanvasRebuild : MonoBehaviour
{
    public Canvas canvas;

    IList<ICanvasElement> m_LayoutRebuildQueue;
    IList<ICanvasElement> m_GraphicRebuildQueue;

    private void Awake()
    {
        System.Type type = typeof(CanvasUpdateRegistry);
        FieldInfo field = type.GetField(nameof(m_LayoutRebuildQueue), BindingFlags.NonPublic | BindingFlags.Instance);
        m_LayoutRebuildQueue = (IList<ICanvasElement>)field.GetValue(CanvasUpdateRegistry.instance);
        field = type.GetField(nameof(m_GraphicRebuildQueue), BindingFlags.NonPublic | BindingFlags.Instance);
        m_GraphicRebuildQueue = (IList<ICanvasElement>)field.GetValue(CanvasUpdateRegistry.instance);
    }

    private void Update()
    {
        for (int i = 0; i < m_LayoutRebuildQueue.Count; i++)
        {
            var rebuild = m_LayoutRebuildQueue[i];
            if (ObjectVaildForUpdate(rebuild))
            {
                Debug.LogFormat("{0}引起{1}网格重建", rebuild.transform.name, rebuild.transform.GetComponent<Graphic>().canvas.name);
            }
        }

        for (int i = 0; i < m_GraphicRebuildQueue.Count; i++)
        {
            var rebuild = m_GraphicRebuildQueue[i];
            if (ObjectVaildForUpdate(rebuild))
            {
                Debug.LogFormat("{0}引起{1}网格重建", rebuild.transform.name, rebuild.transform.GetComponent<Graphic>().canvas.name);
            }
        }
    }

    private bool ObjectVaildForUpdate(ICanvasElement element)
    {
        var valid = element != null;

        var isUnityObject = element is Object;

        if (isUnityObject)
        {
            valid = (element as Object) != null;
        }

        return valid;
    }
}
