namespace Codespirals.Base
{
    public interface IApproval
    {
        public static abstract string Unchecked { get; }
        public static abstract string Pending { get; }
        public static abstract string Approved { get; }
        public static abstract string Denied { get; }
        public static abstract string Retracted { get; }
    }
}
