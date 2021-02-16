using System.Collections.Generic;

namespace ff8_card_manip
{
    public class EarlyQuistisStateTable
    {
        private static Dictionary<string, EarlyQuistisState> _table = new Dictionary<string, EarlyQuistisState>();

        static EarlyQuistisStateTable()
        {
            _table.Add("luzbelheim", new EarlyQuistisState()
            {
                Unused = 0x0000_0001,
                Elastoid = 0x1340_eb2b,
                Malboro = 0x5f22_3d12,
                Wedge = 0x1f13_2481,
            });

            _table.Add("pingval", new EarlyQuistisState()
            {
                Unused = 0x0000_0001,
                Elastoid = 0x1de5_b942,
                Malboro = 0x963c_b5e4,
                Wedge = 0x1f13_2481,
            });
        }

        public static EarlyQuistisState Get(string key)
        {
            return _table[key];
        }
    }
}
