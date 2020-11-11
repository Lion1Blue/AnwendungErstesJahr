using System.Numerics;
using System.Windows.Forms;
using WinFormMVC.Model;

namespace WinFormMVC.Controller
{
    public interface IUsersView
    {
        void SetController(Controller controller);

        //Fractional Arithmetic
        Fraction FractionA                  { get; set; }
        Fraction FractionB                  { get; set; }
        Fraction FractionResult             { get; set; }

        //Numbersystems
        string NumbersystemText             { get; set; }

        //BooleanAlgebra
        DataGridView BooleanAlgebraInput    { get; }
        DataGridView BooleanAlgebraOutput   { get; }

        //Matrices
        DataGridView MatrixA                { get; }
        DataGridView MatrixB                { get; set; }
        DataGridView MatrixGauß             { get; }
        DataGridView MatrixResult           { get; set; }

        //SortingAlgorithms
        DataGridView SortingTable           { get; set; }
        PictureBox SortingPictureBox        { get; set; }
        int SortingMinValue                 { get; set; }
        int SortingMaxValue                 { get; set; }
        int SortingColumns                  { get; set; }
        int SortingRows                     { get; set; }

        //PolynomialFunction
        DataGridView FunctionsGrid { get; set; }
        PictureBox FunctionsGraph  { get; set; }
        float NewtonXStart         { get; }
        float NewtonZero           {      set; }
        float FunctionsXMin        { get; set; }
        float FunctionsXMax        { get; set; }
        float FunctionsYMin        { get; set; }
        float FunctionsYMax        { get; set; }
        int SleepTime              { get; }

        //GraphAlgorithms
        uint StartValueGraphAlgorithm   { get; }
        Graph Graph                     { get; }
        string InvokeRTB                { set; }

        //RSA Encryption
        BigInteger PrimeP       { get; }
        BigInteger PrimeQ       { get; }
        BigInteger E            { get; }
        string Message          { get; }
        string EncryptedMessage {      set; }
        string DecryptedMessage {      set; }
        string PrivateKey       {      set; }
        string PublicKey        {      set; }
        string WarningMessage   { get; set; }


    }   
}
