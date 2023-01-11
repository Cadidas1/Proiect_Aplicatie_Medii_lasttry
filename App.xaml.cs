using System;
using Proiect_Aplicatie_Medii_lasttry.Data;
using System.IO;

namespace Proiect_Aplicatie_Medii_lasttry;
 public partial class App : Application
{
    static InchiriereDatabase database;
    public static InchiriereDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               InchiriereDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "Inchiriere.db3"));
            }
            return database;
        }
    }
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();
    }
}