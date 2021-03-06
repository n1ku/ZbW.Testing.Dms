﻿using System;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.Dms.Client.Model
{
    internal class MetadataItemXml
    {
        private XDocument _xml;
        private PropertyInfo[] _documentFields;
        private DocumentDetailViewModel Document { get; set; }
        private Configuration _configfile;

        public Configuration Configfile
        {
            get => _configfile;
            set => _configfile = value;
        }

        private XDocument Xml { get; set; }
        public MetadataItemXml(DocumentDetailViewModel doc)
        {
            Document = doc;
            Configfile = Document.Config;
            /**
            var properties = doc.GetType().GetProperties();
            foreach (var property in properties)
            {
                for (int i = 0; i > 0; i++)
                {
                    this._documentFields[i] = property;
                }
            }*/

            Xml = new XDocument();


        }

        public void GenerateMetaFile()
        {
            string docType = Document.SelectedTypItem;
            bool isContract = docType.Equals("Verträge");
            bool isInvoice = docType.Equals("Quittungen");
            _documentFields = Document.GetType().GetProperties();
            Xml.Add(new XComment("Generated by ZbW.Testing.Dms"));
            Xml.Add(new XElement("Document",
                new XAttribute("creationTime", Document.Erfassungsdatum.ToString("O")),
                new XAttribute("createdBy", Document.Benutzer),
                new XAttribute("sourcePath", Document.FilePath),
                new XAttribute("originalFileDeleted", Document.IsRemoveFileEnabled),

                new XElement("Records", new XAttribute("description", "GUI inputs"),
                    new XElement("Record", new XAttribute("documentType", docType),
                        new XElement("Description", new XAttribute("dataType", "String"), Document.Bezeichnung),
                        new XElement("ValutaDate", new XAttribute("dataType", "DateTime"), Document.ValutaDatum),
                        new XElement("DocType", new XAttribute("dataType", "String"),
                            new XAttribute("isContractType", isContract), new XAttribute("isInvoiceType", isInvoice),
                            Document.SelectedTypItem),
                        new XElement("Tags", new XAttribute("dataType", "String"), Document.Stichwoerter),
                        new XElement("EntryCreationDate", new XAttribute("dataType", "DateTime"),
                            Document.Erfassungsdatum),
                        new XElement("CreatorsUserId", new XAttribute("dataType", "String"), Document.Benutzer)
                        )
                    )
                )
            );
            string dsc = Document.Bezeichnung;
            string typ = Document.SelectedTypItem;
            DateTime now = DateTime.Now;
            string metaFile = Configfile.RepoLocationPath + "\\" + "DMS-" + dsc + "-" + typ + "_" + 
                              now.Millisecond + now.Second + now.Minute +
                              now.Day+ now.Month + now.Year + ".xml";

            Xml.Save(metaFile);


            /** dynamic implementation
            foreach (PropertyInfo fld in _documentFields)
            {
                var fldName = fld.Name;
                Xml.Add(new XElement(fldName, Document.));
            }*/

        }

        public XDocument 

    }
}