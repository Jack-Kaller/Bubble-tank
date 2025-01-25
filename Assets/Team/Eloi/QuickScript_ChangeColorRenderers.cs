using UnityEngine;

public class QuickScript_ChangeColorRenderers : MonoBehaviour
{
    
    public Renderer[] m_renderers;


    public void PushInColor(Color color)
    {
        foreach (Renderer r in m_renderers)
        {
            if (r != null && r.material!=null)
                r.material.color = color;
        }
    }
}
