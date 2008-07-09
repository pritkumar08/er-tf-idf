using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;
using System.Text;

namespace Model
{
    static class XMLTranslator
    {
        #region XMLTranslator : Members & Consts
            
        #endregion

        #region XMLTranslator : Initialization

        #endregion

        #region XMLTranslator : Properties

        #endregion

        #region XMLTranslator : Events

        #endregion

        #region XMLTranslator : EventHandlers

        #endregion

        #region XMLTranslator : Methods

            internal static ModelDocument ReadFromXML(String path)
            {
                try
                {
                    ModelDocument doc = new ModelDocument();
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(path);
                    XmlNodeList paragraphs = xmlDoc.SelectNodes("/Document/paragraph");
                    foreach (XmlNode node in paragraphs)
                    {
                        XmlAttributeCollection coll = node.Attributes;
                        int id = Int32.Parse(coll.Item(0).Value);
                        double weight = Double.Parse(coll.Item(1).Value);
                        string body = node.InnerText;
                        ModelParagraph par = new ModelParagraph(body, id, weight);
                        AddReadParagraphsNodes(node, ref par);
                        AddReadHeaderNodes(node, ref par);
                        doc.AddParagraph(par);
                    }
                    return doc;
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }

            internal static void WriteToXML(String path, ModelDocument doc)
            {
                try
                {
                    XmlTextWriter writer = new XmlTextWriter(path, System.Text.Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Document");
                    AddWritenParagraphNodes(ref writer, doc.Paragraphs);
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }

            private static void AddReadParagraphsNodes(XmlNode nodes,ref ModelParagraph par)
            {
                foreach (XmlNode node in nodes.SelectNodes("paragraph"))
                {
                    XmlAttributeCollection coll = node.Attributes;
                    int id = Int32.Parse(coll.Item(0).Value);
                    double weight = Double.Parse(coll.Item(1).Value);
                    string body = node.InnerText;
                    ModelParagraph paragraph = new ModelParagraph(body, id, weight);
                    AddReadParagraphsNodes( node, ref par);
                    AddReadHeaderNodes(node, ref paragraph);
                    par.AddNewElementToParagraph(paragraph);
                }
            }

            private static void AddReadHeaderNodes(XmlNode nodes, ref ModelParagraph par)
            {
                foreach (XmlNode node in nodes.SelectNodes("header"))
                {
                    XmlAttributeCollection coll = node.Attributes;
                    double weight = Double.Parse(coll.Item(0).Value);
                    string title = node.InnerText;
                    ModelHeader header = new ModelHeader(title,weight);
                    par.AddNewElementToParagraph(header);
                }
            }


            private static void AddWritenParagraphNodes(ref XmlTextWriter writer, LinkedList<ModelDocumentItem> items)
            {
                foreach (ModelDocumentItem item in items)
                {
                    string text = item.Text;
                    string weight = item.Weight.ToString();
                    if (item is ModelParagraph)
                    {
                        ModelParagraph par = (ModelParagraph)item;
                        writer.WriteStartElement("paragraph");
                        writer.WriteStartAttribute("pid");
                        writer.WriteValue(par.Pid.ToString());
                        writer.WriteEndAttribute();
                        writer.WriteStartAttribute("weight");
                        writer.WriteValue(weight.ToString());
                        writer.WriteEndAttribute();
                        AddWritenParagraphNodes(ref writer, par.Items);
                        writer.WriteString(text);
                        writer.WriteEndElement();
                    }

                    if (item is ModelHeader)
                    {
                        writer.WriteStartElement("header");
                        writer.WriteStartAttribute("weight");
                        writer.WriteValue(weight.ToString());
                        writer.WriteEndAttribute();
                        writer.WriteString(text);
                        writer.WriteEndElement();
                    }
                }
            }

        #endregion
    }
}
