using System;
using System.IO;
using System.Windows;
using System.Drawing;
using System.Collections.Generic;

using System.Text;
using Tulpep.NotificationWindow;
using System.Windows.Forms;
using System.Diagnostics;

namespace ConsoleApp3
{
    class Program
    {



        static void Main(string[] args)
        {

            

            FileSystemWatcher observador = new FileSystemWatcher(@"C:\Temporal");
            observador.NotifyFilter = (
                NotifyFilters.LastAccess |
                NotifyFilters.LastWrite |
                NotifyFilters.FileName |
                NotifyFilters.DirectoryName);

           
            observador.Changed += Alcambiar;

            observador.EnableRaisingEvents = true;


            Console.ReadLine();
        }
        

        private static void Alcambiar(object source,FileSystemEventArgs e)
        {
           
            WatcherChangeTypes TipoCambio = e.ChangeType;
            Console.WriteLine("El Archivo {0} tuvo un cambio de {1}",
               
                e.FullPath, TipoCambio.ToString());
        


                 NotifyIcon nb1 = new NotifyIcon();
            nb1.Icon = SystemIcons.Application;
            nb1.Icon = new Icon(@"C:\Temporal\launch_122853.ico");
           
           
            NotifyIcon tray = new NotifyIcon();
            tray.Icon =nb1.Icon;
            tray.Text = "INFORMACIÓN";
           tray.BalloonTipText = "Se ha detectado un cambio en archivo DATA-TEC"; ;

            tray.Visible = true;
            tray.ShowBalloonTip(10);

            System.Diagnostics.ProcessStartInfo start =
      new System.Diagnostics.ProcessStartInfo();
            //start.FileName = dir + @"\Myprocesstostart.exe";
            start.WindowStyle = ProcessWindowStyle.Hidden;

        }
      
        private static void AlRenombrar(object source,FileSystemEventArgs e)
        {
            //Console.WriteLine("El Archivo {0} ahora se llama {1}", e.OldFullPath, e.FullPath);

        }
    }
}
