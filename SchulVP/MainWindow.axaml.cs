using Avalonia.Controls;
using Avalonia.Media;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SchulVP
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void AddInfos(string abwelae, string lehrmae, string klamitae)
        {
            abLe.Content = abwelae;
            lehMiAe.Content = lehrmae;
            klaMiAe.Content = klamitae;
        }

        public void AddInfos(Label[] geAuf, bool geauf)
        {

            if (geauf)
            {
                geAufs.Children.Clear();
                foreach (Label label in geAuf)
                {
                    geAufs.Children.Add(label);
                }
            }
            else
            {
                AddInfos(geAuf);
            }
        }

        public void AddInfos(Label[] zuInfos)
        {
            zuInfosL.Children.Clear();
            foreach (Label label in zuInfos)
            {
                zuInfosL.Children.Add(label);
            }
        }

        public Label GetFromTemplate(string content, bool colored)
        {
            Label Template = new Label();
            Template.BorderBrush = Brushes.Black;
            if (content == null)
            {
                Template.BorderThickness = new Thickness(1);
                Template.Content = "　";
            }
            else if (content == "")
            {
                Template.BorderThickness = new Thickness(1);
                Template.Content = "　";
            }
            else if (content == " ")
            {
                Template.BorderThickness = new Thickness(1);
                Template.Content = "　";
            }
            else
            {
                Template.BorderThickness = new Thickness(1);
                Template.Content = content;
                if (colored)
                {
                    Template.Foreground = Brushes.Red;
                }
            }
            return Template;
        }
        

        private async void Load(object? sender, EventArgs e)
        {

            await Task.Delay(5000);
            this.Cursor = new Avalonia.Input.Cursor(Avalonia.Input.StandardCursorType.None);
            retry:
            try
            {
                while (true)
                {
                    foreach (object Item in new VPRaw().Items)
                    {
                        main.IsVisible = true;
                        error.IsVisible = false;
                        if (Item is vpKopf)
                        {
                            vpKopf item = (vpKopf)Item;

                            AddInfos(item.kopfinfo.abwesendl, item.kopfinfo.aenderungl, item.kopfinfo.aenderungk);
                            woche.Content = item.titel.Split('(')[1].Replace(')', ' ');

                        }


                        if (Item is vpFuss)
                        {
                            vpFuss item = (vpFuss)Item;
                            List<Label> labels = new List<Label>();
                            foreach (vpFussFusszeile zeile in item.fusszeile)
                            {
                                labels.Add(new Label() { Content = zeile.fussinfo });
                            }
                            AddInfos(labels.ToArray());
                        }
                        if (Item is vpAufsichten)
                        {
                            vpAufsichten item = (vpAufsichten)Item;
                            List<Label> labels = new List<Label>();
                            foreach (vpAufsichtenAufsichtzeile zeile in item.aufsichtzeile)
                            {
                                labels.Add(new Label() { Content = zeile.aufsichtinfo });
                            }
                            AddInfos(labels.ToArray(), true);
                        }

                        if (Item is vpHaupt)
                        {
                            Klasse.Children.Clear();
                            Stunde.Children.Clear();
                            Fach.Children.Clear();
                            Lehrer.Children.Clear();
                            Raum.Children.Clear();
                            Info.Children.Clear();
                            vpHaupt item = (vpHaupt)Item;
                            foreach (vpHauptAktion aktion in item.aktion)
                            {
                                Klasse.Children.Add(GetFromTemplate(aktion.klasse, false));
                                Stunde.Children.Add(GetFromTemplate(aktion.stunde, false));
                                Fach.Children.Add(GetFromTemplate(aktion.fach.Value, aktion.fach.fageaendert == "ae"));
                                Lehrer.Children.Add(GetFromTemplate(aktion.lehrer.Value, aktion.lehrer.legeaendert == "ae"));
                                Raum.Children.Add(GetFromTemplate(aktion.raum.Value, aktion.raum.rageaendert == "ae"));
                                Info.Children.Add(GetFromTemplate(aktion.info, false));
                            }
                        }

                    }
                    await Task.Delay(TimeSpan.FromMinutes(15));
                }
            }
            catch(Exception ex)
            {
                main.IsVisible = false;
                error.IsVisible = true;
                await Task.Delay(TimeSpan.FromMinutes(1));
                goto retry;
            }

        }

        public static int Datum(vpKopf kopf)
        {
            return Convert.ToInt32(kopf.titel.Split(',')[1].Split('.')[0].Trim());
        }
    }
}
