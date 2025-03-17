using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Tarrocco.MAUI.Data.Repositories;
using Tarrocco.MAUI.Models;

namespace Tarrocco.MAUI.ViewModels;

public class FortunePageViewModel : INotifyPropertyChanged
{
    public ICommand GoBackCommand { get; }

    private static List<Card> _cardRepo = CardRepository.GetCards();
    public List<Card> Cards = new List<Card>(_cardRepo);

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

    public FortunePageViewModel()
    {
        FortuneCards = new ObservableCollection<Card>();
        GoBackCommand = new Command(GoBack);
    }

    private void OnPropertyChanged(string property)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }

    public void PickThreeCards()
    {
        Cards = new List<Card>(_cardRepo);
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
