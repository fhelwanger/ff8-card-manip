namespace ff8_card_manip
{
    public class Options
    {
        public uint Base { get; set; }
        public uint Width { get; set; }
        public uint RecoveryWidth { get; set; }
        public uint CountingWidth { get; set; }
        public uint CountingFrameWidth { get; set; }
        public string EarlyQuistis { get; set; }
        public int AutofireSpeed { get; set; }
        public int DelayFrame { get; set; }
        public string RanksOrder { get; set; }
        public int[] StrongHighlightCards { get; set; }
        public int[] HighlightCards { get; set; }
        public TOrder Order { get; set; }
        public int ConsoleFps { get; set; }
        public string Player { get; set; }
        public string[] Fuzzy { get; set; }
        public uint ForcedIncr { get; set; }
        public int AcceptDelayFrame { get; set; }
        public string Prompt { get; set; }

        public enum TOrder
        {
            Reverse,
            Descending,
            Ascending,
        }
    }
}
