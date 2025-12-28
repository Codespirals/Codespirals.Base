# Codespirals.Base

This package contains a set of interfaces, classes and helper functions at the basis of all **Codespirals** solutions and projects.

## Main items

### Identifiable
The `IIdentifiable` interface makes sure that identifiable items (basically any object) all have a common reference point, eliminating all guess work as to what the identifier is called on any given object.

    interface IIdentifiable
    {
        string Id { get; }
    }

### Result Pattern
This library provides mostly guiding interfaces, however for the Result pattern we have the `IResult` interface (and variations) as well as a `Result` class for a basic implementation of the former. 
This should be enough for most projects, though one can always just build their own class using the interfaces.

    interface IResult<TErrorCode>
    {
        bool Success { get; }
        TErrorCode? ErrorCode { get; }
        string Error { get; }
    }

### Selectables
The `ISelectableBase` and the `IIsEnum<TSelf>` interfaces are made to provide a basis for quick, easy and most importantly unified, yet still expressive custom enums.

    interface ISelectableBase
    {
        string Id { get; }
        string Name { get; }
        string Description { get; }
    }

### Filtering
The `IFilterParameters` and `ISearchParameters` interfaces enforce clear parameters to be used to filter a list by, as well as enable pagination (with `IPagination`).
Here too the library provides a basic implementation with the `FilterParameters` / `SearchParameters` classes, as these are enough for most use cases.

    interface IFilterParameters
    {
        int Page { get; }
        int Limit { get; }
        string Sort { get; }
        bool Ascending { get; }
    }

