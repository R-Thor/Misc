using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace CSharp_XSLT_HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            string xmlfile = "RDLC.xml";
            string textfile = "RDLC.html";
            xslt.Load("RDLC.xslt");
            xslt.Transform(xmlfile, textfile);
            FileInfo fi = new FileInfo(textfile);
            FileStream fs = fi.OpenRead();
            byte[] filebytes = new byte[fs.Length];
            fs.Read(filebytes,0, filebytes.Length);
            string output = Encoding.UTF8.GetString(filebytes);
            Console.Write(output);
            //XslCompiledTransform xslt = new XslCompiledTransform();
            //xslt.Load(typeof(Transform));

            ////// Execute the transformation and output the results to a file.
            ////xslt.Transform("books.xml", "discount_books.html");
            //XPathDocument myXPathDoc = new XPathDocument(myXmlFile);
            //XslTransform myXslTrans = new XslTransform();
            //myXslTrans.Load(myStyleSheet);
            //XmlTextWriter myWriter = new XmlTextWriter("result.html", null);
            //myXslTrans.Transform(myXPathDoc, null, myWriter);
        }
    }
}
