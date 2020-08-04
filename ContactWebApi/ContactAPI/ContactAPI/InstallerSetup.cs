using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Xml;

namespace ContactAPI
{
    [RunInstaller(true)]
    public partial class InstallerSetup : Installer
    {
        public InstallerSetup()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);

            string targetSite = Context.Parameters["targetsite"];
            string targetVDir = Context.Parameters["targetvdir"];
            string targetDirectory = Context.Parameters["targetdir"];

            if (targetSite == null)
                throw new InstallException("IIS Site Name Not Specified!");

            string userProvidedConnStr = Context.Parameters["CONNSTR"];

            string path = targetDirectory + "/Web.config";
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);

            XmlNode nodeRestaurantManager = xDoc.SelectSingleNode("/configuration/connectionStrings");
            foreach (XmlNode xnn in nodeRestaurantManager.ChildNodes)
            {
                if (xnn.NodeType == XmlNodeType.Comment)
                {
                }
                else
                {
                    xnn.Attributes["connectionString"].Value = userProvidedConnStr;
                }
            }
            xDoc.Save(path); // saves the web.config file 
        }
    }
}
