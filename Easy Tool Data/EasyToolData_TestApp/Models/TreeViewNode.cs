using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;


namespace EasyToolData_TestApp.Models
{

    class TreeViewNode
    {
        private string _name;
        private object _value;
        private Type _type;

        public TreeViewNode(string name, object value)
        {
            ParseObjectTree(name, value, value.GetType());
        }

        public TreeViewNode(string name, object value, Type t)
        {
            ParseObjectTree(name, value, t);
        }

        public string Name { get { return _name; } }

        public object Value { get { return _value; } }

        public Type Type { get { return _type; } }

        public List<TreeViewNode> Children { get; set; }


        private void ParseObjectTree(string name, object value, Type type)
        {
            Children = new List<TreeViewNode>();

            _type = type;
            _name = name;

            bool valueIsString = value is string;

            if (value != null)
            {
                if (valueIsString && type != typeof(object))
                {
                    if (value != null) { _value = value; }
                }
                else if (value is double || value is bool || value is int || value is float || value is long || value is decimal)
                {
                    _value = value;
                }
                else if (value is Enum)
                {
                    _value = value.GetType().Name + "." + value.ToString();
                }
                else
                {
                    _value = "{" + value.ToString() + "}";
                }
            }

            PropertyInfo[] props = type.GetProperties();

            if (props.Length == 0 && type.IsClass && value is IEnumerable && !valueIsString)
            {
                if (value is IEnumerable arr)
                {
                    int i = 0;
                    foreach (object element in arr)
                    {
                        Children.Add(new TreeViewNode("[" + i + "]", element, element.GetType()));
                        i++;
                    }

                }
            }

            foreach (PropertyInfo p in props)
            {
                // There is probably a more efficient way to use these checks.
                // I layed them all out at the beginning here for debugging / logging purposes.

                bool isPublic = p.PropertyType.IsPublic;
                bool isClass = p.PropertyType.IsClass;
                bool isArray = p.PropertyType.IsArray;
                bool isValue = p.PropertyType.IsValueType;
                int pIndexParams = p.GetIndexParameters().Length;

                // If it is NOT an indexed property, then it SHOULD BE a value type
                object pObj = null; 
                if (pIndexParams == 0)
                {
                    try { pObj = p.GetValue(value, null); }
                    catch { }
                }

                bool pObjIsNull = (pObj == null); 
                bool pObjIsString = pObjIsNull ? false : (pObj is string);
                bool pObjIsIEnumerable = pObjIsNull ? false : (pObj is IEnumerable); 

                //Log.Send(new Okuma.SharedLog.MessageArg(string.Format(
                //    "{0} >> Pub:{1}, Class:{2}, Array:{3}, IEnumerable:{4} Value:{5}, Indices:{6} ObjNull:{7}, ObjStr:{8}, pType:{9}, valStr:{10}", 
                //    p.Name, isPublic, isClass, isArray, pObjIsIEnumerable, isValue, pIndexParams, pObjIsNull, pObjIsString, p.PropertyType, valueIsString
                //    ), Okuma.SharedLog.MessageType.STATUS));

                if (isPublic)
                {
                    if (isClass || isArray)
                    {                  
                        if (pObjIsString)
                        {
                            if (!pObjIsNull)
                            {
                                Children.Add(new TreeViewNode(p.Name, pObj, p.PropertyType));
                            }
                        }

                        // Try to get Location & Offsets
                        //
                        // Exclude IEnumerables if you want to get collection items
                        // otherwise you end up getting the list's Capacity & Count & lose the inner items...
                        else if (!pObjIsNull && !pObjIsIEnumerable)
                        {
                            Children.Add(new TreeViewNode(p.Name, pObj, p.PropertyType));
                        }

                        // This is actually where lists & other collections are added
                        else 
                        {
                            try
                            {               
                                IEnumerable arr = pObj as IEnumerable;
                                TreeViewNode arrayNode = new TreeViewNode(p.Name, arr.ToString(), typeof(object));

                                if (arr != null)
                                {
                                    int i = 0, k = 0;
                                    TreeViewNode arrayNode2;

                                    foreach (object element in arr)
                                    {
                                        //Handle 2D arrays (I don't have any of these, but it is supported...)
                                        if (element is IEnumerable && !(element is string))
                                        {
                                            arrayNode2 = new TreeViewNode("[" + i + "]", element.ToString(), typeof(object));

                                            IEnumerable arr2 = element as IEnumerable;
                                            k = 0;

                                            foreach (object e in arr2)
                                            {
                                                arrayNode2.Children.Add(new TreeViewNode("[" + k + "]", e, e.GetType()));
                                                k++;
                                            }

                                            arrayNode.Children.Add(arrayNode2);
                                        }
                                        else
                                        {
                                            // List items added here
                                            arrayNode.Children.Add(new TreeViewNode("[" + i + "]", element, element.GetType()));
                                        }

                                        i++;
                                    }
                                }

                                Children.Add(arrayNode);
                            }
                            catch { }
                        }

                    }
                    else if (isValue && !valueIsString)
                    {
                        try
                        {
                            if (!pObjIsNull)
                            {
                                // Most items added here
                                Children.Add(new TreeViewNode(p.Name, pObj, p.PropertyType));
                            }
                        }
                        catch { }
                    }
                }
            }

        } // END ParseObjectTree()

    } // END Class

} // END Namespace
