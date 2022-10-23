using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Share.Infra
{
    public sealed class HashConsistentGenerater
    {
        private static HashConsistentGenerater _instance;

        private int _virtualNodeMultiple = 100;

        private readonly List<string> Nodes = new List<string>();

        private readonly List<int> VirtualNode = new List<int>();

        private readonly Dictionary<int, string> VirtualNodeAndNodeMap = new Dictionary<int, string>();

        public static HashConsistentGenerater Instance => _instance;

        static HashConsistentGenerater()
        {
            _instance = new HashConsistentGenerater();
        }

        private HashConsistentGenerater()
        {
        }

        public bool AddNode(params string[] hosts)
        {
            if (hosts == null || hosts.Length == 0)
            {
                return false;
            }

            Nodes.AddRange(hosts);
            foreach (string text in hosts)
            {
                for (int j = 1; j <= _virtualNodeMultiple; j++)
                {
                    int num = GetHashCode(text + j) & 0x7FFFFFFF;
                    if (!VirtualNodeAndNodeMap.ContainsKey(num))
                    {
                        VirtualNode.Add(num);
                        VirtualNodeAndNodeMap.Add(num, text);
                    }
                }
            }

            VirtualNode.Sort();
            return true;
        }

        public bool RemoveNode(string host)
        {
            if (!Nodes.Remove(host))
            {
                return false;
            }

            for (int i = 1; i <= _virtualNodeMultiple; i++)
            {
                int num = GetHashCode(host + i) & 0x7FFFFFFF;
                if (VirtualNodeAndNodeMap.ContainsKey(num) && VirtualNodeAndNodeMap[num] == host)
                {
                    VirtualNode.Remove(num);
                    VirtualNodeAndNodeMap.Remove(num);
                }
            }

            VirtualNode.Sort();
            return true;
        }

        public List<string> GetAllNodes()
        {
            List<string> list = new List<string>(Nodes.Count);
            list.AddRange(Nodes);
            return list;
        }

        public int GetNodesCount()
        {
            return Nodes.Count;
        }

        public void ReSetVirtualNodeMultiple(int multiple)
        {
            if (multiple >= 0 && multiple != _virtualNodeMultiple)
            {
                List<string> list = new List<string>(Nodes.Count);
                list.AddRange(Nodes);
                _virtualNodeMultiple = multiple;
                Nodes.Clear();
                VirtualNode.Clear();
                VirtualNodeAndNodeMap.Clear();
                AddNode(list.ToArray());
            }
        }

        public string GetNode(string key)
        {
            int num = GetHashCode(key) & 0x7FFFFFFF;
            int num2 = 0;
            int num3 = VirtualNode.Count - 1;
            while (num3 - num2 > 1)
            {
                int num4 = (num2 + num3) / 2;
                if (VirtualNode[num4] > num)
                {
                    num3 = num4;
                }
                else
                {
                    num2 = ((VirtualNode[num4] >= num) ? (num3 = num4) : num4);
                }
            }

            return VirtualNodeAndNodeMap[VirtualNode[num2]];
        }

        private static int GetHashCode(string key, int nTime = 0)
        {
            using MD5 mD = MD5.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(key);
            byte[] array = mD.ComputeHash(bytes);
            return (int)((((long)(array[3 + nTime * 4] & 0xFF) << 24) | ((long)(array[2 + nTime * 4] & 0xFF) << 16) | ((long)(array[1 + nTime * 4] & 0xFF) << 8) | ((long)array[nTime * 4] & 0xFFL)) & 0xFFFFFFFFu);
        }
    }
}
