namespace Records_in_C_;

public partial class Program {
    public static void Main(string[] args)
    {
        ProofTemperatureSrtuct();
    }


    private static void ProofTemperatureSrtuct() {
        var poc = new TemperatureProofOfConcept();
        poc.ProofFarenheitToCelsiusConversion(TemperatureProofOfConcept.GetAnArrayWithIncrement(46, 1000000, 0.0001M));
    }

}


