﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CFM.Infrastructure.Constants;
using CFM.Infrastructure.Interfaces;
using CFM.ProfessorModule.ViewModels;
using MahApps.Metro.Controls;
using Microsoft.Practices.Unity;
using Prism.Regions;

namespace CFM.ProfessorModule.Views
{
    /// <summary>
    /// Interaction logic for NewProfessorView.xaml
    /// </summary>
    public partial class NewProfessorFlyout : Flyout, IFlyoutView, IRegionMemberLifetime
    {
        public NewProfessorFlyout(IUnityContainer container)
        {
            InitializeComponent();
            this.DataContext = container.Resolve<NewProfessorFlyoutModel>();
        }

        public string FlyoutName => FlyoutNames.NewProfessorFlyout;

        public bool KeepAlive
        {
            get { return false; }
        }
    }
}
