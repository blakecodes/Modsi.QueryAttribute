using System;
using System.Collections.Generic;
using System.Reflection;

namespace Modsi.QueryAttribute
{
    public static class QueryHandler
    {
        public static string BuildQuery<T>(T request)
        {
            Type type = request.GetType();
            PropertyInfo[] properties = type.GetProperties();
            Dictionary<string, string> queryParameters = new Dictionary<string, string>();
            string queryString = "?";

            foreach (PropertyInfo property in properties)
            {
                QueryAttribute queryAtrributes = property.GetCustomAttribute<QueryAttribute>();

                if (queryAtrributes != null)
                {
                    string name = property.Name;
                    string value = property.GetValue(request)?.ToString();

                    if (value != null && value != queryAtrributes.NullValue)
                    {
                        queryParameters.Add(queryAtrributes.Name, value);
                    }
                }
            }

            foreach (var param in queryParameters)
            {
                queryString += param.Key + "=" + param.Value + "&";
            }

            queryString = queryString.Remove(queryString.Length - 1, 1);

            return queryString;
        }
    }
}
