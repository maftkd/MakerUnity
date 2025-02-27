using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumetricFog : MonoBehaviour
{
    [SerializeField]
    public Shader shader;
    private Material _mat;
    private Camera _cam;

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (_mat == null)
        {
            _mat = new Material(shader);
        }

        if (_cam == null)
        {
            _cam = GetComponent<Camera>();
        }
        
        Matrix4x4 inverseView = _cam.cameraToWorldMatrix;
        _mat.SetMatrix("_InverseView", inverseView);
        
        Graphics.Blit(src, dest, _mat);
    }
}
