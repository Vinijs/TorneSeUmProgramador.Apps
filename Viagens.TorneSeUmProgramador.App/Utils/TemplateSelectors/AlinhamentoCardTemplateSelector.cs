namespace Viagens.TorneSeUmProgramador.App.Utils.TemplateSelectors;

public sealed class AlinhamentoCardTemplateSelector : DataTemplateSelector
{
    public DataTemplate ItemParTemplate { get; set; }
    public DataTemplate ItemImparTemplate { get; set; }
    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var collection = container as CollectionView;

        if(collection is not null)
        {
            var index = collection.ItemsSource.Cast<object>().ToList().IndexOf(item);

            return index % 2 == 0 ? ItemParTemplate : ItemImparTemplate;
        }

        return ItemParTemplate;
    }
}
