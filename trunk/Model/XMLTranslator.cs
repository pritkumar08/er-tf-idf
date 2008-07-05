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
                    XmlNodeList paragraphs = xmlDoc.SelectNodes("/paragraph");
                    foreach (XmlNode node in paragraphs)
                    {
                        XmlAttributeCollection coll = node.Attributes;
                        int id = Int32.Parse(coll.Item(0).Value);
                        double weight = Double.Parse(coll.Item(1).Value);
                        string body = node.Value;
                        ModelParagraph par = new ModelParagraph(body, id, weight);
                        AddReadParagraphsNodes(node.SelectNodes("/paragraph"), ref par);
                        AddReadHeaderNodes(node.SelectNodes("/header"), ref par);
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
                    XmlTextWriter writer = new XmlTextWriter(path, null);
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Document");
                    AddWritenParagraphNodes(ref writer, doc.DocumentParagraphs);
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }

            private static void AddReadParagraphsNodes(XmlNodeList paragraphs,ref ModelParagraph par)
            {
                foreach (XmlNode node in paragraphs)
                {
                    XmlAttributeCollection coll = node.Attributes;
                    int id = Int32.Parse(coll.Item(0).Value);
                    double weight = Double.Parse(coll.Item(1).Value);
                    string body = node.Value;
                    ModelParagraph paragraph = new ModelParagraph(body, id, weight);
                    AddReadParagraphsNodes(paragraphs, ref par);
                    AddReadHeaderNodes(node.SelectNodes("/header"), ref paragraph);
                    par.AddNewElementToParagraph(paragraph);
                }
            }

            private static void AddReadHeaderNodes(XmlNodeList paragraphs, ref ModelParagraph par)
            {
                foreach (XmlNode node in paragraphs)
                {
                    XmlAttributeCollection coll = node.Attributes;
                    double weight = Double.Parse(coll.Item(0).Value);
                    string title = node.Value;
                    ModelHeader header = new ModelHeader(title,weight);
                    par.AddNewElementToParagraph(header);
                }
            }


            private static void AddWritenParagraphNodes(ref XmlTextWriter writer, LinkedList<ModelDocumentItem> items)
            {
                foreach (ModelDocumentItem item in items)
                {
                    if (item is ModelParagraph)
                    {
                        ModelParagraph par = (ModelParagraph)item;
                        writer.WriteStartElement("Paragraph");
                        writer.WriteString(par.ParagraphBody);
                        writer.WriteAttributeString("pid", par.ParagraphID.ToString());
                        writer.WriteAttributeString("weight", par.DocumentItemWeight.ToString());
                        AddWritenParagraphNodes(ref writer, par.ParagraphItems);
                        writer.WriteEndElement();
                    }
                    if (item is ModelHeader)
                    {
                        ModelHeader header = (ModelHeader)item;
                        writer.WriteElementString("header", header.HeaderTitle);
                        writer.WriteAttributeString("weight", header.DocumentItemWeight.ToString());
                        writer.WriteEndElement();
                    }
                }
            }

        #endregion
    }
}
