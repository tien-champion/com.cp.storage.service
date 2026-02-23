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
            _Data = LocalDataSystem.Load<T>(this.name, Encrypt);
        }

        public override void Delete()
        {
            LocalDataSystem.Delete(this.name);
        }
    }
}