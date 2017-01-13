using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rhythmicdote
{
    public class SaveManager : MonoBehaviour
    {
        static bool save;
        void Start()
        {
            save = false;
        }
        void Update()
        {
            if (save)
            {
                save = false;
                PlayerPrefs.Save();
            }
        }
        public static void SaveToDisk()
        {
            save = true;
        }
    }
}
