using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Extensions
{
    public static class SceneExtensions
    {
        public static List<GameObject> FindAllTypeInScene(this Scene scene, Type T)
        {
            var allGameObjects = scene.GetRootGameObjects().ToList();

            var validGameObjects = new List<GameObject>();
            foreach (var gameObject in allGameObjects)
            {
                if (gameObject.GetType() != T)
                    continue;

                validGameObjects.Add(gameObject);
            }

            return validGameObjects;
        }

        public static List<GameObject> FindAllGameObjectsWithTag(this Scene scene, string tag)
        {
            var allGameObjects = scene.GetRootGameObjects().ToList();

            var validGameObjects = new List<GameObject>();
            foreach (var gameObject in allGameObjects)
            {
                if (gameObject.CompareTag(tag))
                    validGameObjects.Add(gameObject);
            }

            return validGameObjects;
        }
    }
}
