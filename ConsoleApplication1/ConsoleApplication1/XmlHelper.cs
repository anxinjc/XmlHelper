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
            base.RemoveAllChilds(base.rootName);

            base.InsertNode("personList", "person0", "Han Mei Mei");
            base.InsertNode("personList", "person1", "Li Lei", "Age", "18");
            

            base.InsertNode(base.rootName, "aaa", "inner");
            base.SetAttribute(base.rootName + "/aaa[@name='aaa-name2']", "sex", "female");

            
        }
    }
}
