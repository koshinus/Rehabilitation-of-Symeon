using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLocation : MonoBehaviour
{
    MapGenerator   map_gen;
    MeshGenerator  mesh_gen;
    ItemsGenerator items_gen;

    float squareSize = 1f;

    void GenerateAll()
    {
        map_gen.GenerateMap();

        // Euristic:)     
        int tileAmountForeground = map_gen.width / 16;

        int tileAmountBackgroundX = map_gen.width / 64;
        int tileAmountBackgroundY = map_gen.height / 64;

        mesh_gen.GenerateMesh(map_gen.borderedMap, squareSize, tileAmountBackgroundX, tileAmountBackgroundY, tileAmountForeground);
        items_gen.GenerateItems(mesh_gen.vertices, mesh_gen.outlines, map_gen.borderedMap, squareSize);

    }

	void Start ()
    {
        map_gen   = GetComponent<MapGenerator>();
        mesh_gen  = GetComponent<MeshGenerator>();
        items_gen = GetComponent<ItemsGenerator>();

        GenerateAll();
    }

    /*
    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GenerateAll();
        }
    }
    */
}
