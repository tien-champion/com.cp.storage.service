using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Champion
{
    public class BaseDataTSO<T> : BaseDataSO where T : class, new()
    {
        [SerializeField] protected T _Data;
        [SerializeField] protected T _Default;

#if UNITY_EDITOR
        [SerializeField] protected T _DataTest;
#endif

        public override void Save()
        {
            LocalDataSystem.Save(this.name, _Data, Encrypt);
        }

        public override async void SaveAsync(Action<bool> result = null)
        {
            bool success = await LocalDataSystem.SaveAsync(this.name, _Data, Encrypt);
            result?.Invoke(success);
        }

        public override void Load()
        {
            T saveData = LocalDataSystem.Load<T>(this.name, Encrypt);
            if (saveData == null)
            {
                _Data = DeepCopy(_Default);
                Save();
            }
            else _Data = saveData;
        }

        public override void ResetData()
        {
            _Data = DeepCopy(_Default);
            Save();
        }

        public T DeepCopy(T source)
        {
            if (source == null) return new T();
            string json = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public override void Delete()
        {
            LocalDataSystem.Delete(this.name);
        }

#if UNITY_EDITOR
        public override void SetupTest()
        {
            _Data = DeepCopy(_DataTest);
        }
#endif
    }
}