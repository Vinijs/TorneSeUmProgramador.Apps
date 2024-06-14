using CommunityToolkit.Mvvm.Messaging.Messages;
using Todo.TorneSeUmProgramador.Core.Modelos;

namespace TodoApp.TorneSeUmProgramador.App.Messages;

public class EditarTarefaMessage : ValueChangedMessage<Tarefa>
{
    public EditarTarefaMessage(Tarefa value) : base(value)
    {
    }
}
