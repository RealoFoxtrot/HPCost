using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utility class for caching resources loaded through Resources.Load().
/// </summary>
static class QuickLoad
{
    private static Dictionary<string, Object> CachedResources = new Dictionary<string, Object>();

    /// <summary>
    /// Loads the specified resource or returns a cached version if it has been loaded previously.
    /// </summary>
    /// <typeparam name="T">The type of resource you want to load.</typeparam>
    /// <param name="resource_path">The path of the resource relative to the Assets/Resources folder.</param>
    public static T Load<T>(string resource_path) where T : Object
    {
        if (CachedResources.ContainsKey(resource_path))
        {
            return CachedResources[resource_path] as T;
        }

        T resource = Resources.Load<T>(resource_path);
        CachedResources.Add(resource_path, resource);
        return resource;
    }
}
