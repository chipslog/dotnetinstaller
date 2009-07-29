using System;
using System.ComponentModel;
using System.IO;
using System.Collections.Generic;

namespace InstallerLib
{
    /// <summary>
    /// A component of type "msi" that executes a Windows Installer package.
    /// </summary>
    public class ComponentMsi : Component
    {
        public ComponentMsi()
            : base("msi")
        {
            m_package = "#APPPATH\\mysetup.msi";
        }

        private string m_package;
        [Description("Specifies a full or a relative path to the msi package or an existing product GUID.")]
        public string package
        {
            get { return m_package; }
            set { m_package = value; }
        }

        private string m_cmdparameters;
        [Description("Optional command line parameters for the msiexec program. May contain quotes. See MSDN for the command line you can use with Windows Installer.")]
        public string cmdparameters
        {
            get { return m_cmdparameters; }
            set { m_cmdparameters = value; }
        }

        private string m_cmdparameters_basic = "/qb";
        [Description("Optional command line parameters for the msiexec program when running in basic UI mode.")]
        public string cmdparameters_basic
        {
            get { return m_cmdparameters_basic; }
            set { m_cmdparameters_basic = value; }
        }

        private string m_cmdparameters_silent = "/qn";
        [Description("Optional command line parameters for the msiexec program when running in silent UI mode.")]
        public string cmdparameters_silent
        {
            get { return m_cmdparameters_silent; }
            set { m_cmdparameters_silent = value; }
        }

        protected override void OnXmlWriteTag(XmlWriterEventArgs e)
        {
            e.XmlWriter.WriteAttributeString("package", m_package);
            e.XmlWriter.WriteAttributeString("cmdparameters", m_cmdparameters);
            e.XmlWriter.WriteAttributeString("cmdparameters_silent", m_cmdparameters_silent);
            e.XmlWriter.WriteAttributeString("cmdparameters_basic", m_cmdparameters_basic);
            base.OnXmlWriteTag(e);
        }

        protected override void OnXmlReadTag(XmlElementEventArgs e)
        {
            ReadAttributeValue(e, "package", ref m_package);
            ReadAttributeValue(e, "cmdparameters", ref m_cmdparameters);
            ReadAttributeValue(e, "cmdparameters_silent", ref m_cmdparameters_silent);
            ReadAttributeValue(e, "cmdparameters_basic", ref m_cmdparameters_basic);
            base.OnXmlReadTag(e);
        }
    }
}
