using Microsoft.VisualStudio.TestTools.UnitTesting;
using zy.webcore.Share.Application.Utilitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Application.Utilitys.Tests
{
    [TestClass()]
    public class StringUtillyTests
    {
        [TestMethod()]
        public void GetStringFromBase64Test()
        {
            string str = Convert.ToBase64String(Encoding.Default.GetBytes("测试"));
            var str1=StringUtilly.GetStringFromBase64(str);
            
        }
    }
}