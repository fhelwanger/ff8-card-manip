using System;
using System.Linq;
using System.Threading;

namespace ff8_card_manip
{
    class Program
    {
        private static Options _options = new Options()
        {
            EarlyQuistis = "luzbelheim",
            Player = "zellmama",
            DelayFrame = 285,
            ConsoleFps = 60,
            ForcedIncr = 10,
            AcceptDelayFrame = 3
        };

        static void Main(string[] args)
        {
            //args = new[] {"1", "477"};

            var (firstState, state, count, searchType) = ReadArgs(args);
            var player = PlayerTable.Get(_options.Player);

            if (searchType == TSearchType.First)
            {

            }
            else
            {
                RareSearch(state, player, counting: searchType == TSearchType.Counting);
            }
        }

        static void RareSearch(uint state, Player player, bool counting = false)
        {
            RareTimer(state, player);
        }

        static void RareTimer(uint state, Player player)
        {
            var fps = _options.ConsoleFps;

            var start = ((DateTime.Now - DateTime.UnixEpoch).TotalSeconds);
            var delay = _options.DelayFrame / 60f;

            var incr = 0U;
            var incrStart = delay - (_options.ForcedIncr / 60f);
            var timerWidth = 8;
            var width = Math.Min(Console.WindowWidth - 1 - timerWidth, 60);

            var header = "timer".PadRight(timerWidth) + "! ";
            Console.WriteLine(header);

            while (true)
            {
                var duration = ((DateTime.Now - DateTime.UnixEpoch).TotalSeconds) - start;

                incr = (uint)Math.Max(
                    Math.Round((duration - incrStart) * 60),
                    _options.ForcedIncr + _options.AcceptDelayFrame
                );

                if (incr <= _options.ForcedIncr + _options.AcceptDelayFrame)
                {
                    incr = _options.ForcedIncr;
                }

                var rareTbl = new int[width].Select((_, idx) => NextRare(state + incr + (uint)idx, player.RareLimit));

                var durationS = (duration - delay).ToString("0.00") + "s" + (rareTbl.First() ? "!" : "");

                var tableS = rareTbl.Select((x, i) =>
                {
                    if (x) return "*";
                    else if (i == 0) return "!";
                    else return "-";
                }).Aggregate((acc, x) => acc + x);

                Console.CursorVisible = false;
                Console.Write(durationS.PadRight(timerWidth) + tableS + "\r");

                Thread.Sleep(1000 / fps);
            }
        }

        static bool NextRare(uint state, int limit)
        {
            var nextRnd = ((state * 0x10dcd + 1) & 0xffff_ffff) >> 17;
            return nextRnd % 100 < limit;
        }

        static (uint firstState, uint state, int count, TSearchType searchType) ReadArgs(string[] args)
        {
            var s = args[0];
            var earlyQuistisTable = EarlyQuistisStateTable.Get(_options.EarlyQuistis);
            var firstState = 0U;
            var searchType = TSearchType.First;

            switch (s)
            {
                case "0": // Unused
                    firstState = earlyQuistisTable.Unused;
                    break;
                case "1": // Elastoid
                    firstState = earlyQuistisTable.Elastoid;
                    break;
                case "2": // Malboro
                    firstState = earlyQuistisTable.Malboro;
                    break;
                case "3": // Wedge
                    firstState = earlyQuistisTable.Wedge;
                    break;
                default: // Hex state
                    firstState = Convert.ToUInt32(s, fromBase: 16);
                    searchType = TSearchType.Recovery;
                    break;
            }

            var state = firstState;
            var count = 0;

            if (args.Length > 1)
            {
                count = int.Parse(args[1]);
                var rng = new CardRng(firstState);

                for (var i = 0; i < count; i++)
                {
                    rng.Next();
                }

                state = rng.State;
                searchType = TSearchType.Counting;
            }

            return (firstState, state, count, searchType);
        }

        enum TSearchType
        {
            First,
            Recovery,
            Counting,
        }
    }
}
