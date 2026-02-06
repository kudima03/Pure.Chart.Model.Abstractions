using Pure.Primitives.Abstractions.String;

namespace Pure.Chart.Model.Abstractions;

public interface ISeries
{
    public IString Legend { get; }

    public IString XAxisSource { get; }

    public IString YAxisSource { get; }
}
