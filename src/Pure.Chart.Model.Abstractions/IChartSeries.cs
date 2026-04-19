using Pure.Primitives.Abstractions.String;

namespace Pure.Chart.Model.Abstractions;

public interface IChartSeries
{
    public IString Legend { get; }

    public IString XAxisSource { get; }

    public IString YAxisSource { get; }
}
