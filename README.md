# Pure.Chart.Model.Abstractions

Chart model interfaces for the **Pure** ecosystem — immutable, composable abstractions over chart data structures.

[![.NET build & test](https://github.com/kudima03/Pure.Chart.Model.Abstractions/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Chart.Model.Abstractions/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.Chart.Model.Abstractions/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Chart.Model.Abstractions/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.Chart.Model.Abstractions)](https://www.nuget.org/packages/Pure.Chart.Model.Abstractions)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.Chart.Model.Abstractions` defines a set of minimal, read-only interfaces that represent the structural components of a chart. Each interface exposes only getters — no mutation, no side effects. All string properties are typed as `IString` from `Pure.Primitives.Abstractions`, keeping the model decoupled from concrete string representations.

## Interfaces

| Interface | Namespace | Description |
|-----------|-----------|-------------|
| `IChart` | `Pure.Chart.Model.Abstractions` | Root chart model — title, description, type, axes, and series |
| `IChartType` | `Pure.Chart.Model.Abstractions` | Named category of chart (e.g. bar, line, pie) |
| `IChartSeries` | `Pure.Chart.Model.Abstractions` | A single data series — legend label and axis source bindings |
| `IAxis` | `Pure.Chart.Model.Abstractions` | A chart axis with a legend label |

## Design Principles

- **Immutable** — all interfaces expose only `get` properties; no setters, no methods that mutate state.
- **Composable** — `IChart` is built from `IChartType`, `IAxis`, and `IEnumerable<IChartSeries>`; complex structure is expressed through composition.
- **Primitive-typed** — string properties use `IString` from `Pure.Primitives.Abstractions`, not `System.String`, keeping the model framework-agnostic.
- **AOT-compatible** — the library is fully compatible with Native AOT compilation.

## Dependencies

- [`Pure.Primitives.Abstractions`](https://github.com/kudima03/Pure.Primitives.Abstractions/tree/4.3.0) — base interfaces for immutable primitive types (`IString`, `INumber<T>`, etc.)

## Target Frameworks

- .NET 7
- .NET 8
- .NET 9
- .NET 10

## Installation

```shell
dotnet add package Pure.Chart.Model.Abstractions
```

## Usage

Implement the interfaces to model a chart in your domain:

```csharp
using Pure.Chart.Model.Abstractions;
using Pure.Primitives.Abstractions.String;

public sealed class BarChartType : IChartType
{
    public IString Name { get; } = new StringValue("Bar");
}

public sealed class SalesChart : IChart
{
    public IString Title { get; } = new StringValue("Monthly Sales");
    public IString Description { get; } = new StringValue("Sales figures by month");
    public IChartType Type { get; } = new BarChartType();
    public IAxis XAxis { get; } = new MonthAxis();
    public IAxis YAxis { get; } = new RevenueAxis();
    public IEnumerable<IChartSeries> Series { get; } = [new SalesSeries()];
}
```
