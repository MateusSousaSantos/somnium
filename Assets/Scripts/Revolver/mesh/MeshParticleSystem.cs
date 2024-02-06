using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MeshParticleSystem : MonoBehaviour
{
    
    private const int Max_quad_amount = 15000;
    private Mesh Mesh;

    [SerializeField] private PlayerAim characterAimHandler;

    private Vector3[] vertices;
    private Vector2[] uv;
    private int[] triangles;

    private int quadIndex;
    private void Awake()
    {
        Mesh = new Mesh();

        vertices = new Vector3[4 * Max_quad_amount];
        uv = new Vector2[4 * Max_quad_amount];
        triangles = new int[6 * Max_quad_amount];

       
        
        Mesh.vertices = vertices;
        Mesh.uv = uv;
        Mesh.triangles = triangles;
        GetComponent<MeshFilter>().mesh = Mesh;
    }


    public void AddQuad(Vector3 position )
    {
        if (quadIndex >= Max_quad_amount) return; //mesh full
        int vIndex = quadIndex * 4;
        int vIndex0 = vIndex;
        int vIndex1 = vIndex+1;
        int vIndex2 = vIndex+2;
        int vIndex3 = vIndex+3;

        Vector3 quadSize = new Vector3(1, 1);
        float rotation = 0f;
        vertices[vIndex0] = position + Quaternion.Euler(0, 0, rotation - 180) * quadSize;
        vertices[vIndex1] = position + Quaternion.Euler(0, 0, rotation - 270) * quadSize;
        vertices[vIndex2] = position + Quaternion.Euler(0, 0, rotation - 0) * quadSize;
        vertices[vIndex3] = position + Quaternion.Euler(0, 0, rotation - 90) * quadSize;

        uv[vIndex0] = new Vector2(0,0);
        uv[vIndex1] = new Vector2(0,1);
        uv[vIndex2] = new Vector2(1,1);
        uv[vIndex3] = new Vector2(1,0);


        int tIndex = quadIndex * 6;

        triangles[tIndex + 0] = vIndex0;
        triangles[tIndex + 1] = vIndex1;
        triangles[tIndex + 2] = vIndex2;

        triangles[tIndex + 3] = vIndex3;
        triangles[tIndex + 4] = vIndex0;
        triangles[tIndex + 5] = vIndex2;

        quadIndex++;

        Mesh.vertices = vertices;
        Mesh.uv = uv;
        Mesh.triangles = triangles;
    }
}
