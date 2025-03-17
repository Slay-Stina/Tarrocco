namespace Tarrocco.MAUI.Contract;

interface ITarotReader
{
    Task<string> GetFortune(string prompt, CollectionView fortuneCardCollection);
}
