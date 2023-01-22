using System.Collections;
using UnityEngine;

public class Utility : ScriptableObject
{
    public static T CopyComponent<T>(T original, GameObject destination) where T : Component
    {
        T comp = destination.GetComponent<T>();
        if(comp != null)
        {
            Destroy(comp);
        }
        var type = original.GetType();
        var copy = destination.AddComponent(type);
        var fields = type.GetFields();
        foreach (var field in fields) field.SetValue(copy, field.GetValue(original));
        return copy as T;
    }
}
