using Microsoft.EntityFrameworkCore.Storage;

namespace Microsoft.EntityFrameworkCore.SqlServer.Storage
{
    internal class SqlServerHierarchyIdTypeMappingSourcePlugin : IRelationalTypeMappingSourcePlugin
    {
        public const string SqlServerTypeName = "hierarchyid";

        public virtual RelationalTypeMapping FindMapping(in RelationalTypeMappingInfo mappingInfo)
        {
            var clrType = mappingInfo.ClrType;
            var storeTypeName = mappingInfo.StoreTypeName;

            return typeof(HierarchyId).IsAssignableFrom(clrType) || storeTypeName == SqlServerTypeName
                ? new SqlServerHierarchyIdTypeMapping(SqlServerTypeName, clrType ?? typeof(HierarchyId))
                : null;
        }
    }
}
