using UnityEditor;
using UnityEngine;

public static class SpacingTools
{
    // 菜单：Edit -> 选中物体沿X轴等距散开
    [MenuItem("Edit/沿X轴等距散开 %#&X")] // 快捷键 Ctrl+Shift+Alt+X
    public static void SpaceAlongX()
    {
        SpaceSelectedObjects(Vector3.right, 5f);
    }

    [MenuItem("Edit/沿Z轴等距散开 %#&Z")] // Ctrl+Shift+Alt+Z
    public static void SpaceAlongZ()
    {
        SpaceSelectedObjects(Vector3.forward, 5f);
    }

    static void SpaceSelectedObjects(Vector3 dir, float spacing)
    {
        var objs = Selection.gameObjects;
        if (objs == null || objs.Length < 2) return;

        Undo.RecordObjects(objs, "散开物体"); // 支持Ctrl+Z撤销

        Vector3 startPos = objs[0].transform.position;
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].transform.position = startPos + dir * spacing * i;
        }
    }
}