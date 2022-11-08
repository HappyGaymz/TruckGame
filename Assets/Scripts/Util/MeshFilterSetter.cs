using UnityEngine;

[ExecuteAlways]
public class MeshFilterSetter : MonoBehaviour
{
    public Mesh mesh;
    public MeshFilter filter;

    private void Update()
    {
        if (mesh != null && filter != null)
            filter.mesh = mesh;
    }
}
