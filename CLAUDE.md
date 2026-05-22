# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

All `dotnet` commands must be run from the `./src` directory.

```bash
dotnet restore                                # restore dependencies
dotnet build --no-restore -warnaserror        # build (treats warnings as errors)
dotnet format --verify-no-changes             # check code style (CI enforces this)
dotnet format && csharpier format .           # auto-fix code style
dotnet pack --configuration Release -p:PackageVersion=<version> --output .  # pack NuGet
```

There are no test projects in this repository — the CI pipeline only builds and checks formatting.

## Architecture

This is an **interfaces-only NuGet library** — no implementations, no tests. Every file defines exactly one interface.

**Public API surface:**

- `IChart` — root chart model; exposes `Title`, `Description` (`IString`), `Type` (`IChartType`), `XAxis`/`YAxis` (`IAxis`), and `Series` (`IEnumerable<IChartSeries>`)
- `IChartType` — names a chart category via a single `Name` (`IString`) property
- `IChartSeries` — represents one data series; `Legend`, `XAxisSource`, `YAxisSource` are all `IString`
- `IAxis` — represents a chart axis with a `Legend` (`IString`) label

All string-typed properties use `IString` from `Pure.Primitives.Abstractions` rather than `System.String`, keeping the model decoupled from concrete string representations.

**Multi-targeting:** `net7.0`, `net8.0`, `net9.0`, `net10.0`. All interfaces must remain AOT-compatible (`IsAotCompatible = true`).

**Package validation:** `EnablePackageValidation = true` with `PackageValidationBaselineVersion = 0.1.0-preview.1.0.0`. Any API-breaking change (removing a member, changing a type) will fail the build. Additions must be purely additive.

**Publishing:** triggered automatically by pushing a semver tag (e.g., `git tag 1.0.0 && git push origin 1.0.0`). The tag becomes the `PackageVersion`. Publishes to both GitHub Packages and NuGet.

## Code Style

Enforced via `.editorconfig` and `dotnet format --verify-no-changes` in CI:

- No `var` — always use explicit types
- File-scoped namespaces (`namespace Foo;`)
- `using` directives outside the namespace
- Interfaces: `I`-prefixed PascalCase

## Commit Messages

Do not mention Claude or AI assistance in commit messages.
