# Changelog

All notable changes to Pure.Chart.Model.Abstractions are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [0.1.0-preview.1.0.0] — 2026-04-19

### Changed

- **`ISeries`** renamed to **`IChartSeries`**. `IChart.Series` is now
  `IEnumerable<IChartSeries>`. Consumers implementing or referencing
  `ISeries` must switch to `IChartSeries`.

## [0.1.0-preview.0.1.0] — 2026-02-06

Initial preview release, defining the chart abstraction model.

### Added

- **`IChart`** — top-level chart contract with `Title`, `Description`,
  `Type` (`IChartType`), `XAxis`/`YAxis` (`IAxis`), and
  `Series` (`IEnumerable<ISeries>`).
- **`IChartType`** — chart type contract with a `Name` property.
- **`IAxis`** — axis contract with a `Legend` property.
- **`ISeries`** — data series contract with `Legend`, `XAxisSource`, and
  `YAxisSource` properties.
- Dependency on `Pure.Primitives.Abstractions` for the underlying
  primitive types (`IString`) used throughout the model.
