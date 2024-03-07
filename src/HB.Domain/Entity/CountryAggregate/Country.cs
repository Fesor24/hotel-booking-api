namespace HB.Domain.Entity.CountryAggregate;
public sealed class Country : BaseEntity
{
    public string Code { get; set; }
    public string Name { get; set; }
    public List<State> States { get; set; }
}

public class State
{
    public string Name { get; set; }
    public string Code { get; set; }
}
