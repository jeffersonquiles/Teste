using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace Tcc.Framework.Patterns.TranslateEntity
{
    /// <summary>
    /// Classe que implementa a operação de tradução de tipos
    /// </summary>
    public class EntityTranslator
    {
        #region --- ConvertValue ---
        private static object ConvertValue(object data, Type targetType)
        {
            if (data == null) return null;

            Type sourceType = data.GetType();

            if (sourceType == targetType) return data;

            object retData = data;

            if (sourceType.Equals(typeof(string)))
            {
                string strTmp = data.ToString();

                if (targetType == typeof(int))
                    retData = int.Parse(strTmp);

                if (targetType == typeof(double))
                    retData = double.Parse(strTmp, CultureInfo.InvariantCulture);

                if (targetType == typeof(decimal))
                    retData = decimal.Parse(strTmp, CultureInfo.InvariantCulture);

                if (targetType == typeof(float))
                    retData = float.Parse(strTmp, CultureInfo.InvariantCulture);

                if (targetType == typeof(DateTime))
                    retData = DateTime.Parse(strTmp, CultureInfo.InvariantCulture);
            }
            else if (targetType.Equals(typeof(string)))
            {
                retData = data.ToString();
            }

            return retData;
        }

        private static object ConvertValue(object data, PropertyInfo targetProperty, EntityTranslatorAttribute attribute, Dictionary<object, object> lstObjects)
        {
            if (data == null) return data;

            Type sourceType = data.GetType();
            Type targetType = targetProperty.PropertyType;

            if (attribute != null)
            {
                if (!attribute.ForceCreate)
                {
                    if (sourceType == targetType) return data;
                }
            }
            else
            {
                if (sourceType == targetType) return data;
            }

            object retData = data;

            if (attribute != null)
            {
                //Mapeamento de indexacao...
                if (attribute.IndexerKey != null && attribute.IndexerKey.Length > 0)
                {
                    Type[] sourceInterfaces = sourceType.GetInterfaces();
                    foreach (Type sourceInterface in sourceInterfaces)
                    {
                        if (sourceInterface.Equals(typeof(IDictionary)) || sourceInterface.FullName.ToString().Contains("IDictionary"))
                        {
                            IDictionary indexData = (IDictionary)data;
                            retData = ConvertValue(indexData[attribute.IndexerKey], targetType);
                        }
                    }
                }
                //Mapeamento de colecoes
                else if (attribute.EnumerableType != null)
                {
                    if (sourceType.GetInterface("IList`1") != null
                        && targetType.GetInterface("IList`1") != null)
                    {
                        object obj = Activator.CreateInstance(targetType);
                        
                        IList lstData = (IList) obj;
                        foreach (object tmpItem in ((IList)data))
                        {
                            lstData.Add(Translate(tmpItem, attribute.EnumerableType, lstObjects));
                        }
                        
                        retData = obj;
                    }
                    else
                    {
                        Type[] sourceInterfaces = sourceType.GetInterfaces();
                        foreach (Type sourceInterface in sourceInterfaces)
                        {
                            if (sourceInterface.Equals(typeof(IEnumerable)))
                            {
                                foreach (Type interfaceTmp in targetType.GetInterfaces())
                                {
                                    if (interfaceTmp.Equals(typeof(IEnumerable)))
                                    {
                                        ArrayList lstData = new ArrayList();
                                        foreach (object tmpItem in ((IEnumerable)data))
                                        {
                                            lstData.Add(Translate(tmpItem, attribute.EnumerableType, lstObjects));
                                        }
                                        retData = lstData.ToArray(attribute.EnumerableType);
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
                else
                {
                    retData = Translate(data, targetType, lstObjects);
                }
            }
            //Mapeamento simples
            else if (sourceType.Equals(typeof(string)) || targetType.Equals(typeof(string)))
            {
                retData = ConvertValue(data, targetType);
            }
            else
            {
                retData = Translate(data, targetType, lstObjects);
            }

            return retData;
        }
        #endregion

        /// <summary>
        /// Método que traduz o objeto de origem para o objeto de destino
        /// </summary>
        /// <param name="source">Objeto de origem</param>
        /// <param name="targetType">Tipo de destino</param>
        /// <param name="enableCanConvert">habilita conversao de todas as propriedades. Caso true, irá executar o método da inteface IEntityTranslatorCanConvert.CanConvert dos objetos destino</param>
        /// <returns>Retorna um objeto com as informações do objeto origem e do tipo de destino</returns>
        public static object Translate(object source, Type targetType, Dictionary<object, object> lstObjects, bool enableCanConvert)
        {
            bool hasProperties = targetType.GetProperties().Length > 0;
            bool hasConstructor = targetType.GetConstructors().Length > 0;

            object obj = source;
            if (hasConstructor)
            {
                try
                {
                    if (lstObjects.ContainsKey(source))
                    {
                        return lstObjects[source];
                    }

                    obj = Activator.CreateInstance(targetType, true);

                    lstObjects[source] = obj;
                }
                catch
                {
                    obj = null;
                }
            }

            Predicate<string> canConvert = null;
            if (obj is IEntityTranslatorCanConvert && enableCanConvert)
            {
                canConvert = ((IEntityTranslatorCanConvert)obj).CanConvert;
            }

            Type tSource = source.GetType();

            if (hasProperties)
            {
                foreach (PropertyInfo prop in targetType.GetProperties())
                {
                    if (canConvert != null)
                    {
                        bool convert = canConvert(prop.Name);
                        if (!convert) continue;
                    }

                    EntityTranslatorAttribute[] attributes = (EntityTranslatorAttribute[])prop.GetCustomAttributes(typeof(EntityTranslatorAttribute), true);
                    if (attributes != null && attributes.Length > 0)
                    {
                        if (!attributes[0].HasMapping) continue;

                        string sourceProperty = attributes[0].SourceProperty;
                        if (sourceProperty == null)
                        {
                            sourceProperty = prop.Name;
                        }

                        PropertyInfo propSource = tSource.GetProperty(sourceProperty);
                        if (propSource != null)
                        {
                            object convertValue = ConvertValue(propSource.GetValue(source, null), prop, attributes[0], lstObjects);
                            if (convertValue != null && prop.CanWrite)
                            {
                                if (prop.PropertyType.FullName != convertValue.GetType().ToString())
                                {
                                    Dictionary<object, object> oDictionary = new Dictionary<object, object>();
                                    prop.SetValue(obj, Translate(convertValue, prop.PropertyType, oDictionary), null);
                                }
                                else
                                    prop.SetValue(obj, convertValue, null);
                            }
                        }
                    }
                    else
                    {
                        PropertyInfo propSource = tSource.GetProperty(prop.Name);
                        if (propSource != null)
                        {
                            object convertValue = ConvertValue(propSource.GetValue(source, null), prop, null, lstObjects);
                            if (convertValue != null && prop.CanWrite)
                                prop.SetValue(obj, convertValue, null);
                        }
                    }
                }
            }
            else
            {
                obj = ConvertValue(source, targetType);
            }

            return obj;     
        }

        /// <summary>
        /// Método que traduz o objeto de origem para o objeto de destino
        /// </summary>
        /// <param name="source">Objeto de origem</param>
        /// <param name="targetType">Tipo de destino</param>
        /// <returns>Retorna um objeto com as informações do objeto origem e do tipo de destino</returns>
        public static object Translate(object source, Type targetType, Dictionary<object, object> lstObjects)
        {
            return Translate(source, targetType, lstObjects, true);
        }

        public static TTarget Translate<TTarget>(object source, bool enableCanConvert)
        {
            Dictionary<object, object> lstObjects = new Dictionary<object, object>();
            Type t = typeof(TTarget);

            return (TTarget)Translate(source, t, lstObjects, enableCanConvert);
        }

        public static TTarget Translate<TTarget>(object source)
        {
            return Translate<TTarget>(source, true);
        }

        public static IList<T> TranslateList<T, T2>(IList<T2> source)
        {
            IList<T> lstTmp = new List<T>();
            if (source != null)
            {
                foreach (T2 item in source)
                {
                    lstTmp.Add(EntityTranslator.Translate<T>(item));
                }
            }
            return lstTmp;
        }

        public static IList<TTarget> Translate<TTarget>(System.Data.DataTable source)
        {
            return DataTableTransform.Translate<TTarget>(source);
        }
    }

    public interface IEntityTranslatorCanConvert
    {
        bool CanConvert(string propertyName);
    }

    /// <summary>
    /// Classe que define o atributo para tradução de entidades
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EntityTranslatorAttribute : System.Attribute
    {
        public EntityTranslatorAttribute(bool hasMapping)
        {
            this.HasMapping = hasMapping;
            this.EnumerableType = null;
            this.ForceCreate = false;
        }

        public EntityTranslatorAttribute(string sourceProperty)
        {
            this.HasMapping = true;
            this.ForceCreate = false;
            this.SourceProperty = sourceProperty;
            this.EnumerableType = null;
        }

        public EntityTranslatorAttribute()
        {
            this.ColumnName = string.Empty;
            this.HasMapping = true;
            this.ForceCreate = false;
            this.EnumerableType = null;
        }

        public bool HasMapping { get; set; }

        public bool ForceCreate { get; set; }

        public string SourceProperty { get; set; }

        public Type EnumerableType { get; set; }

        public string IndexerKey { get; set; }

        public string ColumnName{get; set;}
    }

    internal class DataTableTransform
    {
        static System.Collections.Hashtable columns = null;
        private static object ConvertValue(object data, Type targetType)
        {
            if (data == null || data == System.DBNull.Value) return null;

            Type sourceType = data.GetType();

            if (sourceType == targetType) return data;

            object retData = data;

            if (sourceType.Equals(typeof(string)))
            {
                string strTmp = data.ToString();

                if (targetType == typeof(int))
                    retData = int.Parse(strTmp);

                if (targetType == typeof(double))
                    retData = double.Parse(strTmp, System.Globalization.CultureInfo.InvariantCulture);

                if (targetType == typeof(decimal))
                    retData = decimal.Parse(strTmp, System.Globalization.CultureInfo.InvariantCulture);

                if (targetType == typeof(float))
                    retData = float.Parse(strTmp, System.Globalization.CultureInfo.InvariantCulture);

                if (targetType == typeof(DateTime))
                    retData = DateTime.Parse(strTmp, System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (targetType.Equals(typeof(string)))
            {
                retData = data.ToString();
            }

            return retData;
        }
        private static System.Collections.Hashtable GetColumns(object target)
        {
            System.Collections.Hashtable columns = new System.Collections.Hashtable();
            System.Type t = target.GetType();
            PropertyInfo[] propertyInfos = t.GetProperties();
            foreach (PropertyInfo p in propertyInfos)
            {
                object[] atts = p.GetCustomAttributes(true);
                foreach (System.Attribute att in atts)
                {
                    if (att.GetType() == typeof(EntityTranslatorAttribute))
                    {
                        columns.Add(p.Name, ((EntityTranslatorAttribute)att).ColumnName);
                        break;
                    }
                }
            }
            return columns;
        }
        private static void Populate(System.Data.DataRow row, object target)
        {
            if (null == columns)
                columns = GetColumns(target);

            System.Collections.IDictionaryEnumerator myEnum = columns.GetEnumerator();
            while (myEnum.MoveNext())
            {
                if (row.Table.Columns.Contains(myEnum.Value.ToString()))
                {
                    System.Reflection.PropertyInfo myProperty = target.GetType().GetProperty(myEnum.Key.ToString());
                    object value = ConvertValue(row[myEnum.Value.ToString()], myProperty.GetType());
                    if (null != value)
                        myProperty.SetValue(target, value, null);
                }
            }
            myEnum.Reset();
        }
        internal static System.Collections.Generic.IList<TTarget> Translate<TTarget>(System.Data.DataTable source)
        {
            Type t = typeof(TTarget);
            System.Collections.Generic.IList<TTarget> obj = new System.Collections.Generic.List<TTarget>();
            foreach (System.Data.DataRow row in source.Rows)
            {
                TTarget instance = (System.Activator.CreateInstance<TTarget>());
                Populate(row, instance);
                obj.Add(instance);
            }
            columns = null;
            return obj;
        }
    }
}
