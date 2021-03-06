﻿using System;
using System.Xml;
using System.Xml.Linq;
using IFramework.Infrastructure;
using Newtonsoft.Json;

namespace IFramework.JsonNet
{
    public class JsonConvertImpl: IJsonConvert
    {
        public string SerializeObject(object value, bool serializeNonPublic = false, 
                                      bool loopSerialize = false, bool useCamelCase = false,
                                      bool ignoreNullValue = true, bool useStringEnumConvert = true)
        {
            return value.ToJson(serializeNonPublic, loopSerialize, useCamelCase, ignoreNullValue, useStringEnumConvert);
        }

        public object DeserializeObject(string value, bool serializeNonPublic = false, bool loopSerialize = false, bool useCamelCase = false)
        {
            return value.ToObject(serializeNonPublic, loopSerialize, useCamelCase);
        }

        public dynamic DeserializeDynamicObject(string json, bool serializeNonPublic = false, bool loopSerialize = false, bool useCamelCase = false)
        {
            return json.ToDynamicObject(serializeNonPublic, loopSerialize, useCamelCase);
        }

        public dynamic DeserializeDynamicObjects(string json, bool serializeNonPublic = false, bool loopSerialize = false, bool useCamelCase = false)
        {
            return json.ToDynamicObjects(serializeNonPublic, loopSerialize, useCamelCase);
        }

        public T DeserializeAnonymousType<T>(string value, T anonymousTypeObject, bool serializeNonPublic = false, bool loopSerialize = false, bool useCamelCase = false)
        {
            return JsonConvert.DeserializeAnonymousType(value, anonymousTypeObject, 
                                                        JsonHelper.GetCustomJsonSerializerSettings(serializeNonPublic, loopSerialize, useCamelCase));

        }

        public T DeserializeObject<T>(string value, bool serializeNonPublic = false, bool loopSerialize = false, bool useCamelCase = false)
        {
            return value.ToObject<T>(serializeNonPublic, loopSerialize, useCamelCase);
        }

        public object DeserializeObject(string value, Type type, bool serializeNonPublic = false, bool loopSerialize = false, bool useCamelCase = false)
        {
            return value.ToObject(type, serializeNonPublic, loopSerialize, useCamelCase);
        }

        public void PopulateObject(string value, object target, bool serializeNonPublic = false, bool loopSerialize = false, bool useCamelCase = false)
        {
            JsonConvert.PopulateObject(value, target, JsonHelper.GetCustomJsonSerializerSettings(serializeNonPublic, loopSerialize, useCamelCase));
        }

        public string SerializeXmlNode(XmlNode node)
        {
            return JsonConvert.SerializeXmlNode(node);
        }

        public XmlDocument DeserializeXmlNode(string value)
        {
            return JsonConvert.DeserializeXmlNode(value);
        }

        public XmlDocument DeserializeXmlNode(string value, string deserializeRootElementName)
        {
            return JsonConvert.DeserializeXmlNode(value, deserializeRootElementName);
        }

        public XmlDocument DeserializeXmlNode(string value, string deserializeRootElementName, bool writeArrayAttribute)
        {
            return JsonConvert.DeserializeXmlNode(value, deserializeRootElementName, writeArrayAttribute);
        }

        public string SerializeXNode(XObject node)
        {
            return JsonConvert.SerializeXNode(node);
        }
        
        public XDocument DeserializeXNode(string value)
        {
            return JsonConvert.DeserializeXNode(value);
        }

        public XDocument DeserializeXNode(string value, string deserializeRootElementName)
        {
            return JsonConvert.DeserializeXNode(value, deserializeRootElementName);
        }

        public XDocument DeserializeXNode(string value, string deserializeRootElementName, bool writeArrayAttribute)
        {
            return JsonConvert.DeserializeXNode(value, deserializeRootElementName, writeArrayAttribute);
        }
    }
}
