using UnityEngine;

namespace Champion
{
    public class BaseDataTSO<T> : BaseDataSO where T : class, new()
    {
        [SerializeField] protected T _Data;

        public override void Save()
        {
            LocalDataSystem.Save(this.name, _Data, Encrypt);
        }

        public override void Load()
        {
            T saveData = LocalDataSystem.Load<T>(this.name, Encrypt);
            if (saveData == null) Save();
            else _Data = saveData;
        }

        public override void Delete()
        {
            LocalDataSystem.Delete(this.name);
        }
    }
}