using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public class PrimaryKey
    {
        public List<Object> KeyValues { get; set; }

        public PrimaryKey(Object[] stringKeys)
        {
            KeyValues = MakeToMultipleKey(stringKeys);
        }

        public PrimaryKey(int id)
        {
            KeyValues = MakeToIdKey(id);
        }

        public PrimaryKey()
        {
            KeyValues = new List<object>();
        }

        private List<object> MakeToIdKey(int id)
        {
            List<object> idKey = new List<object>();
            idKey.Add(id);
            return idKey;
        }

        private List<object> MakeToMultipleKey(Object[] keys)
        {
            List<object> stringKeys = new List<object>();
            foreach (Object item in keys)
            {
                stringKeys.Add(item);
            }
            return stringKeys;
        }
    }
}
