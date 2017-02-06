using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class XmlHelper : XmlBase
    {
        public XmlHelper()
        {
            CreateFile();
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        public void CreateFile()
        {
            base.path = "example.xml";
            base.rootName = "personList";
            base.Init();
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        public void Insert()
        {
            base.Insert("personList", "person0", "Han Mei Mei");
            base.Insert("personList", "person1", "Li Lei", "Age", "18");

            base.Insert("personList/person1[@Age='18']", "", "Bei Jing Da Xue", "Age", "18");
        }
    }
}
