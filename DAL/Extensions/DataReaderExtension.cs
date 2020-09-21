using Npgsql;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Extensions
{
    public static class DataReaderExtension
    {
        public static T CreateModel<T>(this NpgsqlDataReader reader)
        {
            T item = Activator.CreateInstance<T>();
            foreach (var property in typeof(T).GetProperties())
            {
                if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                {
                    Type convertTo = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                    property.SetValue(item, Convert.ChangeType(reader[property.Name], convertTo), null);
                }
            }
            return item;
        }
    }
}
