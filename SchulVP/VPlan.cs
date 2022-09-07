using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Net.Http;

namespace SchulVP
{
    public class VPRaw : vp
    {

        public VPRaw()
        {
            var client = new HttpClient();
            var authenticationString = "schueler:S1w6597";
            var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.UTF8.GetBytes(authenticationString));
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + base64EncodedAuthenticationString);
            Task<Stream> task;
            Stream zugriff;
            try
            {
                task = client.GetStreamAsync($"https://www.stundenplan24.de/10104966/vplan/vdaten/VplanKl{DateTime.Today.ToString("yyyyMMdd")}.xml");
                zugriff = task.Result;
            }
            catch
            {
                task = client.GetStreamAsync($"https://www.stundenplan24.de/10104966/vplan/vdaten/VplanKl.xml");
                zugriff = task.Result;
            }
            
            var reader = new StreamReader(zugriff);
            vp VPTemp = new XmlSerializer(typeof(vp)).Deserialize(reader) as vp;
            reader.Close();
            zugriff.Flush();
            zugriff.Close();
            client.Dispose();
            this.Items = VPTemp.Items;
        }

        
    }



    // HINWEIS: Für den generierten Code ist möglicherweise mindestens .NET Framework 4.5 oder .NET Core/Standard 2.0 erforderlich.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class vp
    {

        private object[] itemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("aufsichten", typeof(vpAufsichten))]
        [System.Xml.Serialization.XmlElementAttribute("freietage", typeof(vpFreietage))]
        [System.Xml.Serialization.XmlElementAttribute("fuss", typeof(vpFuss))]
        [System.Xml.Serialization.XmlElementAttribute("haupt", typeof(vpHaupt))]
        [System.Xml.Serialization.XmlElementAttribute("kopf", typeof(vpKopf))]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class vpAufsichten
    {

        private vpAufsichtenAufsichtzeile[] aufsichtzeileField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("aufsichtzeile")]
        public vpAufsichtenAufsichtzeile[] aufsichtzeile
        {
            get
            {
                return this.aufsichtzeileField;
            }
            set
            {
                this.aufsichtzeileField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class vpAufsichtenAufsichtzeile
    {

        private string aufsichtinfoField;

        /// <remarks/>
        public string aufsichtinfo
        {
            get
            {
                return this.aufsichtinfoField;
            }
            set
            {
                this.aufsichtinfoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class vpFreietage
    {

        private uint[] ftField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ft")]
        public uint[] ft
        {
            get
            {
                return this.ftField;
            }
            set
            {
                this.ftField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class vpFuss
    {

        private vpFussFusszeile[] fusszeileField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("fusszeile")]
        public vpFussFusszeile[] fusszeile
        {
            get
            {
                return this.fusszeileField;
            }
            set
            {
                this.fusszeileField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class vpFussFusszeile
    {

        private string fussinfoField;

        /// <remarks/>
        public string fussinfo
        {
            get
            {
                return this.fussinfoField;
            }
            set
            {
                this.fussinfoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class vpHaupt
    {

        private vpHauptAktion[] aktionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("aktion")]
        public vpHauptAktion[] aktion
        {
            get
            {
                return this.aktionField;
            }
            set
            {
                this.aktionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class vpHauptAktion
    {

        private string klasseField;

        private string stundeField;

        private vpHauptAktionFach fachField;

        private vpHauptAktionLehrer lehrerField;

        private vpHauptAktionRaum raumField;

        private string infoField;

        /// <remarks/>
        public string klasse
        {
            get
            {
                return this.klasseField;
            }
            set
            {
                this.klasseField = value;
            }
        }

        /// <remarks/>
        public string stunde
        {
            get
            {
                return this.stundeField;
            }
            set
            {
                this.stundeField = value;
            }
        }

        /// <remarks/>
        public vpHauptAktionFach fach
        {
            get
            {
                return this.fachField;
            }
            set
            {
                this.fachField = value;
            }
        }

        /// <remarks/>
        public vpHauptAktionLehrer lehrer
        {
            get
            {
                return this.lehrerField;
            }
            set
            {
                this.lehrerField = value;
            }
        }

        /// <remarks/>
        public vpHauptAktionRaum raum
        {
            get
            {
                return this.raumField;
            }
            set
            {
                this.raumField = value;
            }
        }

        /// <remarks/>
        public string info
        {
            get
            {
                return this.infoField;
            }
            set
            {
                this.infoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class vpHauptAktionFach
    {

        private string fageaendertField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string fageaendert
        {
            get
            {
                return this.fageaendertField;
            }
            set
            {
                this.fageaendertField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class vpHauptAktionLehrer
    {

        private string legeaendertField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string legeaendert
        {
            get
            {
                return this.legeaendertField;
            }
            set
            {
                this.legeaendertField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class vpHauptAktionRaum
    {

        private string rageaendertField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string rageaendert
        {
            get
            {
                return this.rageaendertField;
            }
            set
            {
                this.rageaendertField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class vpKopf
    {

        private string dateiField;

        private string titelField;

        private object schulnameField;

        private string datumField;

        private vpKopfKopfinfo kopfinfoField;

        /// <remarks/>
        public string datei
        {
            get
            {
                return this.dateiField;
            }
            set
            {
                this.dateiField = value;
            }
        }

        /// <remarks/>
        public string titel
        {
            get
            {
                return this.titelField;
            }
            set
            {
                this.titelField = value;
            }
        }

        /// <remarks/>
        public object schulname
        {
            get
            {
                return this.schulnameField;
            }
            set
            {
                this.schulnameField = value;
            }
        }

        /// <remarks/>
        public string datum
        {
            get
            {
                return this.datumField;
            }
            set
            {
                this.datumField = value;
            }
        }

        /// <remarks/>
        public vpKopfKopfinfo kopfinfo
        {
            get
            {
                return this.kopfinfoField;
            }
            set
            {
                this.kopfinfoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class vpKopfKopfinfo
    {

        private string abwesendlField;

        private string abwesendkField;

        private string abwesendrField;

        private string aenderunglField;

        private string aenderungkField;

        /// <remarks/>
        public string abwesendl
        {
            get
            {
                return this.abwesendlField;
            }
            set
            {
                this.abwesendlField = value;
            }
        }

        /// <remarks/>
        public string abwesendk
        {
            get
            {
                return this.abwesendkField;
            }
            set
            {
                this.abwesendkField = value;
            }
        }

        /// <remarks/>
        public string abwesendr
        {
            get
            {
                return this.abwesendrField;
            }
            set
            {
                this.abwesendrField = value;
            }
        }

        /// <remarks/>
        public string aenderungl
        {
            get
            {
                return this.aenderunglField;
            }
            set
            {
                this.aenderunglField = value;
            }
        }

        /// <remarks/>
        public string aenderungk
        {
            get
            {
                return this.aenderungkField;
            }
            set
            {
                this.aenderungkField = value;
            }
        }
    }


}
