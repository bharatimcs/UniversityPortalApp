using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace UniversityPortalApp.Web
{
    /// <summary>
    /// Convert response to bson
    /// </summary>
    public class BsonFormatter : MediaTypeFormatter
    {
        private const string contentType = "application/bson";
        private JsonSerializerSettings jsonSerializerSettings;

        /// <summary>
        /// Initialize the <see cref="BsonFormatter"/>
        /// </summary>
        public BsonFormatter()
        {
            jsonSerializerSettings = CreateDefaultSerializerSettings();
            SupportedMediaTypes.Add(new MediaTypeHeaderValue(contentType));
            MediaTypeMappings.Add(new QueryStringMapping("fmt", "bson", new MediaTypeHeaderValue(contentType)));
        }

        /// <summary>
        /// Creates a <see cref="JsonSerializerSettings"/> instance
        /// </summary>
        /// <returns></returns>
        public JsonSerializerSettings CreateDefaultSerializerSettings()
        {
            return new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                TypeNameHandling = TypeNameHandling.None
            };
        }

        /// <summary>
        /// Dont support reading the type of object as bson
        /// </summary>
        /// <param name="type">Type of object to write</param>
        /// <returns></returns>
        public override bool CanReadType(Type type)
        {
            return false;
        }

        /// <summary>
        /// Can write the type of object to bson
        /// </summary>
        /// <param name="type">Type of object to write</param>
        /// <returns></returns>
        public override bool CanWriteType(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("Type cannot be null");
            }
            return true;
        }

        /// <summary>
        /// Media type header value
        /// </summary>
        public MediaTypeHeaderValue MediaType
        {
            get
            {
                return new MediaTypeHeaderValue("application/bson");
            }
        }

        /// <summary>
        /// Serialize the object to the stream as bson
        /// </summary>
        /// <param name="type">Type to serialize</param>
        /// <param name="value">Value of the object</param>
        /// <param name="writeStream">Stream</param>
        /// <param name="content">Http content</param>
        /// <param name="transportContext">Transport Context</param>
        /// <returns>Task</returns>
        public override Task WriteToStreamAsync(Type type,
                                                object value,
                                                Stream writeStream,
                                                HttpContent content,
                                                TransportContext transportContext)
        {
            var tcs = new TaskCompletionSource<object>();
            content.Headers.ContentType = MediaType;
            using (var bsonWriter = new BsonWriter(writeStream) { CloseOutput = false })
            {
                var serializer = JsonSerializer.Create(jsonSerializerSettings);
                serializer.Serialize(bsonWriter, value);
                bsonWriter.Flush();
                tcs.SetResult(null);
            }
            return tcs.Task;
        }
    }
}