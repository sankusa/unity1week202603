using System;
using ShirohataLib.Basic;
using UnityEngine;

namespace ShirohataLabo.u1w202603
{
    [Serializable]
    public class SaveData
    {
        const string _saveKey = "ShirohataLabo_u1w202603";
        [SerializeField] Wisdom _wisdom;

        public SaveData(Wisdom wisdom)
        {
            _wisdom = wisdom;
            JsonSave.logOutput = true;
        }

        public void Save()
        {
            JsonSave.Save(_saveKey, this);
        }

        public void LoadOverWrite()
        {
            JsonSave.LoadOverWrite(_saveKey, this);
        }

        public bool HasKey()
        {
            return PlayerPrefs.HasKey(_saveKey);
        }
    }
}