﻿using TodoApp.TorneSeUmProgramador.App.Views;

namespace TodoApp.TorneSeUmProgramador.App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AdicionarEditarTarefa();
        }
    }
}
