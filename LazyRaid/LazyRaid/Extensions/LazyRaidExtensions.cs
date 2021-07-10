using LazyRaid.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace LazyRaid
{
    public static class LazyRaidExtensions
    {
        public static void Sort<T>(this ObservableCollection<T> collection, Comparison<T> comparison)
        {
            var sortableList = new List<T>(collection);
            sortableList.Sort(comparison);

            for (int i = 0; i < sortableList.Count; i++)
            {
                collection.Move(collection.IndexOf(sortableList[i]), i);
            }
        }

        public static string GetMemberName<T>(Expression<Func<T>> memberExpression)
        {
            MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
            return expressionBody.Member.Name;
        }
    }

    public class SerializeAsGUIDAttribute : Attribute { }
    public class SerializeReferenceClassAttribute : Attribute { }

    public class OC<T> : ObservableCollection<T>
    {
        public new void Add(T objectToadd)
        {
            ((ObservableCollection<T>)this).Add(objectToadd);
        }
    }

    public class OCLibrary<T> : OC<T> where T : BindableReferenceBase
    {
        private Dictionary<Guid, T> lookupDictionary = new Dictionary<Guid, T>();
        public string ObjectTypeName = typeof(T).Name.ToString();
        public new void Add(T objectToAdd)
        {
            ((ObservableCollection<T>)this).Add(objectToAdd);
            lookupDictionary.Add(objectToAdd.ID, objectToAdd);
        }

        public bool ContainsKey(Guid ID)
        {
            return lookupDictionary.ContainsKey(ID);
        }

        public T GetValue(Guid ID)
        {
            return lookupDictionary[ID];
        }
    }

}
