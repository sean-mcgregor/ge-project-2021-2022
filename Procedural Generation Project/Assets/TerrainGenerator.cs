using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {

    public int terrain_depth = 10;          // Depth of terrain
    public int terrain_width = 256;         // Width of terrain
    public int terrain_height = 256;        // Height of terrain
    public float terrain_scale = 10f;       // Scale of terrain
    public float terrain_offset_x =  10f;   
    public float terrain_offset_y =  10f;


    // Start is called once when Play is pressed
    void Start() 
    {
        generateOffset(); // Shifts entire terrain when start is called
    }


    // Update is called once per frame
    void Update()
    {
        Terrain terrain =  GetComponent<Terrain>();                 // Getting terrain object
        terrain.terrainData = GenerateTerrain(terrain.terrainData); // Generating new terrain data
        terrain_offset_x = terrain_offset_x + 0.01f;
    }

    
    void generateOffset()
    {
        terrain_offset_x = Random.Range(0f, 50f);
        terrain_offset_y = Random.Range(0f, 200f);
    }


    // Returns a 2D array of heights
    float[,] GenerateHeights()
    {
        int yToSendValue = 0;
        float[,] heights = new float[terrain_width, terrain_height]; // new float array
        
        for (int x = 0; x < terrain_width; x++) {

            for (int y = 0; y < terrain_height; y++) {

                yToSendValue = y;

                if (x < 256){

                    yToSendValue = (y + 200);
                }

                heights[x,y] = CalculateHeights(x,yToSendValue); // Perlin noise values
            }

        }

        return heights;
    }


    float CalculateHeights (int x, int y)
    {
        float xCoordinate = ((float)x / terrain_width) * terrain_scale + terrain_offset_x;
        float yCoordinate = ((float)y / terrain_height) * terrain_scale + terrain_offset_y;

        return Mathf.PerlinNoise(xCoordinate, yCoordinate);
    }


    TerrainData GenerateTerrain(TerrainData data)
    {
        data.heightmapResolution = terrain_width + 1;
        data.size = new Vector3(terrain_width, terrain_depth, terrain_height); // Dimensions of terrain
        data.SetHeights(0, 0, GenerateHeights());

        return data;
    }
}