using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class shell_particle : MonoBehaviour
{
    public static shell_particle Instance { get; private set; }
    public GameObject spawn_position;

    private Casing_bullet casingBullet;
    private void Awake()
    {
        Instance = this;
    }
    public void spawnShell(Vector3 position, Vector3 direction)
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector3 quadSize = new Vector3(0.7f, 0.7f);
            float rotation = 0f;
            int spawnedQuadIndex = casingBullet.addquad(spawn_position.transform.position, rotation, quadSize, true);

            Vector3 quadPosition = spawn_position.transform.position;
            FunctionUpdater.Create(() => {

                quadPosition += new Vector3(1, 1) * Time.deltaTime;
                casingBullet.updateQuad(spawnedQuadIndex, quadPosition, 0f, new Vector3(0.5f, 0.5f), true);
            }
            );

        }
    }
}
