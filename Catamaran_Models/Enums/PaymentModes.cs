using System.ComponentModel;

namespace Catamaran_Models.Enums
{
    public enum PaymentModes
    {
        [Description("Cash On Delivery")]
        Cash = 0,
        [Description("Credit Card")]
        CreditCard,
        [Description("Debit Card")]
        DebitCard,
        [Description("Cheque")]
        Cheque,
        [Description("Demand Draft")]
        Draft,
        [Description("Net Banking")]
        NetBanking,
        [Description("Google Pay")]
        GooglePay,
        [Description("Phone Pay")]
        PhonePay,
        [Description("Paytm")]
        Paytm,
        [Description("Dedicated Bank Apps")]
        DedicatedBankApps
    }
}
