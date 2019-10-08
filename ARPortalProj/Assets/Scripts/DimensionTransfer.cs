using UnityEngine;
using UnityEngine.Rendering;

public class DimensionTransfer : MonoBehaviour
{
    public Material[] materials;

    public Transform device;

    bool wasInFront;
    bool inOtherWorld;
    bool hasCollided;

    void Start()
    {
        SetMaterials(false);
    }

    void Update()
    {
        WhileCameraColliding();
    }

    private void OnDestroy()
    {
        SetMaterials(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform != device)
        {
            return;
        }
        hasCollided = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != device)
        {
            return;
        }

        wasInFront = GetIsInFront();
        hasCollided = true;
    }

    bool GetIsInFront()
    {
        //Get the actual position of the near clipping plane so that the transition into the portal doesn't flicker
        Vector3 worldPos = device.position + device.forward * Camera.main.nearClipPlane;

        Vector3 position = transform.InverseTransformPoint(worldPos);
        return position.z >= 0 ? true : false;
    }

    void WhileCameraColliding()
    {
        if (!hasCollided)
        {
            return;
        }

        bool isInFront = GetIsInFront();

        if ((isInFront && !wasInFront) || (wasInFront && !isInFront))
        {
            inOtherWorld = !inOtherWorld;
            SetMaterials(inOtherWorld);
        }

        wasInFront = isInFront;
    }

    void SetMaterials(bool fullRender)
    {
        var stencilTest = fullRender ? CompareFunction.NotEqual : CompareFunction.Equal;
        Shader.SetGlobalInt("_StencilTest", (int)stencilTest);
        //foreach (var mat in materials)
        //{
        //    mat.SetInt("_StencilTest", (int)stencilTest);
        //}
    }

    
}
