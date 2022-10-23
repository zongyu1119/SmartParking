using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SmartParking.Share.ObjExt
{
    public static class DocumenationExtension
    {
        private static readonly Dictionary<Assembly, XmlDocument> Cache = new Dictionary<Assembly, XmlDocument>();

        private static readonly Dictionary<Assembly, Exception> FailCache = new Dictionary<Assembly, Exception>();

        public static XmlElement? GetDocumentation(this Type type)
        {
            return type.XmlFromName('T', "");
        }

        public static XmlElement? GetDocumentation(this MethodInfo methodInfo)
        {
            string text = "";
            ParameterInfo[] parameters = methodInfo.GetParameters();
            foreach (ParameterInfo parameterInfo in parameters)
            {
                if (text.Length > 0)
                {
                    text += ",";
                }

                text += parameterInfo.ParameterType.FullName;
            }

            if ((object)methodInfo.DeclaringType == null)
            {
                return null;
            }

            if (text.Length > 0)
            {
                return methodInfo.DeclaringType.XmlFromName('M', methodInfo.Name + "(" + text + ")");
            }

            return methodInfo.DeclaringType.XmlFromName('M', methodInfo.Name);
        }

        public static XmlElement? GetDocumentation(this MemberInfo memberInfo)
        {
            if ((object)memberInfo != null)
            {
                if ((object)memberInfo.DeclaringType == null)
                {
                    return null;
                }

                return memberInfo.DeclaringType.XmlFromName(memberInfo.MemberType.ToString()[0], memberInfo.Name);
            }

            return null;
        }

        public static string GetSummary(this MemberInfo memberInfo)
        {
            if ((object)memberInfo != null)
            {
                XmlNode xmlNode = memberInfo.GetDocumentation()?.SelectSingleNode("summary");
                if (xmlNode == null)
                {
                    return "";
                }

                return xmlNode.InnerText.Trim();
            }

            return string.Empty;
        }

        public static string GetSummary(this Type type)
        {
            XmlNode xmlNode = type.GetDocumentation()?.SelectSingleNode("summary");
            if (xmlNode == null)
            {
                return string.Empty;
            }

            return xmlNode.InnerText.Trim();
        }

        private static XmlElement? XmlFromName(this Type type, char prefix, string name)
        {
            string text = ((!string.IsNullOrEmpty(name)) ? (prefix + ":" + type.FullName + "." + name) : (prefix + ":" + type.FullName));
            XmlDocument xmlDocument = type.Assembly.XmlFromAssembly();
            if (xmlDocument != null)
            {
                return xmlDocument["doc"]?["members"]?.SelectSingleNode("member[@name='" + text + "']") as XmlElement;
            }

            return null;
        }

        public static XmlDocument? XmlFromAssembly(this Assembly assembly)
        {
            if (FailCache.ContainsKey(assembly))
            {
                return null;
            }

            try
            {
                if (!Cache.ContainsKey(assembly))
                {
                    Cache[assembly] = XmlFromAssemblyNonCached(assembly);
                }

                return Cache[assembly];
            }
            catch (Exception value)
            {
                FailCache[assembly] = value;
                return null;
            }
        }

        private static XmlDocument XmlFromAssemblyNonCached(Assembly assembly)
        {
            string text = "file:///" + assembly.Location;
            StreamReader txtReader;
            try
            {
                txtReader = new StreamReader(Path.ChangeExtension(text.Substring(8), ".xml"));
            }
            catch (FileNotFoundException innerException)
            {
                throw new FileNotFoundException("XML documentation not present (make sure it is turned on in project properties when building)", innerException);
            }

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(txtReader);
            return xmlDocument;
        }
    }
}
