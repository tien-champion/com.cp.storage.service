using System;
using UnityEngine;

namespace Champion
{
    public class BaseDataSO : ScriptableObject
    {
        public DataEncryptionType Encrypt = DataEncryptionType.Json;

        public virtual void Save()
        {
        }

        public virtual void SaveAsync(Action<bool> result = null)
        {
            
        }

        public virtual void Load()
        {
        }

        public virtual void Delete()
        {
        }

        public virtual void ResetData()
        {

        }

        public virtual void SetupTest()
        {

        }
    }
}