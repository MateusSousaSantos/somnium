using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using CodeMonkey.Utils;

public class Casing_bullet : MonoBehaviour
{
    private const int max_quad = 15000;
    private Mesh Mesh;
    private Vector3[] vertices;
    private Vector2[] uv;
    private int[] triangles;
    public GameObject spawn_position;

    private int quadIndex;

    private void Awake()
    {
        Mesh = new Mesh();

        vertices = new Vector3[4 * max_quad];
        uv = new Vector2[4 * max_quad];
        triangles = new int[6 * max_quad];


        Mesh.vertices = vertices;
        Mesh.uv = uv;
        Mesh.triangles = triangles;

        GetComponent<MeshFilter>().mesh = Mesh;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3 quadSize = new Vector3(0.7f, 0.7f);
            float rotation = 0f;
            int spawnedQuadIndex = addquad(spawn_position.transform.position,rotation,quadSize,true);

            Vector3 quadPosition = spawn_position.transform.position;
            FunctionUpdater.Create(() =>{

                quadPosition += new Vector3(1, 1) * Time.deltaTime;
                updateQuad(spawnedQuadIndex, quadPosition, 0f, new Vector3(0.5f, 0.5f),true);
            }
            );
            
        }
    }
    public int addquad(Vector3 position , float rotation, Vector3 quadSize, bool skewd)
    {


        updateQuad(quadIndex, position,rotation,quadSize, skewd);

        int spawnedQuadIndex = quadIndex;
        quadIndex++;

        return spawnedQuadIndex;

    }

    public void updateQuad( int quadIndex, Vector3 position, float rotation, Vector3 quadSize, bool skewd)
    {
        if (quadIndex >= max_quad) return; // mesh full

        // Relocate vertices
        int vIndex = quadIndex * 4;
        int vIndex0 = vIndex;
        int vIndex1 = vIndex + 1;
        int vIndex2 = vIndex + 2;
        int vIndex3 = vIndex + 3;

        Vector3 quadsize = new Vector3(1, 1);
       

        // Use spawn_position's position as the reference
        Vector3 spawnPosition = spawn_position.transform.position;
        if(skewd)
        {
            vertices[vIndex0] = position + Quaternion.Euler(0, 0, rotation ) * new Vector3(-quadSize.x, -quadsize.y);
            vertices[vIndex1] = position + Quaternion.Euler(0, 0, rotation ) * new Vector3(-quadSize.x, +quadsize.y); ;
            vertices[vIndex2] = position + Quaternion.Euler(0, 0, rotation ) * new Vector3(+quadSize.x, +quadsize.y); ;
            vertices[vIndex3] = position + Quaternion.Euler(0, 0, rotation ) * new Vector3(+quadSize.x, -quadsize.y); ;
        }
        else
        {
            vertices[vIndex0] = position + Quaternion.Euler(0, 0, rotation - 180) * quadsize;
            vertices[vIndex1] = position + Quaternion.Euler(0, 0, rotation - 270) * quadsize;
            vertices[vIndex2] = position + Quaternion.Euler(0, 0, rotation - 0) * quadsize;
            vertices[vIndex3] = position + Quaternion.Euler(0, 0, rotation - 90) * quadsize;
        }


        // UV coordinates

        uv[vIndex0] = new Vector2(0, 0);
        uv[vIndex1] = new Vector2(0, 1);
        uv[vIndex2] = new Vector2(1, 1);
        uv[vIndex3] = new Vector2(1, 0);

        // Create triangles

        int tIndex = quadIndex * 6;

        triangles[tIndex + 0] = vIndex0;
        triangles[tIndex + 1] = vIndex1;
        triangles[tIndex + 2] = vIndex2;

        triangles[tIndex + 3] = vIndex0;
        triangles[tIndex + 4] = vIndex2;
        triangles[tIndex + 5] = vIndex3;



        Mesh.vertices = vertices;
        Mesh.uv = uv;
        Mesh.triangles = triangles;

        Mesh.RecalculateBounds();
    }
    
        
    


}
