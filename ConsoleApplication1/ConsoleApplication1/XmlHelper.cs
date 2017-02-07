//XPath语法：http://www.cnblogs.com/zengsiyu/articles/1525195.html

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
            base.InsertNode("personList", "person0", "Han Mei Mei");
            base.InsertNode("personList", "person2", "Li Lei", "Age", "18");

            base.InsertNode("personList/person2[@Age='18']", "school", "Bei Jing Da Xue", "during Years", "4");
        }
    }
}
