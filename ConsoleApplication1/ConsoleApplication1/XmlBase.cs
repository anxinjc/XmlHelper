using System;
using System.IO;
using System.Xml;

/// <summary>
/// XML文件存储基类
/// http://www.cnblogs.com/zery/p/3362480.html
/// http://outofmemory.cn/code-snippet/15449/C-define-process-xml-data-class
/// XPath语法：http://www.cnblogs.com/zengsiyu/articles/1525195.html
/// </summary>
public abstract class XmlBase 
{
    protected string path;
    protected string rootName;

    public void Init()
    {
        if (path == null)
        {
            Console.WriteLine("xml 路径为空");
            return;
        }

        if (!File.Exists(path))
        {
            create();
        }

        //Console.WriteLine("文件初始化完成 : "+ path);
    }

    /// <summary>
    /// 创建XML文件
    /// </summary>
    void create()
    {
        XmlDocument doc = new XmlDocument();

        XmlDeclaration xmlDeclar;
        xmlDeclar = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        doc.AppendChild(xmlDeclar);

        XmlElement xmlElement = doc.CreateElement(rootName);
        doc.AppendChild(xmlElement);

        doc.Save(path);

        Console.WriteLine("【创建文件】" + path);
    }

    /// <summary>
    /// 读取XML文件
    /// </summary>
    public XmlDocument Load()
    {
        XmlDocument doc = new XmlDocument();

        try
        {
            if (File.Exists(path))
                doc.Load(path);
        }
        catch
        {
            Console.WriteLine("读取XML文件失败");
        }

        return doc;
    }

    /// <summary>
    /// 插入节点
    /// </summary>
    /// <param name="node">节点路径</param>
    /// <param name="element">元素名</param>
    /// <param name="inner">【InnerText】</param>
    public void InsertNode(string node, string element, string inner)
    {
        if (node.Equals(""))
        {
            Console.WriteLine("插入节点失败，父节点不能为空！");
            return;
        }

        if (element.Equals(""))
        {
            Console.WriteLine("插入节点失败，要插入的节点不能为空！");
            return;
        }

        XmlDocument doc = Load();
        XmlNode xn = doc.SelectSingleNode(node);

        if (xn == null)
        {
            Console.WriteLine("指定父节点不存在！");
            return;
        }
        

        XmlElement xe = doc.CreateElement(element);

        if (!inner.Equals(""))
            xe.InnerText = inner;

        xn.AppendChild(xe);

        doc.Save(path);
    }

    /// <summary>
    /// 插入节点
    /// </summary>
    /// <param name="node">节点路径</param>
    /// <param name="element">元素名</param>
    /// <param name="inner">【InnerText】</param>
    /// <param name="attribute">属性名</param>
    /// <param name="value">属性值</param>
    public void InsertNode(string node, string element, string inner, string attribute, string value)
    {
        if (node.Equals(""))
        {
            Console.WriteLine("插入节点失败，父节点不能为空！");
            return;
        }

        if (element.Equals(""))
        {
            Console.WriteLine("插入节点失败，要插入的节点不能为空！");
            return;
        }

        if (attribute.Contains(" "))
        {
            Console.WriteLine("插入节点失败，要插入的属性不能包含空格！");
            return;
        }

        XmlDocument doc = Load();
        XmlNode xn = doc.SelectSingleNode(node);

        if (xn == null)
        {
            Console.WriteLine("指定父节点不存在！");
            return;
        }
        
        XmlElement xe = doc.CreateElement(element);

        if (!attribute.Equals(""))
        {
            xe.SetAttribute(attribute, value);
        }

        if (!inner.Equals(""))
        {
            xe.InnerText = inner;
        }

        xn.AppendChild(xe);

        doc.Save(path);
    }

    /// <summary>
    /// 更新节点
    /// </summary>
    /// <param name="node">节点路径</param>
    /// <param name="inner">【InnerText】</param>
    public void Update(string node, string inner)
    {
        XmlDocument doc = Load();
        XmlNode xn = doc.SelectSingleNode(node);

        if (xn == null)
        {
            Console.WriteLine("指定节点不存在！");
            return;
        }

        if (!inner.Equals(""))
        {
            xn.InnerText = inner;
        }

       // xn.AppendChild(xn);

        doc.Save(path);
    }

    /// <summary>
    /// 更新节点
    /// </summary>
    /// <param name="node">节点路径</param>
    /// <param name="inner">【InnerText】</param>
    /// <param name="attribute">属性名</param>
    /// <param name="value">属性值</param>
    public void Update(string node, string inner, string attribute, string value)
    {
        XmlDocument doc = Load();
        XmlNode xn = doc.SelectSingleNode(node);

        if (xn == null)
        {
            Console.WriteLine("指定节点不存在！");
            return;
        }

        if (!attribute.Equals(""))
        {
            XmlElement xe = (XmlElement)xn;
            xe.SetAttribute(attribute, value);
        }

        if (!inner.Equals(""))
        {
            xn.InnerText = inner;
        }

        //Console.WriteLine("update : " + attribute + " " + value);

        doc.Save(path);
    }

    /// <summary>
    /// 节点是否存在
    /// </summary>
    /// <param name="node">节点</param>
    /// <returns></returns>
    public bool IsNodeExist(string node)
    {
        XmlDocument doc = Load();
        XmlNode xn = doc.SelectSingleNode(node);

        if (xn == null)
            return false;
        else
            return true;
    }

    public int ReadChildCount(string node)
    {
        XmlDocument doc = Load();
        XmlNodeList xns = doc.SelectSingleNode(node).ChildNodes;
        return xns.Count;
    }

    /// <summary>
    /// 删除指定节点
    /// </summary>
    public void Remove(string node)
    {
        if (!IsNodeExist(node))
        {
            Console.WriteLine("节点不存在：" + node);
            return;
        }
            

        XmlDocument doc = Load();
        XmlNode xn = doc.SelectSingleNode(node);
        XmlNode parent = xn.ParentNode;
        parent.RemoveChild(xn);

        doc.Save(path);

        Console.WriteLine("节点已删除：" + node);
    }

    /// <summary>
    /// 删除所有子节点
    /// </summary>
    /// <param name="node">节点</param>
    public void RemoveAllChilds(string node)
    {
        XmlDocument doc = Load();
        XmlNode xn = doc.SelectSingleNode(node);

        while (xn.HasChildNodes)
        {
            xn.RemoveChild(xn.FirstChild);
        }
        //xn.RemoveAll();

        doc.Save(path);
    }

    /// <summary>
    /// 读取节点的 InnerText 值
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public string ReadInnerText(string node)
    {
        XmlDocument doc = Load();
        XmlNode xn = doc.SelectSingleNode(node);

        return xn.InnerText;
    }

    /// <summary>
    /// 读取节点的属性值
    /// </summary>
    /// <param name="node"></param>
    /// <param name="attribute"></param>
    /// <returns></returns>
    public string ReadAttributeValue(string node, string attribute)
    {
        XmlDocument doc = Load();
        XmlNode xn = doc.SelectSingleNode(node);

        XmlElement xe = (XmlElement)xn;

        return xe.GetAttribute(attribute);
    }

    

}
