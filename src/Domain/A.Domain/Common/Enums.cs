namespace A.Domain.Common
{
    public enum OrderStatus
    {
        NotStarted = 0,
        InProgress = 1,
        Completed = 2,
        Failed = 3
    }

    public enum PromotionType
    {
        CurrentMonthSpecial,
        BOGOF,
        SpendAndSave
    }
}
