#region Assembly System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6\System.Data.dll
#endregion

using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace System.Data
{
    /*
    // Summary:
    //     Represents the collection of tables for the System.Data.DataSet.
    [DefaultEvent("CollectionChanged")]
    [DefaultMember("Item")]
    [Editor("Microsoft.VSDesigner.Data.Design.TablesCollectionEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [ListBindable(false)]
    public sealed class DataTableCollection : InternalDataCollectionBase
    {
        //
        // Summary:
        //     Gets the System.Data.DataTable object with the specified name.
        //
        // Parameters:
        //   name:
        //     The name of the DataTable to find.
        //
        // Returns:
        //     A System.Data.DataTable with the specified name; otherwise null if the System.Data.DataTable
        //     does not exist.
        public DataTable this[string name] { get; }
        //
        // Summary:
        //     Gets the System.Data.DataTable object at the specified index.
        //
        // Parameters:
        //   index:
        //     The zero-based index of the System.Data.DataTable to find.
        //
        // Returns:
        //     A System.Data.DataTablewith the specified index; otherwise null if the System.Data.DataTable
        //     does not exist.
        //
        // Exceptions:
        //   T:System.IndexOutOfRangeException:
        //     The index value is greater than the number of items in the collection.
        public DataTable this[int index] { get; }
        //
        // Summary:
        //     Gets the System.Data.DataTable object with the specified name in the specified
        //     namespace.
        //
        // Parameters:
        //   name:
        //     The name of the DataTable to find.
        //
        //   tableNamespace:
        //     The name of the System.Data.DataTable namespace to look in.
        //
        // Returns:
        //     A System.Data.DataTable with the specified name; otherwise null if the System.Data.DataTable
        //     does not exist.
        public DataTable this[string name, string tableNamespace] { get; }

        protected override ArrayList List { get; }

        //
        // Summary:
        //     Occurs while the System.Data.DataTableCollection is changing because of System.Data.DataTable
        //     objects being added or removed.
        public event CollectionChangeEventHandler CollectionChanging;
        //
        // Summary:
        //     Occurs after the System.Data.DataTableCollection is changed because of System.Data.DataTable
        //     objects being added or removed.
        [ResDescriptionAttribute("collectionChangedEventDescr")]
        public event CollectionChangeEventHandler CollectionChanged;

        //
        // Summary:
        //     Adds the specified DataTable to the collection.
        //
        // Parameters:
        //   table:
        //     The DataTable object to add.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     The value specified for the table is null.
        //
        //   T:System.ArgumentException:
        //     The table already belongs to this collection, or belongs to another collection.
        //
        //   T:System.Data.DuplicateNameException:
        //     A table in the collection has the same name. The comparison is not case sensitive.
        public void Add(DataTable table);
        //
        // Summary:
        //     Creates a new System.Data.DataTable object by using a default name and adds it
        //     to the collection.
        //
        // Returns:
        //     The newly created System.Data.DataTable.
        public DataTable Add();
        //
        // Summary:
        //     Creates a System.Data.DataTable object by using the specified name and adds it
        //     to the collection.
        //
        // Parameters:
        //   name:
        //     The name to give the created System.Data.DataTable.
        //
        //   tableNamespace:
        //     The namespace to give the created System.Data.DataTable.
        //
        // Returns:
        //     The newly created System.Data.DataTable.
        //
        // Exceptions:
        //   T:System.Data.DuplicateNameException:
        //     A table in the collection has the same name. (The comparison is not case sensitive.)
        public DataTable Add(string name, string tableNamespace);
        //
        // Summary:
        //     Creates a System.Data.DataTable object by using the specified name and adds it
        //     to the collection.
        //
        // Parameters:
        //   name:
        //     The name to give the created System.Data.DataTable.
        //
        // Returns:
        //     The newly created System.Data.DataTable.
        //
        // Exceptions:
        //   T:System.Data.DuplicateNameException:
        //     A table in the collection has the same name. (The comparison is not case sensitive.)
        public DataTable Add(string name);
        //
        // Summary:
        //     Copies the elements of the specified System.Data.DataTable array to the end of
        //     the collection.
        //
        // Parameters:
        //   tables:
        //     The array of System.Data.DataTable objects to add to the collection.
        public void AddRange(DataTable[] tables);
        //
        // Summary:
        //     Verifies whether the specified System.Data.DataTable object can be removed from
        //     the collection.
        //
        // Parameters:
        //   table:
        //     The DataTable in the collection to perform the check against.
        //
        // Returns:
        //     true if the table can be removed; otherwise false.
        public bool CanRemove(DataTable table);
        //
        // Summary:
        //     Clears the collection of all System.Data.DataTable objects.
        public void Clear();
        //
        // Summary:
        //     Gets a value that indicates whether a System.Data.DataTable object with the specified
        //     name exists in the collection.
        //
        // Parameters:
        //   name:
        //     The name of the System.Data.DataTable to find.
        //
        // Returns:
        //     true if the specified table exists; otherwise false.
        public bool Contains(string name);
        //
        // Summary:
        //     Gets a value that indicates whether a System.Data.DataTable object with the specified
        //     name and table namespace exists in the collection.
        //
        // Parameters:
        //   name:
        //     The name of the System.Data.DataTable to find.
        //
        //   tableNamespace:
        //     The name of the System.Data.DataTable namespace to look in.
        //
        // Returns:
        //     true if the specified table exists; otherwise false.
        public bool Contains(string name, string tableNamespace);
        //
        // Summary:
        //     Copies all the elements of the current System.Data.DataTableCollection to a one-dimensional
        //     System.Array, starting at the specified destination array index.
        //
        // Parameters:
        //   array:
        //     The one-dimensional System.Array to copy the current System.Data.DataTableCollection
        //     object's elements into.
        //
        //   index:
        //     The destination System.Array index to start copying into.
        public void CopyTo(DataTable[] array, int index);
        //
        // Summary:
        //     Gets the index of the specified System.Data.DataTable object.
        //
        // Parameters:
        //   table:
        //     The DataTable to search for.
        //
        // Returns:
        //     The zero-based index of the table, or -1 if the table is not found in the collection.
        public int IndexOf(DataTable table);
        //
        // Summary:
        //     Gets the index in the collection of the specified System.Data.DataTable object.
        //
        // Parameters:
        //   tableName:
        //     The name of the System.Data.DataTable object to look for.
        //
        //   tableNamespace:
        //     The name of the System.Data.DataTable namespace to look in.
        //
        // Returns:
        //     The zero-based index of the System.Data.DataTable with the specified name, or
        //     -1 if the table does not exist in the collection.
        public int IndexOf(string tableName, string tableNamespace);
        //
        // Summary:
        //     Gets the index in the collection of the System.Data.DataTable object with the
        //     specified name.
        //
        // Parameters:
        //   tableName:
        //     The name of the DataTable object to look for.
        //
        // Returns:
        //     The zero-based index of the DataTable with the specified name, or -1 if the table
        //     does not exist in the collection.Returns -1 when two or more tables have the
        //     same name but different namespaces. The call does not succeed if there is any
        //     ambiguity when matching a table name to exactly one table.
        public int IndexOf(string tableName);
        //
        // Summary:
        //     Removes the specified System.Data.DataTable object from the collection.
        //
        // Parameters:
        //   table:
        //     The DataTable to remove.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     The value specified for the table is null.
        //
        //   T:System.ArgumentException:
        //     The table does not belong to this collection.-or- The table is part of a relationship.
        public void Remove(DataTable table);
        //
        // Summary:
        //     Removes the System.Data.DataTable object with the specified name from the collection.
        //
        // Parameters:
        //   name:
        //     The name of the System.Data.DataTable object to remove.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     The collection does not have a table with the specified name.
        public void Remove(string name);
        //
        // Summary:
        //     Removes the System.Data.DataTable object with the specified name from the collection.
        //
        // Parameters:
        //   name:
        //     The name of the System.Data.DataTable object to remove.
        //
        //   tableNamespace:
        //     The name of the System.Data.DataTable namespace to look in.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     The collection does not have a table with the specified name.
        public void Remove(string name, string tableNamespace);
        //
        // Summary:
        //     Removes the System.Data.DataTable object at the specified index from the collection.
        //
        // Parameters:
        //   index:
        //     The index of the DataTable to remove.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     The collection does not have a table at the specified index.
        public void RemoveAt(int index);
    }*/
}