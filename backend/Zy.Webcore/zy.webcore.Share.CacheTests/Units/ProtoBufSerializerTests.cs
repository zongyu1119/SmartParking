using Microsoft.VisualStudio.TestTools.UnitTesting;
using zy.webcore.Share.Redis.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using ProtoBuf;
using System.Diagnostics.CodeAnalysis;

namespace zy.webcore.Share.Redis.Units.Tests
{
    [TestClass()]
    public class ProtoBufSerializerTests
    {
        [TestMethod()]
        public void SerializeTest()
        {
            ProtoBufSerializer serializer = new ProtoBufSerializer();
           
            using var ms = new MemoryStream();
            Serializer.Serialize(ms, new Test());
            var bytes= ms.ToArray();
           var x= Serializer.Deserialize<Test>(new MemoryStream(bytes));
        }
        [ProtoContract]
        public class Test
        {
            //[ProtoMember(1)]
            public long Id { get; set; } = 123;
            //[ProtoMember(2)]
            public string Name { get; set; } = "test";
            //public string[] List { get; set; } = { "123", "456" };
        }
    }
}