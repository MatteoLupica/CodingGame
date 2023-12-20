using System;
using System.Collections.Generic;

public class Game
{
    private static readonly Dictionary<string, int> KARTS = new Dictionary<string, int>
    {
        {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5}, {"6", 6}, {"7", 7}, {"8", 8},
        {"9", 9}, {"10", 10}, {"J", 11}, {"Q", 12}, {"K", 13}, {"A", 14}
    };

    private List<string> _player1deck = new List<string>();
    private List<string> _player2deck = new List<string>();
    private List<string> _player1table = new List<string>();
    private List<string> _player2table = new List<string>();
    private string _winner = "PAT";
    private int _round = 0;
    private bool _war = false;

    public Game()
    {
        int n = int.Parse(Console.ReadLine());
        ReadDeck(n, _player1deck);
        int m = int.Parse(Console.ReadLine());
        ReadDeck(m, _player2deck);
    }

    private void ReadDeck(int count, List<string> deck)
    {
        for (int i = 0; i < count; i++)
        {
            deck.Add(Console.ReadLine());
        }
    }

    public void PrintResult() =>
        Console.WriteLine(_winner == "PAT" ? "PAT" : $"{_winner} {_round}");

    public void DragKarts(int n = 1)
    {
        DragKartsFromDeck(_player1deck, _player1table, n);
        DragKartsFromDeck(_player2deck, _player2table, n);
    }

    private void DragKartsFromDeck(List<string> sourceDeck, List<string> targetTable, int n)
    {
        targetTable.AddRange(sourceDeck.GetRange(0, n));
        sourceDeck.RemoveRange(0, n);
    }

    public void PlayerGotAll(int np)
    {
        List<string> currentTable = np == 1 ? _player1table : _player2table;
        List<string> currentDeck = np == 1 ? _player1deck : _player2deck;

        currentDeck.AddRange(currentTable);
        currentTable.Clear();
    }

    public void CheckCarts()
    {
        int p1Kart = KARTS[_player1table[^1].Substring(0, _player1table[^1].Length - 1)];
        int p2Kart = KARTS[_player2table[^1].Substring(0, _player2table[^1].Length - 1)];

        if (p1Kart > p2Kart)
        {
            PlayerGotAll(1);
            _war = false;
        }
        else if (p1Kart < p2Kart)
        {
            PlayerGotAll(2);
            _war = false;
        }
        else
        {
            _war = true;
        }
    }

    public bool HaveEnoughKarts(int n)
    {
        int len1 = _player1deck.Count;
        int len2 = _player2deck.Count;

        if (len1 >= n && len2 >= n)
        {
            return true;
        }
        else
        {
            if (_war || len1 - n < 0 && len2 - n < 0)
            {
                _winner = "PAT";
            }
            else
            {
                _winner = len1 > len2 ? "1" : "2";
            }

            return false;
        }
    }

    public bool Play()
    {
        if (_war && !HaveEnoughKarts(3))
        {
            return false;
        }

        if (!HaveEnoughKarts(1))
        {
            return false;
        }

        if (!_war)
        {
            RoundPlus();
        }

        DragKarts();
        CheckCarts();

        return true;
    }

    public void RoundPlus() => _round++;

    public void Run()
    {
        while (Play())
        {
        }
        PrintResult();
    }
}

class Program
{
    static void Main()
    {
        Game game = new Game();
        game.Run();
    }
}
