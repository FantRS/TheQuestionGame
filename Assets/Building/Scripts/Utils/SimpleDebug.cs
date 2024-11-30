using UnityEngine;

public static class SimpleDebug
{
    /// <summary>
    /// Simple output of the current object to the Unity console
    /// </summary>
    public static void ConsoleWrite<T>(this T obj)
    {
        Debug.Log(obj);
    }
}