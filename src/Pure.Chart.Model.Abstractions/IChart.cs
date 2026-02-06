using System.Collections.Generic;
using Pure.Primitives.Abstractions.String;

namespace Pure.Chart.Model.Abstractions;

public interface IChart
{
    public IString Title { get; }

    public IString Description { get; }

    public IChartType Type { get; }

    public IAxis XAxis { get; }

    public IAxis YAxis { get; }

    public IEnumerable<ISeries> Series { get; }
}
