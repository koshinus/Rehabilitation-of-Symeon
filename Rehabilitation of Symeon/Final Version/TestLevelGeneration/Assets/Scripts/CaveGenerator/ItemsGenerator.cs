using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsGenerator : MonoBehaviour
{
    public List<GameObject> gen_items;
    public List<int> items_counts;

    public void GenerateItems(List<Vector3> vertices, List<List<int>> outlines, int[,] borderedMap, float squareSize)
    {
        List<Vector2> ground_wall_vertices = new List<Vector2>();
        List<Vector2> ground_wall_next_vertices = new List<Vector2>();
        float eps = 1e-3f;

        foreach (var outline in outlines)
        {
            for (int counter = 0; counter < outline.Count - 1; ++counter)
                if (System.Math.Abs(vertices[outline[counter]].z - vertices[outline[counter + 1]].z) < eps)
                {
                    int index_x = (int)System.Math.Round(vertices[outline[counter]].x / squareSize + 0.5f * (borderedMap.GetLength(0) - 1));
                    int index_y = (int)System.Math.Round(vertices[outline[counter]].z / squareSize + 0.5f * (borderedMap.GetLength(1) - 1));

                    // -----
                    if (index_x < 0)
                        index_x = 0;
                    else
                    if (index_x > (borderedMap.GetLength(0) - 2))
                        index_x = borderedMap.GetLength(0) - 2;

                    if (index_y < 0)
                        index_y = 0;
                    else
                    if (index_y > (borderedMap.GetLength(1) - 2))
                        index_y = borderedMap.GetLength(1) - 2;
                    // -----

                    if ((borderedMap[index_x, index_y + 1] == 0) && (borderedMap[index_x, index_y - 1] == 1))
                    {
                        ground_wall_vertices.Add(new Vector2(vertices[outline[counter]].x, vertices[outline[counter]].z));


                        if ((ground_wall_next_vertices.Count > 0) && (ground_wall_vertices[ground_wall_vertices.Count - 1] == ground_wall_next_vertices[ground_wall_next_vertices.Count - 1]))
                        {
                            ground_wall_vertices.RemoveAt(ground_wall_vertices.Count - 1);
                            continue;
                        }

                        ground_wall_next_vertices.Add(new Vector2(vertices[outline[counter + 1]].x, vertices[outline[counter + 1]].z));
                    }


                }
        }

        System.Random rnd = new System.Random();


        for (int counter_1 = 0; counter_1 < gen_items.Count; ++counter_1)
            for (int counter_2 = 0; counter_2 < items_counts[counter_1]; ++counter_2)
            {
                //Vector2 vertical_offset = new Vector2(0f, gen_items[counter_1].GetComponent<Renderer>().bounds.size.y / 2);
                Vector2 vertical_offset = new Vector2(0f, gen_items[counter_1].GetComponent<BoxCollider2D>().size.y / 2);
                int rnd_index = rnd.Next(ground_wall_vertices.Count);

                gen_items[counter_1].transform.position = 0.5f * (ground_wall_vertices[rnd_index] + ground_wall_next_vertices[rnd_index]) + vertical_offset;

                ground_wall_vertices.RemoveAt(rnd_index);
                ground_wall_next_vertices.RemoveAt(rnd_index);

                GameObject item = Instantiate(gen_items[counter_1]);
                item.name = "Item_" + counter_1.ToString() + "_" + counter_2.ToString();
            }
    }
}
