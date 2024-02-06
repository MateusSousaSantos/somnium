using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    public Transform firepoint;
    private Mesh mesh;
    public Vector3 origin;
    private float fov;
    private float startingAngle;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        fov = 90f;
    }

    void LateUpdate()
    {
        SetOrigin(firepoint.transform.position);
        SetAimDirection(UtilsClass.GetMouseWorldPosition());
        rays();
    }

    void rays()
    {
        int raycount = 50;
        float angle = startingAngle;
        float angleIncrease = fov / raycount;
        float viewDistance = 25f;

        Vector3[] vertices = new Vector3[raycount + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[raycount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= raycount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit = Physics2D.Raycast(origin, UtilsClass.GetVectorFromAngle(angle), viewDistance, layerMask);
            if (raycastHit.collider == null)
            {
                Debug.DrawLine(origin, raycastHit.point);
                vertex = origin + UtilsClass.GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                Debug.DrawLine(origin, raycastHit.point);
                vertex = raycastHit.point;
            }
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        startingAngle = UtilsClass.GetAngleFromVectorFloat(aimDirection) - fov / 2f;
    }
}
