using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Share.Infra
{
    internal class HashGenerater : IHashGenerater
    {
        public HashConsistentGenerater ConsistentGenerater => HashConsistentGenerater.Instance;

        internal HashGenerater()
        {
        }
    }
}
