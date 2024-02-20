#pragma warning disable CS1591
#pragma warning disable CS8618


public record UniversitySpendingsModel
{
    public int AllocationYear { get; init; }
    public int UniversityID { get; init; }
    public decimal TotalAmount { get; init; }
    public decimal AmountRemaining { get; init; }
    public List<StudentInfoModel> FundedStudents { get; init; }

}