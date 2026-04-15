using UnityEditor;
using UnityEngine;

public static class GridTools
{
    [MenuItem("Edit/排列成网格(行列) %#&G")]
    public static void ArrangeInGrid()
    {
        var objs = Selection.gameObjects;
        if (objs == null || objs.Length == 0) return;

        Undo.RecordObjects(objs, "排列成网格");

        int count = objs.Length;
        int cols = Mathf.CeilToInt(Mathf.Sqrt(count)); // 自动算列数
        float spacing = 6f;

        for (int i = 0; i < count; i++)
        {
            int x = i % cols;
            int z = i / cols;
            objs[i].transform.position = new Vector3(x * spacing, 0, z * spacing);
        }
    }
}