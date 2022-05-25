using System;

namespace Quest
{
    public class Prize
    {
        private string _text { get; }
        public Prize(string _t)
        {
            _text = _t;
        }

        public void ShowPrize(Adventurer a)
        {
            if (a.Awesomeness > 0)
            {
                for (int i = 0; i < a.Awesomeness; i++)
                {
                    Console.WriteLine($"Your prize is {_text}");
                }
            }
            else
            {
                Console.WriteLine("I thought you said you were an adventurer...");
            }
        }
    }
}