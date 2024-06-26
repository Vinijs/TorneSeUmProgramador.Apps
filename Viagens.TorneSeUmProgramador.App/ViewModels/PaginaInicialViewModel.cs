using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Viagens.TorneSeUmProgramador.Core.Dtos;

namespace Viagens.TorneSeUmProgramador.App.ViewModels;

public sealed partial class PaginaInicialViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<MaisBuscadosDto> maisBuscados;
    public PaginaInicialViewModel()
    {
        MaisBuscados = new()
        {
            new MaisBuscadosDto
            {
                Imagem = "https://images.unsplash.com/photo-1490644658840-3f2e3f8c5625?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Titulo = "Nova York",
                Descricao = "Distância 2500 - mi"
            },
            new MaisBuscadosDto
            {
                Imagem = "https://images.unsplash.com/photo-1490644658840-3f2e3f8c5625?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Titulo = "Nova York",
                Descricao = "Distância 2500 - mi"
            },
            new MaisBuscadosDto
            {
                Imagem = "https://images.unsplash.com/photo-1490644658840-3f2e3f8c5625?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Titulo = "Nova York",
                Descricao = "Distância 2500 - mi"
            },
            new MaisBuscadosDto
            {
                Imagem = "https://images.unsplash.com/photo-1490644658840-3f2e3f8c5625?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Titulo = "Nova York",
                Descricao = "Distância 2500 - mi"
            },
            new MaisBuscadosDto
            {
                Imagem = "https://images.unsplash.com/photo-1490644658840-3f2e3f8c5625?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Titulo = "Nova York",
                Descricao = "Distância 2500 - mi"
            }
        };
    }
}
