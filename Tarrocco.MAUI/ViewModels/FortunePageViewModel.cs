using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Tarrocco.MAUI.Models;
using Tarrocco.MAUI.Views;

namespace Tarrocco.MAUI.ViewModels;

public class FortunePageViewModel : INotifyPropertyChanged
{
    public List<Card> Cards = new List<Card>();
    public event PropertyChangedEventHandler? PropertyChanged;
    private ObservableCollection<Card> _fortuneCards;
    public ObservableCollection<Card> FortuneCards
    {
        get => _fortuneCards;
        set
        {
            _fortuneCards = value;
            OnPropertyChanged(nameof(FortuneCards));
        }
    }

    public ICommand GoBackCommand { get; }

    public FortunePageViewModel()
    {
        PopulateCards();
        FortuneCards = new ObservableCollection<Card>();
        GoBackCommand = new Command(GoBack);
    }

    private void OnPropertyChanged(string property)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }

    private void PopulateCards()
    {
        Cards.Clear();
        var cpvm = CardPageViewModel.CPVM();
        foreach (var card in cpvm.Cards)
        {
            Cards.Add(card);
        }
    }

    public void PickThreeCards()
    {
        PopulateCards();
        FortuneCards.Clear();
        Random random = new Random();
        for (int i = 0; i < 3; i++)
        {
            int index = random.Next(Cards.Count);
            FortuneCards.Add(Cards[index]);
            Cards.RemoveAt(index);
        }
    }

    public async void GoBack()
    {
        await Shell.Current.GoToAsync("///MainPage");
    }
}
