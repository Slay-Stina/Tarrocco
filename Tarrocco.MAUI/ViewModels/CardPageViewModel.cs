using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using Tarrocco.MAUI.Data.Repositories;
using Tarrocco.MAUI.Models;

namespace Tarrocco.MAUI.ViewModels;

class CardPageViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private ObservableCollection<Card> _cards;
    public ObservableCollection<Card> Cards
    {
        get => _cards;
        set
        {
            _cards = value;
            OnPropertyChanged(nameof(Cards));
        }
    }

    private void OnPropertyChanged(string property)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }

    public CardPageViewModel()
    {
        Cards = new ObservableCollection<Card>();
        LoadCardsAsync();
    }

    private async void LoadCardsAsync()
    {
        var sw = new Stopwatch();
        sw.Start();
        var cards = await new CardRepository(new TarroccoContext()).GetAllCardsAsync();
        foreach (var card in cards)
        {
            Cards.Add(card);
        }
        sw.Stop();
        Debug.WriteLine(sw.Elapsed.TotalMilliseconds);
    }
}
