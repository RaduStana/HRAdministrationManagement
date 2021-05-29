using Dapper;
using HRAM.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAM.UI.Helpers
{
    public class ColumnAttributeTypeMapper<T> : FallbackTypeMapper
    {
        public ColumnAttributeTypeMapper()
            : base(new SqlMapper.ITypeMap[]
                {
                    new CustomPropertyTypeMap(
                       typeof(T),
                       (type, columnName) =>
                           type.GetProperties().FirstOrDefault(prop =>
                               prop.GetCustomAttributes(false)
                                   .OfType<Employee>()
                                   .Any(attr => attr.Email == columnName)
                               )
                       ),
                    new DefaultTypeMap(typeof(T))
                })
        {
        }
    }
}
