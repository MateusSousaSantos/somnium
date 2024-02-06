using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class scp_fov : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
   private Mesh mesh;
   private Vector3 origin;
   private float startingAngle;
   private float fov;
   public float viewDistance;
    void Start(){
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        origin = Vector3.zero;
        fov = 100f;
    }



    private void LateUpdate()
    {
        int raycount = 50;
        float angle = startingAngle;
        float angleIncrease = fov / raycount;

        Vector3[] vertices = new Vector3[raycount + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangle = new int[raycount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= raycount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit20 = Physics2D.Raycast(origin, UtilsClass.GetVectorFromAngle(angle), viewDistance,layerMask);
            if(raycastHit20.collider == null)
            {
                vertex = origin + UtilsClass.GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                vertex = raycastHit20.point;
                Debug.DrawLine(origin,raycastHit20.point);
            }
            vertices[vertexIndex] = vertex;
            if(i > 0)
            {
                triangle[triangleIndex + 0] = 0;
                triangle[triangleIndex + 1] = vertexIndex - 1;
                triangle[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangle;
        mesh.RecalculateBounds();


    }

    public void SetOringin(Vector3 origin)
    {
        this.origin = origin;
    }
    public void SetAimDirection(Vector3 aimDirection)
    {
        startingAngle = UtilsClass.GetAngleFromVectorFloat(aimDirection) + fov / 2f;
    }
    public void setFov(float fov)
    {
        this.fov = fov;
    }
    public void SetViewDistance(float viewDistance)
    {
        this.viewDistance = viewDistance;
    }
}
