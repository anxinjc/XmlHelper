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

            //添加节点
            base.InsertNode("personList", "person0", "Han Mei Mei");
            base.InsertNode("personList", "person0", "Lucy");

            //第一个【personList/person0】的【age】属性为【14】
            base.SetAttribute("personList/person0", "age", "14");

            //第二个【personList/person0】的【age】属性为【17】
            base.SetAttribute("personList/person0[2]", "age", "17");

            //添加带有属性的节点
            base.InsertNode("personList", "person1", "Jim", "age", "21");
            base.InsertNode("personList", "person1", "", "age", "18");

            base.InsertNode("personList/person1[@age='18']", "school", "Bei Jing Da Xue");
            


            base.InsertNode(base.rootName, "aaa", "inner");
            //base.SetAttribute(base.rootName + "/aaa[@name='aaa-name2']", "sex", "female");

            
        }
    }
}
