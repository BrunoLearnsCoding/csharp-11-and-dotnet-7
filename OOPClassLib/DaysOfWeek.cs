[Flags]
public enum DaysOfWeek : byte {
    None =      0b_0000_0000,
    Saturday =  0b_0000_0001,
    Sunday =    0b_0000_0010,
    Monday =    0b_0000_0100,
    Tuesday =   0b_0000_1000,
    Wednesday = 0b_0001_0000,
    Thursday =  0b_0010_0000,
    Friday =    0b_0100_0000
}